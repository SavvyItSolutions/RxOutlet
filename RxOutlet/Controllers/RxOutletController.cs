using Newtonsoft.Json;
using RxOutlet.Business;
using RxOutlet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using RxOutlet.DataAccess;
using RxOutlet.DataAccess.Interfaces;
using RxOutlet.DataAccess.DataManager;
using RxOutlet.Models;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Diagnostics;

namespace RxOutlet.Controllers
{
    public class RxOutletController : ApiController
    {
        //public RxOutletController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        //{
        //    UserManager = userManager;
        //    SignInManager = signInManager;
        //}
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}



        [HttpGet]
        public PrescriptionResponse GetPrescriptionList()
        {
            PrescriptionResponse resp = new PrescriptionResponse();
            IRxOutletService rxoutletService = new RxOutletService();
            resp = rxoutletService.GetPrescriptionList();
            return resp;
        }



        [HttpGet]
        public PrescriptionResponse GetUserPrescriptionList(string objectId)
        {
            PrescriptionResponse resp = new PrescriptionResponse();
            IRxOutletService rxoutletService = new RxOutletService();
            resp = rxoutletService.GetUserPrescriptionList(objectId);
            return resp;
        }



        [HttpPost]
        public int UploadingPrescription(UploadPrescriptionModel uploadPrescription)
        {

            IRxOutletService rxService = new RxOutletService();
            SendEmail obj = new SendEmail();
            obj.SendOneEmail("soujanyareddy.gade@gmail.com");
            return rxService.UploadingPrescription(uploadPrescription);

        }




        //[HttpGet]
        //public ConfirmationEmailResponse ConfirmationMail(string objectId)
        //{

        //    IRxOutletService rxService = new RxOutletService();


        //    SendEmail objsendmail = new SendEmail();
        //    objsendmail.SendOneEmail("");
          
            
        //    return rxService.ConfirmationMail(objectId);


        //}




        [HttpPost]
        public async Task<int> Registration(RegistrationModel model)
        {
            try
            {
                var user = new ApplicationUser { Name = model.Name, UserName = model.Email, Email = model.Email, PhoneNumber = model.MobileNum };
                var result = await System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().CreateAsync(user, model.Password);
              
            }
            catch (Exception ex)
            { }
            return 1;
        }

        //[HttpGet]
        //public async Task<ConfirmationEmailResponse> ConfirmEmail(string userId, string code)
        //{
        //    ConfirmationEmailResponse objMailResponse = new ConfirmationEmailResponse();
        //    if (userId == null || code == null)
        //    {
                
        //    }
        //    var result = await UserManager.ConfirmEmailAsync(userId, code);
        //    //  return View(result.Succeeded ? "ConfirmEmail" : "Error");

        //    return objMailResponse;
        //}


      

        [HttpPost]
        public async Task<LoginResponse> Login(LoginModel model)
        {
            string email = model.Email;

            LoginResponse resp = new LoginResponse();
          
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: true);
          
            //cant navigate view from api controller 

            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        return RedirectToLocal(returnUrl);
            //    case SignInStatus.LockedOut:
            //        return View("Lockout");
            //    case SignInStatus.RequiresVerification:
            //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            //    case SignInStatus.Failure:
            //    default:
            //        ModelState.AddModelError("", "Invalid login attempt.");
            //        return View(model);
            //}

