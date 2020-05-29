using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIPSA.M_II.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExerciseFour()
        {
            ViewBag.Message = "Entra tu nombre:";

            return View();
        }
    }
}