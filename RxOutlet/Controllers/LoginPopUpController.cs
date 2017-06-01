using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RxOutlet.Models;

namespace RxOutlet.Controllers
{
    public class LoginPopUpController : Controller
    {
        // GET: LoginPopUp
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(LoginViewModel login)
        {
            return View();
        }
    }
}