            return resp;
        }



        //[Authorize]
        //[HttpGet]
        //public CustomerResponse AuthenticateUser(string objectId, string EmailId, string DeviceId)
        //{
        //    DateTime start = DateTime.Now;
        //    Trace.TraceInformation("Started service AuthenticateUser");
        //    string response = null;
        //    CustomerResponse resp = new CustomerResponse();
        //    IItemService itemService = new ItemService();
        //    resp = itemService.AuthenticateUser(objectId, EmailId, DeviceId);
        //    if (resp.customer.CustomerID == 0)//&& resp.customer.IsMailSent == 0)
        //        resp.ErrorDescription = "We do not have your email address in our records. Please update it by contacting the store.";
        //    if (resp.customer.CustomerID != 0 && resp.customer.IsMailSent == 0)
        //    {
        //        if (resp.customer.Email != "" && resp.customer.Email != null)
        //            resp.ErrorDescription = "Hi " + resp.customer.FirstName + " " + resp.customer.LastName + ", \nWe are sending a verification email to " + resp.customer.Email + " . To proceed press continue. To change your emailAddress click on Update.";
        //        else
        //            resp.ErrorDescription = "Hi " + resp.customer.FirstName + resp.customer.LastName + ", \nIt seems we do not have your email address! Please update it so we can send you a verification link that will activate your account.";
        //        string activationCode = Guid.NewGuid().ToString();
        //        response = itemService.InsertActivationCode(activationCode, resp.customer.Email);
        //        if (response != null && response != "")
        //        {
        //            resp.customer.IsMailSent = 1;
        //            SendEmail se = new SendEmail();
        //            var result = se.SendOneEmail(response, resp.customer.Email, resp.customer.FirstName);
        //            //if (resp.customer.Email == "mohana.indukuri@gmail.com")
        //            //{
        //            SMSCAPI sms = new SMSCAPI();
        //            sms.SendSMS("savvyitsolutions", "71900446", "1" + resp.customer.PhoneNumber, "https://hangoutz.azurewebsites.net/VerificationPage.html?ActivationCode=" + response + " Click here to activate your winehangouts account");
        //            //}
        //        }
        //        else
        //            resp.customer.IsMailSent = 0;
        //    }
        //    DateTime end = DateTime.Now;
        //    TimeSpan tm = end - start;
        //    Trace.TraceInformation("Time taken to AuthenticateUser =" + tm);
        //    return resp;
        //}



        //[Authorize]
        //[HttpGet]
        //public GetDrugNameResponse GetCartItems(string objectId)
        //{
        //    GetDrugNameResponse resp = new GetDrugNameResponse();
        //    IRxOutletService itemService = new RxOutletService();
        //    resp = itemService.GetCartItems(objectId);
        //    return resp;
        //}

        [HttpGet]
        public GetDrugNameResponse GetProductDetails(int objectId)
        {
            GetDrugNameResponse resp = new GetDrugNameResponse();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetProductDetails(objectId);
            return resp;
        }

        [HttpGet]
        public GetDrugNameResponse GetDrugTypes()
        {

            GetDrugNameResponse resp = new GetDrugNameResponse();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetDrugTypes();
            return resp;
        }


        [HttpGet]
        public GetDrugNameResponse GetSupplierName()
        {

            GetDrugNameResponse resp = new GetDrugNameResponse();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetSupplierName();
            return resp;
        }


        [HttpGet]
        public GetDrugNameResponse DrugList()
        {

            GetDrugNameResponse resp = new GetDrugNameResponse();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetDrugList();
            return resp;
        }

        [HttpGet]
        public GetDrugNameResponse DrugListNew(SearchCreiteria sc)
        {

            GetDrugNameResponse resp = new GetDrugNameResponse();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetDrugList();
            return resp;
        }

        public class SearchCreiteria
        {
            public string SearchText { get; set; }
            List<int> Type;
            int PageStart;
            int PageSize;
            public SearchCreiteria()
            {
                Type = new List<int>();
            }
        }
        //[HttpGet]
        //public RxOutletMenuListRespone MenuList()
        //{

        //    RxOutletMenuListRespone resp = new RxOutletMenuListRespone();
        //    IRxOutletService itemService = new RxOutletService();
        //     resp = itemService.GetMenuList();
        //    return resp;
        //}


        //[HttpGet]
        //public RxOutletSubMenuListResponse SubMenuList(int objectId)
        //{
        //    RxOutletSubMenuListResponse resp = new RxOutletSubMenuListResponse();
        //    IRxOutletService itemService = new RxOutletService();
        //    resp = itemService.GetSubMenuList(objectId);
        //    return resp;

        //}


        //[HttpGet]
        //public RxOutLetMenuItemListResponse MenuItemList(int objectId, int userid)
        //{
        //    RxOutLetMenuItemListResponse resp = new RxOutLetMenuItemListResponse();
        //    IRxOutletService itemService = new RxOutletService();
        //    resp = itemService.GetMenuItemList(objectId, userid);

        //    return resp;

        //}





        [HttpGet]
        public List<CompleteMenu> GetCompleteMenu()
        {
            List<CompleteMenu> resp = new List<CompleteMenu>();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetCompleteMenu();

            return resp;
        }


        [HttpGet]
        public List<DrugSearch> GetDrugNamesSearch()
        {
            List<DrugSearch> resp = new List<DrugSearch>();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetDrugNamesSearchService();

            return resp;
        }



    }
}
