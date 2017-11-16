using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RxOutlet.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using RxOutlet.Business;

namespace RxOutlet.Controllers
{
    public class ContactUSController : Controller
    {
        [HttpGet]
        public ActionResult ContactUS()
        {


            ContactUs objcontactUs = new ContactUs();
            RxOutletService objservice = new RxOutletService();

            var result = objservice.GetContactUsSubjectHeading();

            List<SelectListItem> ObjItem = new List<SelectListItem>();
            foreach (var x in result)
            {
                var p = new SelectListItem();
                p.Text = x.SubjectHeadingName;
                p.Value = x.SubjectHeadingID.ToString();
                ObjItem.Add(p);
            }
            ViewBag.SubjectHeading = ObjItem;

            return View(objcontactUs);



        }

        // Calling on http post (on Submit)
        [HttpPost]
        public ActionResult ContactUS(ContactUs model)
        {
            IRxOutletService RxOutletSvc = new RxOutletService();

            model.SubjectHeadingID = Convert.ToInt32(Request.Form["SubjectHeading"]);
            RxOutletSvc.ContactUs(model);
            return RedirectToAction("index", "Home");
        }

    
            }
        }





      

