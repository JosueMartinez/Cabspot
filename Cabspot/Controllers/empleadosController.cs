﻿using System;
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
    public class empleadosController : Controller
    {
        private CabspotDB db = new CabspotDB();

        // GET: empleados
        public async Task<ActionResult> Index()
        {
            var empleados = db.empleados.Include(e => e.bases).Include(e => e.estadoempleados).Include(e => e.roles);
            return View(await empleados.ToListAsync());
        }

        // GET: empleados/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = await db.empleados.FindAsync(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: empleados/Create
        public ActionResult Create()
        {
            empleados empleado = new empleados();
            direcciones d = new direcciones();
            personas p = new personas();
            contactos c = new contactos();
            empleado.listaBases = new SelectList(db.bases, "idBase", "nombreBase");
            empleado.listaRoles = new SelectList(db.roles, "idRol", "rol");
            d.listaProvincias = new SelectList(db.provincias, "idProvincia", "nombreProvincia");  //enviando el listado de provincias al View
            p.direcciones = d;
            empleado.personas = p;
            
            return View(empleado);
        }

        // POST: empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(empleados empleados, HttpPostedFileBase foto)
        {
            
            //asignando ids
            try
            {
                //base y rol
                empleados.idBase = int.Parse(empleados.baseSeleccionada);
                empleados.idRol = int.Parse(empleados.rolSeleccionado);

                //estado siempre activo
                var idEstadoEmpleado = (from e in db.estadoempleados where e.estadoEmpleado.Equals("Activo") select e.idEstadoEmpleado).First();
                empleados.idEstadoEmpleado = idEstadoEmpleado;
                empleados.fechaRegistro = DateTime.Now;
                //registradoPor

                //direccion
                empleados.personas.direcciones.idMunicipio = empleados.personas.direcciones.municipioSeleccionado;

                //subir foto
                var filename = Path.GetFileName(foto.FileName);
                var path = Path.Combine(Server.MapPath(@"~/App_Data/files/"), filename);
                foto.SaveAs(path);
                empleados.personas.foto = path;
               // ModelState.SetModelValue("personas.foto", new ValueProviderResult(path,path, ));
            }
            catch (Exception e)
            {
                empleados.listaBases = new SelectList(db.bases, "idBase", "nombreBase");
                empleados.listaRoles = new SelectList(db.roles, "idRol", "rol");
                empleados.personas.direcciones.listaProvincias = new SelectList(db.provincias, "idProvincia", "nombreProvincia");  //enviando el listado de provincias al View

                return View(empleados);
            }
            
            
            if (ModelState.IsValid)
            {
                try
                {
                    db.empleados.Add(empleados);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    TempData["error"] = e.ToString();
                    return Redirect("~/Shared/Error.cshtml");
                }
                
            }
            var errors = ViewData.ModelState.Where(n => n.Value.Errors.Count > 0).ToList();
            //retornando en caso de falta de algo
            empleados.listaBases = new SelectList(db.bases, "idBase", "nombreBase");
            empleados.listaRoles = new SelectList(db.roles, "idRol", "rol");
            empleados.personas.direcciones.listaProvincias = new SelectList(db.provincias, "idProvincia", "nombreProvincia");  //enviando el listado de provincias al View
                
            return View(empleados);
        }

        // GET: empleados/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = await db.empleados.FindAsync(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBase = new SelectList(db.bases, "idBase", "nombreBase", empleados.idBase);
            ViewBag.registradoPor = new SelectList(db.empleados, "idEmpleado", "usuario", empleados.registradoPor);
            ViewBag.idEstadoEmpleado = new SelectList(db.estadoempleados, "idEstadoEmpleado", "estadoEmpleado", empleados.idEstadoEmpleado);
            ViewBag.idRol = new SelectList(db.roles, "idRol", "rol", empleados.idRol);
            return View(empleados);
        }

        // POST: empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idEmpleado,fechaRegistro,registradoPor,idEstadoEmpleado,idBase,idRol,usuario,contrasena")] empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idBase = new SelectList(db.bases, "idBase", "nombreBase", empleados.idBase);
            ViewBag.registradoPor = new SelectList(db.empleados, "idEmpleado", "usuario", empleados.registradoPor);
            ViewBag.idEstadoEmpleado = new SelectList(db.estadoempleados, "idEstadoEmpleado", "estadoEmpleado", empleados.idEstadoEmpleado);
            ViewBag.idRol = new SelectList(db.roles, "idRol", "rol", empleados.idRol);
            return View(empleados);
        }

        // GET: empleados/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = await db.empleados.FindAsync(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            empleados empleados = await db.empleados.FindAsync(id);
            db.empleados.Remove(empleados);
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