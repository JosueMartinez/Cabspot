using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cabspot.Models;
using Twilio;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Cabspot.Controllers.Clases;

namespace Cabspot.Controllers
{
    public partial class MyDatabaseEntities : DbContext
    {
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }

                throw;  // You can also choose to handle the exception here...
            }
        }
    }

    public class requestSmsController : Controller
    {
        private CabspotDB db = new CabspotDB();

        // GET: requestSms
        public async Task<ActionResult> Index()
        {
            var clientes = db.clientes.Include(c => c.personas);
            return View(await clientes.ToListAsync());
        }

        

        // GET: requestSms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = await db.clientes.FindAsync(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: requestSms/Create
        public ActionResult Create()
        {
            ViewBag.idPersona = new SelectList(db.personas, "idPersona", "identificacion");
            return View();
        }

        public JsonResult getTelefonoMovil(string telefonoMovil)
        {
            //recibo un json el cual convierto a string
            string telefono = (telefonoMovil);
            contactos c = createContacto(telefonoMovil);
            autenticacionSms sms = generarCodigo();

            string AccountSid = Constantes.ACCOUNT_SID;
            string AuthToken = "e4b0d062616e0d65e9bc155b829b816a";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);

            var message = twilio.SendMessage(
                "+19179831394", "+18297596854",
                "Tu codigo es este " + sms.codigo);

            return Json("jordani" + telefono, JsonRequestBehavior.AllowGet);
        }

        public contactos createContacto(String telefonoMovil)
        {
            contactos c = new contactos();
            c.telefonoMovil = telefonoMovil = "+18297596854";
            //c.telefonoResidencial = "8297596854";
            //c.telefonoTrabajo = "8297596854";
            //c.fax = "8297596854";
            //c.email = "jordanirozon1@gmail.com";
            //c.emailAlternativo = "jordanirozon1@gmail.com";
            //c.paginaWeb = "www.google.com";
            db.contactos.Add(c);
            db.SaveChanges();
        
            return c;
        }

        public autenticacionSms generarCodigo()
        {
            Random random = new Random();
            autenticacionSms sms = new autenticacionSms();
            int otp = random.Next(100000, 999999);
            sms.idCliente = 1;
            sms.codigo = otp.ToString();

            db.autenticacionSms.Add(sms);
            db.SaveChanges();

            return sms;
        }

        public void verificarCodigo(String telefonoMovil, int otp)
        {
            contactos c = new contactos();
            autenticacionSms sms = new autenticacionSms();
        }

        // POST: requestSms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idCliente,idPersona,nombreUsuario,apikey,fechaRegistro")] clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.clientes.Add(clientes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idPersona = new SelectList(db.personas, "idPersona", "identificacion", clientes.idPersona);
            return View(clientes);
        }

        // GET: requestSms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = await db.clientes.FindAsync(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPersona = new SelectList(db.personas, "idPersona", "identificacion", clientes.idPersona);
            return View(clientes);
        }

        // POST: requestSms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idCliente,idPersona,nombreUsuario,apikey,fechaRegistro")] clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idPersona = new SelectList(db.personas, "idPersona", "identificacion", clientes.idPersona);
            return View(clientes);
        }

        // GET: requestSms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = await db.clientes.FindAsync(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: requestSms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            clientes clientes = await db.clientes.FindAsync(id);
            db.clientes.Remove(clientes);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
