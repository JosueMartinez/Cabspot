using Cabspot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cabspot.Controllers
{
    public class HomeController : Controller
    {
        CabspotDB db = new CabspotDB();

        //enviando taxistas y su ubicacion
        public JsonResult ubicacionTaxistas()
        {
            var taxistas = from t in db.taxistas select new {t.codigoTaxista, t.personas.nombres,t.personas.apellidos, t.idTaxista,
                                                             t.longitudActual, t.latitudActual, t.estadodisponibilidad.estadoDisponibilidad,
                                                             t.personas.contactos.telefonoMovil, t.rating, t.personas.foto};
                return Json(taxistas.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ubicacionTaxista(int id)
        {
            
            if (id != null)
            {
                var taxistas = from t in db.taxistas where t.idTaxista == id select new {t.codigoTaxista, t.personas.nombres,t.personas.apellidos, t.idTaxista,
                                                             t.longitudActual, t.latitudActual, t.estadodisponibilidad.estadoDisponibilidad,
                                                             t.personas.contactos.telefonoMovil, t.rating, t.personas.foto};

                return Json(taxistas.ToList(), JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        //vista de mapa
        public ActionResult Index()
        {
            return View();
        }
    }
}
