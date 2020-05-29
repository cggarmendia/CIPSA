using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIPSA.M_VI.WebApp.Controllers
{
    public class HomeController : Controller
    {      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExerciseEleven()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}