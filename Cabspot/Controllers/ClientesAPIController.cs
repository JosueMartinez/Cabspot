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

namespace Cabspot.Controllers
{
    public class ClientesAPIController : ApiController
    {
        private CabspotDB db = new CabspotDB();

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