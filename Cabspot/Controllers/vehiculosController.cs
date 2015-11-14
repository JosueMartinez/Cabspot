using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cabspot.Controllers
{
    public class vehiculosController : Controller
    {
        // GET: vehiculos
        public ActionResult Index()
        {
            return View();
        }
    }
}