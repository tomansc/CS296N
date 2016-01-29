using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Toman296Lab2.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult Map()
        {
            ViewBag.Message = "Where is Bellingham, anyway?";
            return View();
        }
    }
}