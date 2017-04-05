using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RxOutlet.Models;
using RxOutlet.Business;
using Newtonsoft.Json;

namespace RxOutlet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.Name = "Rx Outlet";
            ViewData["Name"] = "Rx OutLet";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        



        [HttpGet]
        public JsonResult Menuitems()
        {

            var menu = new { MenuNames="Home",SubMenu="Product Categories",Menuitems="Diabetic Supplies" };
            return Json(menu, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMenuitems()
        {
            var menuDetails = GetMenuDetails();
            return Json(menuDetails,JsonRequestBehavior.AllowGet);
        }


        public List<MenuDetailsModel> GetMenuDetails()
        {
            var MenuList = new List<MenuDetailsModel>
            {
                new MenuDetailsModel
                {
                    menu="Home",
                    submenu="Product Categorie",
                    menuitem="Diabetic Suplies"
                },

                new MenuDetailsModel
                {
                    menu="Pharmacy",
                    submenu="Prescription Services",
                    menuitem="new prescription"
                },
                new MenuDetailsModel
                {
                    menu="Forms",
                    submenu="About RX USA Outlet",
                    menuitem=""
                }
            };
            return MenuList;
        }

        [ChildActionOnly]
        public ActionResult GetHtmlPage(string path)
        {
            return new FilePathResult(path, "html");
        }





        [HttpGet]
        public JsonResult MenuList()
        {
            //var menuDetails = ();
            //return Json(menuDetails, JsonRequestBehavior.AllowGet);

            RxOutletMenuListRespone resp = new RxOutletMenuListRespone();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetMenuList();
          
            string json = JsonConvert.SerializeObject(resp);
              return Json(json, JsonRequestBehavior.AllowGet);

        }



        [HttpGet]
        public JsonResult SubMenuList(int objectId)
        {
          

            RxOutletSubMenuListResponse resp = new RxOutletSubMenuListResponse();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetSubMenuList(objectId);

            string json = JsonConvert.SerializeObject(resp);
            return Json(json, JsonRequestBehavior.AllowGet);

        }



        [HttpGet]
        public JsonResult MenuItemList(int objectId, int userid)
        {


            RxOutLetMenuItemListResponse resp = new RxOutLetMenuItemListResponse();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetMenuItemList(objectId, userid);

            string json = JsonConvert.SerializeObject(resp);
            return Json(json, JsonRequestBehavior.AllowGet);

        }






    }
}