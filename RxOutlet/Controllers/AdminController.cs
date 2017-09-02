using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RxOutlet.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminPage()
        {
            return View("AdminPage");
        }

        //public ActionResult PendingPrescriptions()
        //{
        //    return View("PendingPrescriptions", "~/Views/Shared/_AdminLayout.cshtml");
        //}

        //public ActionResult ReadyToPickup()
        //{
        //    return View("ReadyToPickup", "~/Views/Shared/_AdminLayout.cshtml");
        //}
    }
}