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
            vehiculos v = new vehiculos();
            v.listaCondicion = new SelectList(db.condicionvehiculos, "idCondicionVehiculo", "condicionVehiculo");
            v.listaEstado = new SelectList(db.estadovehiculos, "idEstadoVehiculo", "estadoVehiculo");
            v.listaTipo = new SelectList(db.tipovehiculos, "idTipoVehiculo", "tipoVehiculo");
            taxistas.vehiculo = v;
            return View(taxistas);
        }

        // GET: taxistas/Create
        public ActionResult Create()
        {
            taxistas taxista = new taxistas();
            vehiculos v = new vehiculos();
            direcciones d = new direcciones();
            personas p = new personas();
            contactos c = new contactos();
            taxista.listaBases = new SelectList(db.bases, "idBase", "nombreBase");
            //empleado.listaRoles = new SelectList(db.roles, "idRol", "rol");
            d.listaProvincias = new SelectList(db.provincias, "idProvincia", "nombreProvincia");  //enviando el listado de provincias al View
            p.direcciones = d;
            taxista.personas = p;
            //v.listaCondicion = new SelectList(db.condicionvehiculos, "idCondicionVehiculo", "condicionVehiculo");            
            //v.listaEstado= new SelectList(db.estadovehiculos, "idEstadoVehiculo", "estadoVehiculo");
            //v.listaTipo = new SelectList(db.tipovehiculos, "idTipoVehiculo", "tipoVehiculo");
            //taxista.vehiculo = v;

            return View(taxista);
        }

        // POST: taxistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(taxistas taxistas, HttpPostedFileBase foto, string comando)
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
                        return RedirectToAction("Details", "taxistas", new { id = taxistas.idTaxista });
                    }
                    catch (Exception e)
                    {
                        TempData["error"] = e.ToString();
                        return Redirect("~/Shared/Error.cshtml");
                    }
                }

                taxistas.listaBases = new SelectList(db.bases, "idBase", "nombreBase", taxistas.baseSeleccionada);
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


        //agregar vehiculo al taxista antes de su creacion, agreagar a db junto con el taxista
        [HttpPost]
        public async Task<ActionResult> AgregarVehiculo(taxistas taxista)
        {
            var idTaxista = Request.Form["idTaxista"];
            //asignando ids de estados
            taxista.vehiculo.idCondicionVehiculo = taxista.vehiculo.condicionSeleccionada;
            taxista.vehiculo.idEstadoVehiculo = taxista.vehiculo.estadoSeleccionado;
            taxista.vehiculo.idTipoVehiculo = taxista.vehiculo.tipoSeleccionado;
            taxista.vehiculo.registradoPor = 1;  //meanwhile

            taxistas t = db.taxistas.Find(taxista.idTaxista);

            if (ModelState.IsValid)
            {
                db.vehiculos.Add(taxista.vehiculo);
                await db.SaveChangesAsync();
                ViewData["mensajeAgregarVehiculo"] = "Se ha agregado un vehículo para este taxista";
                return View("Details", t);
            }

            var errors = ViewData.ModelState.Where(n => n.Value.Errors.Count > 0).ToList();
            taxista.vehiculo.listaCondicion = new SelectList(db.condicionvehiculos, "idCondicionVehiculo", "condicionVehiculo", taxista.vehiculo.condicionSeleccionada);
            taxista.vehiculo.listaEstado = new SelectList(db.estadovehiculos, "idEstadoVehiculo", "estadoVehiculo", taxista.vehiculo.estadoSeleccionado);
            taxista.vehiculo.listaTipo = new SelectList(db.tipovehiculos, "idTipoVehiculo", "tipoVehiculo", taxista.vehiculo.tipoSeleccionado);
            ViewData["mensajeAgregarVehiculo"] = "Ha ocurrido un error agregando el vehículo.";
            return View("Details", taxista);
        }

    }
}
