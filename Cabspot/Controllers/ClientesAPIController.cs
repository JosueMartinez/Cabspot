using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Cabspot.Models;
using Twilio;
using Cabspot.Controllers.Clases;
using System.Text.RegularExpressions;

namespace Cabspot.Controllers
{
    public class ClientesAPIController : ApiController
    {
        private CabspotDB db = new CabspotDB();


        //login
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("clientes/login/{telefonoMovil}")]
        public bool loginCliente(string telefonoMovil)
        {
            //telefono con formato E.164  ej. +1809453123
            string telefonoFormat = "";

            //variables de twilio
            string AccountSid = Constantes.ACCOUNT_SID_CABSPOT;
            string AuthToken = Constantes.AUTH_TOKEN_CABSPOT;
            var twilio = new TwilioRestClient(AccountSid, AuthToken);


            if (!string.IsNullOrEmpty(telefonoMovil))
            {
                //verificar que es un numero en formato correcto ---------------------
                telefonoFormat = contactos.FormatearCelular(telefonoMovil);
                if (telefonoFormat != null)
                {

                    //buscar al cliente en clientesMovil
                    var clientes = db.clientesMovil.Where(x => x.telefonoMovil.Equals(telefonoMovil));

                    //verificar si existe un cliente con ese numero movil
                    if (clientes.Count() > 0)
                    {
                        //si existe enviar mensaje de texto
                        clientesMovil cliente = clientes.First();

                        //enviar mensaje de texto
                        return clientesMovil.enviarMensajeTexto(cliente);

                    }
                    else
                    {
                        //sino existe crear el clienteMovil

                        clientesMovil clientePrimeraVez = new clientesMovil();
                        clientePrimeraVez.fechaRegistro = DateTime.Now;
                        clientePrimeraVez.telefonoMovil = telefonoMovil;

                        try
                        {
                            //guardar el cliente
                            db.clientesMovil.Add(clientePrimeraVez);
                            db.SaveChanges();

                            //buscar este cliente recien guardado
                            var clientesMoviles = db.clientesMovil.Where(x => x.telefonoMovil.Equals(telefonoMovil));

                            if (clientesMoviles.Count() > 0)
                            {
                                clientesMovil clienteMovil = clientesMoviles.First();

                                //enviar mensaje de texto
                                return clientesMovil.enviarMensajeTexto(clienteMovil);
                            }
                        }
                        catch (Exception e)
                        {
                            return false;
                        }
                    }
                }

                return false;
            }
            return false;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("clientes/autenticar/{codigoVerificacion}")]
        //[ResponseType(typeof(taxistas))]
        public IHttpActionResult autenticarCliente(string codigoVerificacion)
        {
            if (!string.IsNullOrEmpty(codigoVerificacion))
            {
                //buscar codigo en BD
                autenticacionsms sms = new autenticacionsms();
                var listaSMS = db.autenticacionSms.Where(x => x.codigo.Equals(codigoVerificacion));
                if (listaSMS.Count() > 0)
                {
                    sms = listaSMS.First();
                }

                //verificar el mensaje se ha enviado
                if (sms != null)
                {
                    //verificar que no haya sido verificado ya
                    if (!sms.verificado)
                    {
                        sms.verificado = true;
                        var clientes = db.clientes.Where(x => x.personas.contactos.telefonoMovil.Equals(sms.clientesMovil.telefonoMovil));

                        clienteRetorno cr = new clienteRetorno();
                        //cr.autenticado = true;

                        //si es un cliente antiguo                        
                        if (clientes.Count() > 0)
                        {
                            cr.antiguedadCliente = "Existente";
                            cr.idCliente = clientes.First().idCliente;
                        }
                        //si es un cliente nuevo
                        else
                        {
                            cr.antiguedadCliente = "Nuevo";
                        }

                        return Ok(cr);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("clientes/create")]
        [ResponseType(typeof(clientes))]
        public IHttpActionResult crearCliente(clienteNuevo cliente)
        {
            return Ok();
        }

        // GET: api/ClientesAPI
        public IQueryable<clientes> Getclientes()
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account
            string AccountSid = "AC44ec8cb4a1f64fbaf319c8631d9ad15b";
            string AuthToken = "e4b0d062616e0d65e9bc155b829b816a";

            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var message = twilio.SendMessage("+19179831394", "+18297596854", "Cabspot en accion", "");

            Console.WriteLine(message.Sid);
            return db.clientes;
        }

        // GET: api/ClientesAPI/5
        [ResponseType(typeof(clientes))]
        public async Task<IHttpActionResult> Getclientes(int id)
        {
            clientes clientes = await db.clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            return Ok(clientes);
        }

        // PUT: api/ClientesAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putclientes(int id, clientes clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientes.idCliente)
            {
                return BadRequest();
            }

            db.Entry(clientes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ClientesAPI
        [ResponseType(typeof(clientes))]
        public async Task<IHttpActionResult> Postclientes(clientes clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.clientes.Add(clientes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = clientes.idCliente }, clientes);
        }

        // DELETE: api/ClientesAPI/5
        [ResponseType(typeof(clientes))]
        public async Task<IHttpActionResult> Deleteclientes(int id)
        {
            clientes clientes = await db.clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            db.clientes.Remove(clientes);
            await db.SaveChangesAsync();

            return Ok(clientes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool clientesExists(int id)
        {
            return db.clientes.Count(e => e.idCliente == id) > 0;
        }
    }
}