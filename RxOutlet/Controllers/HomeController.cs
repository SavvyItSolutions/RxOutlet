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

       
        //public ActionResult upload(Uploadimage )
        //{
        //    if (Request.Files.Count > 0)
        //    {
        //        var file = Request.Files[0];

        //        if (file != null && file.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(file.FileName);
        //            var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
        //            file.SaveAs(path);
        //        }
        //    }

        //    return RedirectToAction("PrescriptionUploadView");
        //}

        //[HttpPost]
        //public ActionResult PrescriptionUploadView()
        //{
        //    if (Request.Files.Count > 0)
        //    {
        //        var file = Request.Files[0];

        //        if (file != null && file.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(file.FileName);
        //            var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
        //            file.SaveAs(path);
        //        }
        //    }
        //    return View();
        //}



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




        public ActionResult PC() //This view is strongly typed against User
        {

            string responseString;
            string jsonobject;
           object MenuItems;

            IEnumerable<string> menu;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://rxoutlet.azurewebsites.net");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/RxOutlet/MenuList").Result;

                //if (response.IsSuccessStatusCode)
                //{

                responseString = response.Content.ReadAsStringAsync().Result;

                    JObject json = JObject.Parse(responseString);
                    jsonobject = responseString;
                    var result = JsonConvert.DeserializeObject<RxOutletMenuListRespone>(jsonobject);

                    MenuItems = result.MenuList.Select(p => p.MenuName).ToList();
                         menu = result.MenuList.Select(p => p.MenuName);

               // }

            }

            return View(menu);


          //  List<string> myList = new List<string>();
            //IEnumerable<object> myEnumerable = MenuItems;
            //List<object> listAgain = myEnumerable.ToList();


            //return PartialView();  --- for PC



            // return PartialView("_TestPC");

            //"_ProductCategories",
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





        //    public ActionResult Index()
        //    {

        //        ViewBag.Name = "Rx Outlet";
        //        ViewData["Name"] = "Rx OutLet";
        //        return View();
        //    }

        //    public ActionResult About()
        //    {
        //        ViewBag.Message = "Your application description page.";

        //        return View();
        //    }

        //    public ActionResult Contact()
        //    {
        //        ViewBag.Message = "Your contact page.";

        //        return View();
        //    }





        //    [HttpGet]
        //    public JsonResult Menuitems()
        //    {

        //        var menu = new { MenuNames="Home",SubMenu="Product Categories",Menuitems="Diabetic Supplies" };
        //        return Json(menu, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        //    }

        //    public JsonResult GetMenuitems()
        //    {
        //        var menuDetails = GetMenuDetails();
        //        return Json(menuDetails,JsonRequestBehavior.AllowGet);
        //    }


        //    public List<MenuDetailsModel> GetMenuDetails()
        //    {
        //        var MenuList = new List<MenuDetailsModel>
        //        {
        //            new MenuDetailsModel
        //            {
        //                menu="Home",
        //                submenu="Product Categorie",
        //                menuitem="Diabetic Suplies"
        //            },

        //            new MenuDetailsModel
        //            {
        //                menu="Pharmacy",
        //                submenu="Prescription Services",
        //                menuitem="new prescription"
        //            },
        //            new MenuDetailsModel
        //            {
        //                menu="Forms",
        //                submenu="About RX USA Outlet",
        //                menuitem=""
        //            }
        //        };
        //        return MenuList;
        //    }

        //    [ChildActionOnly]
        //    public ActionResult GetHtmlPage(string path)
        //    {
        //        return new FilePathResult(path, "html");
        //    }













        //    [HttpGet]
        //    public JsonResult MenuList()
        //    {
        //        //var menuDetails = ();
        //        //return Json(menuDetails, JsonRequestBehavior.AllowGet);
        //        RxOutletController rx = new RxOutletController(); 
        //        RxOutletMenuListRespone resp = rx.MenuList();


        //        string json = JsonConvert.SerializeObject(resp);
        //          return Json(json, JsonRequestBehavior.AllowGet);

        //    }



        //    [HttpGet]
        //    public JsonResult SubMenuList(int objectId)
        //    {


        //        RxOutletSubMenuListResponse resp = new RxOutletSubMenuListResponse();
        //        IRxOutletService itemService = new RxOutletService();
        //        resp = itemService.GetSubMenuList(objectId);

        //        string json = JsonConvert.SerializeObject(resp);
        //        return Json(json, JsonRequestBehavior.AllowGet);

        //    }



        //    [HttpGet]
        //    public JsonResult MenuItemList(int objectId, int userid)
        //    {


        //        RxOutLetMenuItemListResponse resp = new RxOutLetMenuItemListResponse();
        //        IRxOutletService itemService = new RxOutletService();
        //        resp = itemService.GetMenuItemList(objectId, userid);

        //        string json = JsonConvert.SerializeObject(resp);
        //        return Json(json, JsonRequestBehavior.AllowGet);

        //    }






    }
}