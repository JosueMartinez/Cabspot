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
using System.IO;

namespace Cabspot.Controllers
{
    public class taxistasController : Controller
    {
        private CabspotDB db = new CabspotDB();

        // GET: taxistas
        public async Task<ActionResult> Index()
        {
            return View(await db.taxistas.ToListAsync());
        }

        // GET: taxistas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taxistas taxistas = await db.taxistas.FindAsync(id);
            if (taxistas == null)
            {
                return HttpNotFound();
            }
            return View(taxistas);
        }

        // GET: taxistas/Create
        public ActionResult Create()
        {
            taxistas taxista = new taxistas();
            direcciones d = new direcciones();
            personas p = new personas();
            contactos c = new contactos();
            taxista.listaBases = new SelectList(db.bases, "idBase", "nombreBase");
            //empleado.listaRoles = new SelectList(db.roles, "idRol", "rol");
            d.listaProvincias = new SelectList(db.provincias, "idProvincia", "nombreProvincia");  //enviando el listado de provincias al View
            p.direcciones = d;
            taxista.personas = p;

            return View(taxista);
        }

        // POST: taxistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(taxistas taxistas, HttpPostedFileBase foto)
        {
            //asignando ids
            try
            {
                //base
                taxistas.idBase = int.Parse(taxistas.baseSeleccionada);
                //creado como disponible por default
                var idEstadoDisponibilidad = (from e in db.estadodisponibilidad where e.estadoDisponibilidad.Equals("Disponible") select e.idEstadoDisponibilidad).First();
                taxistas.idEstadoDisponibilidad = idEstadoDisponibilidad;
                //direccion
                taxistas.personas.direcciones.idMunicipio = taxistas.personas.direcciones.municipioSeleccionado;

                //subir foto
                var filename = Path.GetFileName(foto.FileName);
                var path = Path.Combine(Server.MapPath(@"~/App_Data/files/"), filename);
                foto.SaveAs(path);
                taxistas.personas.foto = path;


                //verificar que codigo de taxista no esta asignado

                //model error para identidad reutilizada distintos

                //model error para movil e email distintos

            }
            catch (Exception e)
            {
                taxistas.listaBases = new SelectList(db.bases, "idBase", "nombreBase");
                taxistas.personas.direcciones.listaProvincias = new SelectList(db.provincias, "idProvincia", "nombreProvincia");  //enviando el listado de provincias al View

                return View(taxistas);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.taxistas.Add(taxistas);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    TempData["error"] = e.ToString();
                    return Redirect("~/Shared/Error.cshtml");
                }
            }

            taxistas.listaBases = new SelectList(db.bases, "idBase", "nombreBase");
            taxistas.personas.direcciones.listaProvincias = new SelectList(db.provincias, "idProvincia", "nombreProvincia");  //enviando el listado de provincias al View

            return View(taxistas);
        }

        // GET: taxistas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taxistas taxistas = await db.taxistas.FindAsync(id);
            if (taxistas == null)
            {
                return HttpNotFound();
            }
            return View(taxistas);
        }

        // POST: taxistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idTaxista,idPersona,codigoTaxita,idEstadoDisponibilidad,idBase,fechaRegistro,registradoPor,latitudActual,longitudActual,ultimaActualizacionPosicion")] taxistas taxistas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taxistas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(taxistas);
        }

        // GET: taxistas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taxistas taxistas = await db.taxistas.FindAsync(id);
            if (taxistas == null)
            {
                return HttpNotFound();
            }
            return View(taxistas);
        }

        // POST: taxistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            taxistas taxistas = await db.taxistas.FindAsync(id);
            db.taxistas.Remove(taxistas);
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
