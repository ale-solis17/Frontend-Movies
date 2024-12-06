using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Silicon.Controllers
{
    public class AccountController : Controller
    {
        // Usa System.Web.Mvc.HttpGetAttribute, no System.Web.Http.HttpGetAttribute
        // GET: Account
        public ActionResult collections()
        {
            return View();
        }
        public ActionResult details()
        {
            return View();
        }
        public ActionResult messages()
        {
            return View();
        }
        public ActionResult notifications()
        {
            return View();
        }
        public ActionResult payment()
        {
            return View();
        }
        public ActionResult saveditems()
        {
            return View();
        }
        public ActionResult security()
        {
            return View();
        }
        public ActionResult signin()
        {
            return View();
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult signup()
        {
            return View();
        }
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(ActionModel.RegisterModel model)
        { 
        }

        }
}