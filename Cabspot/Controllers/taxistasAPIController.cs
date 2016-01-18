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
using System.Web.Mvc;
using Cabspot.Controllers.Clases;
using Twilio;
using Cabspot.Models;
using System.Text.RegularExpressions;

namespace Cabspot.Controllers
{
    public class taxistasAPIController : ApiController
    {
        private CabspotDB db = new CabspotDB();

        //login -------------------------------------------------------------------------
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("taxistas/login/{codigoTaxista}")]
        public bool loginTaxista(string codigoTaxista)
        {
            //variables de twilio
            string AccountSid = Constantes.ACCOUNT_SID_CABSPOT;
            string AuthToken = Constantes.AUTH_TOKEN_CABSPOT;
            var twilio = new TwilioRestClient(AccountSid, AuthToken);

            //buscar el taxista que tiene ese codigoTaxista
            if (!string.IsNullOrEmpty(codigoTaxista))
            {
                var taxistaLogin = taxistas.BuscarPorCodigo(codigoTaxista);
                if (taxistaLogin != null)
                {
                    //enviar mensaje de texto 
                    autenticacionsmstaxista sms = taxistas.generarCodigoTaxista(taxistaLogin.idTaxista);
                    if (sms != null)
                    {
                        try
                        {
                            //formato EI64 para el numero
                            var numero = contactos.FormatearCelular(taxistaLogin.personas.contactos.telefonoMovil);  
                            //si el numero no esta en el formato correcto SALIR
                            if (numero == null)
                            {
                                return false;
                            }
                            //enviando mensaje
                            var message = twilio.SendMessage(Constantes.PHONE_CABSPOT, numero, Constantes.Mensaje_Codigo + sms.codigo);
                            //respuesta si el mensaje fue enviado o no
                            if(!string.IsNullOrEmpty(message.Sid))
                                return true;
                            return false;
                        }
                        catch (Exception e)
                        {
                            return false;
                        }
                    }
                    return false;
                    
                }
                return false; 
            }
            return false;          
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("taxistas/autenticar/{codigoVerificacion}")]
        [ResponseType(typeof(taxistas))]
        public IHttpActionResult autenticarTaxista(string codigoVerificacion)
        {
            if (!string.IsNullOrEmpty(codigoVerificacion))
            {
                //buscar codigo en tabla autenticacionsmstaxista
                autenticacionsmstaxista sms = new autenticacionsmstaxista();// = autenticacionsmstaxista.getAutenticacionSMS(codigoVerificacion);
                
                var listaSMS = from l in db.autenticacionSmsTaxista where l.codigo.Equals(codigoVerificacion) select l;
                if (listaSMS.Count() > 0)
                {
                    sms = listaSMS.FirstOrDefault();
                }
                

                if (sms != null)
                {
                    //revisar codigo no ha sido verificado
                    if (!sms.verificado)
                    {
                        //buscar taxista
                        taxistas taxista = db.taxistas.Find(sms.idTaxista);
                        
                        if (taxista != null)
                        {
                            //cambio de verificado en DB
                            sms.verificado = true;
                            var vehiculos = taxista.vehiculos.Where(v => v.idEstadoVehiculo == 31);

                            //cambiando estado del taxista a disponible si tiene por lo menos un vehiculo activo
                            if (vehiculos.Count() > 0 && taxista.idEstadoDisponibilidad != 81)
                            {
                                taxista.idEstadoDisponibilidad = 81;
                            }
                                                        
                            try
                            {
                                //actualizando en bd
                                db.Entry(sms).State = EntityState.Modified;
                                db.Entry(taxista).State = EntityState.Modified;
                                db.SaveChanges();
                                //devolver taxista
                                //return Ok(taxista);
                                return getVehiculos(taxista.idTaxista);  //Ok(vehiculosEnviar);
                            }
                            catch (Exception e)
                            {
                                return BadRequest();
                            }
                            
                        }
                        else
                        {
                            return BadRequest();
                        }                        
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

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("vehiculos/getVehiculos/{idTaxista}")]
        public IHttpActionResult getVehiculos(int idTaxista)
        {
                taxistas taxista = db.taxistas.Find(idTaxista);

                if (taxista != null)
                {
                    var vehiculos = taxista.vehiculos;

                    //enviar vehiculos con estado activo para posterior elección
                    var vehiculosEnviar = from v in vehiculos where v.idEstadoVehiculo == 31 select new { v.idVehiculo, v.marca, v.modelo, v.serie, v.placa, v.anio, v.color, v.unidad, v.tipovehiculos.tipoVehiculo };
                    return Ok(vehiculosEnviar);
                }
                else
                {
                    return BadRequest();
                }  
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("vehiculos/activacion/{idVehiculo}")]
        public bool elegirVehiculo(int idVehiculo)
        {
            //buscar vehiculo
            vehiculos vehiculo = db.vehiculos.Find(idVehiculo);
            if (vehiculo == null)
            {
                return false;
            }

            //en caso que el vehiculo ya esta activo
            if (vehiculo.activo)
            {
                return true;
            }

            //sino esta activo

            //buscar todos los vehiculos de ese taxista y deshabilitar
            var todos = db.vehiculos.Where(t => t.idTaxista == vehiculo.idTaxista);
            foreach (var v in todos)
            {
                v.activo = false;
                db.Entry(v).State = EntityState.Modified;
            }

            //activar el seleccionado
            vehiculo.activo = true;
            db.Entry(vehiculo).State = EntityState.Modified;


            //guardar cambios
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
//            return true;
        }
        
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("taxistas/actualizarUbicacion")]
        public void actualizarUbicacion(taxistas taxistas)
        {
            
           //verificar que el id no sea nulo y que exista
            if (taxistas.idTaxista > 0)
            {
                taxistas taxistaBD = db.taxistas.Find(taxistas.idTaxista);
                if (taxistaBD != null && taxistaBD.idEstadoDisponibilidad != 111)   //si el taxista esta activo
                {
                    //verificar que longitud y latitud no sea nulos
                    if (taxistas.longitudActual != null && taxistas.latitudActual != null)
                    {
                        //verificar formato de posicion
                        string patron = @"^(\-?\d+\.\d+)";
                        var validarLat = Regex.Match(taxistas.latitudActual.ToString(), patron);
                        var validarLong = Regex.Match(taxistas.longitudActual.ToString(), patron);

                        if (validarLat.Success && validarLong.Success)
                        {
                            //actualizar ubicacion taxista
                            taxistaBD.latitudActual = taxistas.latitudActual;
                            taxistaBD.longitudActual = taxistas.longitudActual;

                            taxistaBD.ultimaActualizacionPosicion = DateTime.Now;

                            try
                            {
                                //actualizar entidad
                                db.Entry(taxistaBD).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            catch (Exception e) { }
                        }
                    }
                }
            }           
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("taxistas/getDatos/{idTaxista}")]
        public IHttpActionResult getDatos(int idTaxista)
        {
            taxistas taxista = db.taxistas.Find(idTaxista);

            if (taxista != null)
            {
                var t = from x in db.taxistas where x.idTaxista == idTaxista select new { x.idTaxista, x.codigoTaxista, x.personas.nombres, x.personas.apellidos, x.personas.foto };
                if (t.Count() == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(t.First());
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("taxistas/getPerfil/{idTaxista}")]
        public IHttpActionResult getPerfil(int idTaxista)
        {
            taxistas taxista = db.taxistas.Find(idTaxista);

            if(taxista != null)
            {
                var t = from x in db.taxistas 
                        where x.idTaxista == idTaxista 
                        select new {
                                        //informacion basica
                                        x.idTaxista, x.codigoTaxista, x.personas.nombres, x.personas.apellidos, x.personas.foto, x.personas.identificacion, x.personas.fechaNacimiento, x.personas.sexo,
                                        x.rating, x.personas.nacionalidad,
                                        //direccion
                                        x.personas.direcciones.nombreEdificio, x.personas.direcciones.numeroPuerta, x.personas.direcciones.calle, x.personas.direcciones.numeroEdificio, 
                                        x.personas.direcciones.municipios.nombreMunicipio, x.personas.direcciones.municipios.provincias.nombreProvincia,
                                        //contactos
                                        x.personas.contactos.telefonoMovil            
                                    };
                if (t.Count() == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(t.First());
                }

            }
            else
            {
                return BadRequest();
            }


            
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("taxistas/getCarreras/{idTaxista}")]
        public IHttpActionResult getCarreras(int idTaxista)
        {
           var carreras = db.carreras.Where(x => x.idTaxista == idTaxista);
            
           return Ok(carreras);           
        }

        //-------------------------------------------------------------------------------
         
        // GET: api/taxistasAPI
        public IQueryable<taxistas> Gettaxistas()
        {
            return db.taxistas;
        }

        // GET: api/taxistasAPI/5
        [ResponseType(typeof(taxistas))]
        public IHttpActionResult Gettaxistas(int id)
        {
            taxistas taxistas = db.taxistas.Find(id);
            if (taxistas == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(taxistas);
            }
        }

        // PUT: api/taxistasAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttaxistas(int id, taxistas taxistas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taxistas.idTaxista)
            {
                return BadRequest();
            }

            db.Entry(taxistas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!taxistasExists(id))
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

        // POST: api/taxistasAPI
        [ResponseType(typeof(taxistas))]
        public async Task<IHttpActionResult> Posttaxistas(taxistas taxistas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.taxistas.Add(taxistas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = taxistas.idTaxista }, taxistas);
        }

        // DELETE: api/taxistasAPI/5
        [ResponseType(typeof(taxistas))]
        public async Task<IHttpActionResult> Deletetaxistas(int id)
        {
            taxistas taxistas = await db.taxistas.FindAsync(id);
            if (taxistas == null)
            {
                return NotFound();
            }

            db.taxistas.Remove(taxistas);
            await db.SaveChangesAsync();

            return Ok(taxistas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool taxistasExists(int id)
        {
            return db.taxistas.Count(e => e.idTaxista == id) > 0;
        }        
    }
}