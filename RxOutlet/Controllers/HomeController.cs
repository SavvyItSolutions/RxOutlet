using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RxOutlet.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.Collections;
using Newtonsoft.Json.Linq;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Web;
using System.IO;
using static System.Net.WebRequestMethods;

namespace RxOutlet.Controllers
{
    public class HomeController : Controller
    {
        // GET: AboutUS
        public ActionResult Index()
        {
            return View();
        }

        // GET: AboutUS
        public ActionResult About()
        {
            return View();
        }

        // GET: AboutUS
        public ActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> PrescriptionUploadView(UploadPrescription obj)
        {
            string path = @"G:\prescription.jpeg";
            //  string path =obj.Filepath;
           
           StorageCredentials sc = new StorageCredentials("icsintegration", "+7UyQSwTkIfrL1BvEbw5+GF2Pcqh3Fsmkyj/cEqvMbZlFJ5rBuUgPiRR2yTR75s2Xkw5Hh9scRbIrb68GRCIXA==");
            CloudStorageAccount storageaccount = new CloudStorageAccount(sc, true);
            CloudBlobClient blobClient = storageaccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("rxoutlet");
            await container.CreateIfNotExistsAsync();
            CloudBlockBlob blob = container.GetBlockBlobReference("Prescription.jpeg");
            //  LoggingClass.LogInfo("Updated profile picture", screenid);
            using (var fs = System.IO.File.Open(path, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None))
            {

                await blob.UploadFromStreamAsync(fs);
                //uploadsuccessmail(name,email);

            }


            return View();
        }

        public ActionResult _ProductCategories() //This view is strongly typed against User
        {
           // return View();


            return PartialView();
        }



        public ActionResult MyAccount() //This view is strongly typed against User
        {
         

            return PartialView();
        }
        public ActionResult _Wishlist() //This view is strongly typed against User
        {
         
            return PartialView();
        }
        public ActionResult _Checkout() //This view is strongly typed against User
        {
           
            return PartialView();
        }

        public ActionResult MySettings() //This view is strongly typed against User
        {

            return View();
        }

        public ActionResult Testpopup() //This view is strongly typed against User
        {

            return View();
        }

        public ActionResult profile() //This view is strongly typed against User
        {

            return View();
        }
    }
}