using Microsoft.AspNet.Identity;
using RxOutlet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RxOutlet.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductList()
        {
            return View();
        }

       
        public ActionResult PagginationTest()
        {
            return View();
        }

        public ActionResult AngularToolTip()
        {
            return View();
        }

        public ActionResult SearchFunctionality()
        {
            return View();
        }

        public ActionResult DisplayGridView()
        {
            return View();
        }

        public ActionResult DisplayGridViewNew()
        {
            return View();
        }
        public ActionResult AutoSearch()
        {
            return View();
        }
        public ActionResult AddToCart()
        {
            return View();
        }
        public ActionResult AutoSearchFunctionality()
        {
            return View("AutoSearchFunctionality", "~/Views/Shared/AutoSearch.cshtml");
        }
        public ActionResult AutoSearchMouseOver()
        {
            return View("AutoSearchMouseOver", "~/Views/Shared/AutoSearch.cshtml");
        }




        [Authorize]
        public ActionResult ProductDetailsView()
        {

          
        AddToCartModel objSubjectHeading = new AddToCartModel();
           
            return View(objSubjectHeading);
           
        }
     
        // Calling on http post (on Submit)
        [HttpPost]
       
        public ActionResult ProductDetailsView(AddToCartModel obj)
        {
         
            AddToCartModel objreg = new AddToCartModel();
            string result = objreg.InsertCartItems(obj);
            ViewData["result"] = result;
            ModelState.Clear();
            return View(obj);
        }
    }


    
}