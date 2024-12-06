using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Silicon.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult courses()
        {
            return View();
        }
        public ActionResult grid()
        {
            return View();
        }
        public ActionResult list()
        {
            return View();
        }
        public ActionResult singlecourse()
        {
            return View();
        }
        public ActionResult singleproject()
        {
            return View();
        }
        public ActionResult slider()
        {
            return View();
        }
        public ActionResult pricing()
        {
            return View();
        }
    }
}