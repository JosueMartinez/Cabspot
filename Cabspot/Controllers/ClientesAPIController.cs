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
                //verificar que es un numero correcto ---------------------
                telefonoFormat = contactos.FormatearCelular(telefonoMovil);
                if (telefonoFormat != null)
                {
                    
                    //buscar cliente en BD por el telefono
                    var cliente = db.clientes.Where(x => x.personas.contactos.telefonoMovil.Equals(telefonoMovil));
                    if (cliente.Count() > 0)
                    {
                        clientes clienteLogin = cliente.First();

                        //enviar mensaje de texto
                        autenticacionsms sms = clientes.generarCodigoCliente(clienteLogin.idCliente);

                        if (sms != null)
                        {
                            try
                            {
                                //si el numero no esta en el formato correcto salir
                                if (telefonoFormat == null)
                                {
                                    return false;
                                }
                                //enviando mensaje
                                var message = twilio.SendMessage(Constantes.PHONE_CABSPOT, telefonoFormat, Constantes.Mensaje_Codigo + sms.codigo);

                                //devolviendo resultado del envio del mensaje
                                if (!string.IsNullOrEmpty(message.Sid))
                                    return true;
                                return false;
                            }
                            catch (Exception e)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    //el cliente no existe, primera vez que este se registra.
                    //creamos un cliente nuevo
                    else
                    {
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
                                autenticacionsms sms = clientesMovil.generarCodigoCliente(clienteMovil.idClienteMovil);

                                if (sms != null)
                                {
                                    try
                                    {
                                        //formato EI64 para el numero
                                        var numero = contactos.FormatearCelular(clienteMovil.telefonoMovil);
                                        if (numero == null)
                                        {
                                            return false;
                                        }

                                        //enviando mensaje
                                        //enviando mensaje
                                        var message = twilio.SendMessage(Constantes.PHONE_CABSPOT, numero, Constantes.Mensaje_Codigo + sms.codigo);
                                        //respuesta si el mensaje fue enviado o no
                                        if (!string.IsNullOrEmpty(message.Sid))
                                            return true;
                                        return false;
                                    }
                                    catch (Exception e)
                                    {
                                        return false;
                                    }
                                }
                            }                                                     
                            


                        }
                        catch (Exception e)
                        {
                            return false;
                        }

                        
                    }
                }
                else
                {
                    return false;
                }
            }

            return false;
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