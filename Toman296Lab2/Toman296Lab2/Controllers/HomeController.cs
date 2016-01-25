using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Toman296Lab2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "About Bellingham, Jewel of the North";
            ViewBag.Message = "Bellingham, Washington: Yes, one of its official slogans is \"The City of Subdued Excitement.\"";
            ViewBag.Footer = "The current date and time is " + DateTime.Now;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact the site administrator";
            ViewBag.Message = "Everything you need is below.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About the author";
            ViewBag.Message = "About Sam Toman";
            return View();
        }

        public ActionResult History()
        {
            ViewBag.Title = "The history of Bellingham";
            ViewBag.Message = "A partially fabricated history of Bellingham";

            return View();
        }
    }
}