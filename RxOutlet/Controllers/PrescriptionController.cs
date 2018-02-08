using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using RxOutlet.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity.Owin;

using System.Security.Claims;
using Microsoft.Owin.Security.OAuth;
using RxOutlet.Business;

namespace RxOutlet.Controllers
{
    public class PrescriptionController : Controller
    {
        HttpClient client;

        HttpClient ConfirmationEmailClient;

      // The URL of the WEB API Service
         string PrescriptionDetailsURL = "http://rxoutlet.azurewebsites.net/api/Rxoutlet/UploadingPrescriptionNew";

      // string PrescriptionDetailsURL = "http://localhost:64404/api/Rxoutlet/ByteArray";
        string ConfirmationMailURL = "http://rxoutlet.azurewebsites.net/api/Rxoutlet/ConfirmationMail";

      //  string UserPrescriptionListURL = "http://rxoutlet.azurewebsites.net/api/Rxoutlet/GetUserPrescriptionList/";



        public PrescriptionController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(PrescriptionDetailsURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ConfirmationEmailClient = new HttpClient();
            ConfirmationEmailClient.BaseAddress = new Uri(ConfirmationMailURL);
            ConfirmationEmailClient.DefaultRequestHeaders.Accept.Clear();
            ConfirmationEmailClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        UploadPrescriptionModel obj = new UploadPrescriptionModel();
        ImageService imageService = new ImageService();

        public string UserID { get; private set; }

        // GET: Image
        public ActionResult Upload()
        {
            var userid = User.Identity.GetUserId();
            if (userid != null)
                return View();
            else
                TempData["FillNewPrescription"] = "Need to Login to Fill New Prescription.";
            return RedirectToAction("Login","Account");
        }

        public ActionResult PrescriptionList()
        {
            return View();
        }


        [Authorize]
        //The Post method
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase photo, UploadPrescription model)
        {



            if (photo != null)
            {
                List<string> test = new List<string>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                     photo = Request.Files[i];
                    string blobcontainer = "newprescriptions";
                  
                    test.Add(imageService.UploadImageAsync(photo, blobcontainer));
                  //  model.Filepath = imageService.UploadImageAsync(photo, blobcontainer);
                   
                }

                
                
                string blobImagePath = "'" + String.Join("','", test) + "'";

                model.Filepath = blobImagePath;
                model.UserID = User.Identity.GetUserId();

                IRxOutletService RxOutletSvc = new RxOutletService();
                RxOutletSvc.UploadingPrescriptionNew(model);

            }
            else
                model.Filepath = "";

            //model.UserID = User.Identity.GetUserId();

            //IRxOutletService RxOutletSvc = new RxOutletService();
            //      RxOutletSvc.UploadingPrescriptionNew(model);


         

            return View("LatestImage");

        }

        public ActionResult LatestImage(UploadPrescriptionModel model)
        {
            return View();
        }

        public ActionResult UserPrescriptionList()
        {
           string UserID = User.Identity.GetUserId();
            return View("Error");
        }




    }
}