using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Silicon.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult error404v1()
        {
            return View();
        }
        public ActionResult error404v2()
        {
            return View();
        }
    }
}