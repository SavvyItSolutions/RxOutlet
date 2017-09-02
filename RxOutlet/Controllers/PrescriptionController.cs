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

namespace RxOutlet.Controllers
{
    public class PrescriptionController : Controller
    {
    

        HttpClient client;

        HttpClient ConfirmationEmailClient;
        //The URL of the WEB API Service
        string PrescriptionDetailsURL = "http://localhost:64404/api/Rxoutlet/UploadingPrescription";
        string ConfirmationMailURL = "http://localhost:64404/api/Rxoutlet/ConfirmationMail";

        string UserPrescriptionListURL = "http://localhost:64404/api/Rxoutlet/GetUserPrescriptionList/";



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
            return View();
        }

        public ActionResult PrescriptionList()
        {
            return View();
        }

        

        //The Post method
        [HttpPost]
        public async Task<ActionResult> Upload(HttpPostedFileBase photo, UploadPrescriptionModel model)
        {
            //HttpResponseMessage responseMessage = await client.GetAsync(url);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

            //    var Employees = JsonConvert.DeserializeObject<List<EmployeeInfo>>(responseData);

            //    return View(Employees);
            //}
            //return View("Error");
        

        model.Filepath = imageService.UploadImageAsync(photo);
          
            model.UserID = User.Identity.GetUserId();

            HttpResponseMessage PrescriptionDetailsResponse = await client.PostAsJsonAsync(PrescriptionDetailsURL, model);
          
            if (PrescriptionDetailsResponse.IsSuccessStatusCode)
                {

                HttpResponseMessage ConfirmationMailResponse = await client.PostAsJsonAsync(ConfirmationMailURL, model.UserID);

                return View("LatestImage");

                }   
                  return View("Upload");



        }

        public ActionResult LatestImage(UploadPrescriptionModel model)
        {
            //var latestImage = ;
            //if (TempData["LatestImage"] != null)
            //{
            //    ViewBag.LatestImage = Convert.ToString(TempData["LatestImage"]);
            //}


           
            return View();
        }

        public async Task<ActionResult> UserPrescriptionList()
        {
           string UserID = User.Identity.GetUserId();
            string url = UserPrescriptionListURL + UserID;
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Employees = JsonConvert.DeserializeObject<List<UploadPrescriptionModel>>(responseData);

                return View("UserPrescriptionList");
            }
            return View("Error");
        }




    }
}