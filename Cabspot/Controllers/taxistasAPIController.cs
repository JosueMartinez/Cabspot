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

namespace Cabspot.Controllers
{
    public class taxistasAPIController : ApiController
    {
        private CabspotDB db = new CabspotDB();
        taxistas taxista = new taxistas();

        //login -------------------------------------------------------------------------
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("taxistas/login/{codigoTaxista}")]
        public bool loginTaxista(string codigoTaxista)
        {
            //variables de twilio
            string AccountSid = Constantes.ACCOUNT_SID;
            string AuthToken = Constantes.AUTH_TOKEN;
            var twilio = new TwilioRestClient(AccountSid, AuthToken);

            //buscar el taxista que tiene ese telefonoMovil
            if (!string.IsNullOrEmpty(codigoTaxista))
            {
                var taxistaLogin = taxista.FindByCodigo(codigoTaxista);
                if (taxistaLogin != null)
                {
                    //enviar mensaje de texto 
                    autenticacionsmstaxista sms = taxista.generarCodigo(taxistaLogin.idTaxista);
                    if (sms != null)
                    {
                        try
                        {
                            var numero  = "+18099801767";   //taxistaLogin.personas.contactos.telefonoMovil
                            var message = twilio.SendMessage("+19179831394", "+18297596854", "Su código es: " + sms.codigo);
                            return true;
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


        //-------------------------------------------------------------------------------

        // GET: api/taxistasAPI
        public IQueryable<taxistas> Gettaxistas()
        {
            return db.taxistas;
        }

        // GET: api/taxistasAPI/5
        [ResponseType(typeof(taxistas))]
        public async Task<IHttpActionResult> Gettaxistas(int id)
        {
            taxistas taxistas = await db.taxistas.FindAsync(id);
            if (taxistas == null)
            {
                return NotFound();
            }

            return Ok(taxistas);
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