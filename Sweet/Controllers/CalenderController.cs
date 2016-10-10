using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;


namespace Sweet.Controllers
{
    public class CalenderController : Controller
    {
        // GET: Calender
        public ActionResult Index()
        {
            return View();
        }
    }
}