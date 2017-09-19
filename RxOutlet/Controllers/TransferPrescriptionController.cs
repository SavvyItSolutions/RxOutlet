using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RxOutlet.Models;
using Microsoft.AspNet.Identity;
using RxOutlet.Business;

namespace RxOutlet.Controllers
{
    public class TransferPrescriptionController : Controller
    {
     

        [HttpPost]
   
        public ActionResult _TransferPrescriptionView(TransferPrescriptionModel model)
        {

            model.UserID = User.Identity.GetUserId();
            IRxOutletService RxOutletSvc = new RxOutletService();
            RxOutletSvc.TransferPrescription(model);
            return RedirectToAction("upload","Prescription");


           

        }

    }
}