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
using System.Web.Security;
using System.Security.Claims;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace RxOutlet.Controllers
{
    public class RxOutletController : ApiController
    {
      
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


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


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
        public int UploadingPrescriptionNew(UploadPrescriptionModel uploadPrescription)
        {
            int resp = 0;
            List<UploadPrescriptionModel> LstPrescriptionModel = new List<UploadPrescriptionModel>();
            IRxOutletService rxService = new RxOutletService();

            LstPrescriptionModel =  rxService.UploadingPrescriptionNew(uploadPrescription);
            if(LstPrescriptionModel.Count > 0)
            {
                resp = 1;
                SendEmail se = new SendEmail();
                se.SendOneEmail(LstPrescriptionModel[0].Email,LstPrescriptionModel[0].Name,LstPrescriptionModel[0].TransactionPrescriptionID);
            }
            return resp;
        }

      

        [HttpPost]
        public int ByteArray(ByteArrayModel byt)
        {
            byte[] array = byt.array; string userid = byt.userid;
            string FileExtension = byt.FileExtension;

            int resp = 0;
            List<UploadPrescriptionModel> LstPrescriptionModel = new List<UploadPrescriptionModel>();
            IRxOutletService rxService = new RxOutletService();
            string imageFullPath = null;
            try
            {
                CloudStorageAccount cloudStorageAccount = ConnectionString.GetConnectionString();
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("rxoutlet");

                if (cloudBlobContainer.CreateIfNotExists())
                {
                    cloudBlobContainer.SetPermissionsAsync(
                       new BlobContainerPermissions
                       {
                           PublicAccess = BlobContainerPublicAccessType.Blob
                       }
                       );
                }
                string imageName = Guid.NewGuid().ToString() + "-" + FileExtension;

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
                // cloudBlockBlob.Properties.ContentType = .ContentType;
                cloudBlockBlob.UploadFromByteArray(array, 0, 1);


                imageFullPath = cloudBlockBlob.Uri.ToString();
            }
            catch (Exception ex)
            {

            }
            UploadPrescriptionModel objuploadPrescription = new UploadPrescriptionModel();
            objuploadPrescription.Filepath = imageFullPath;
            LstPrescriptionModel = rxService.UploadingPrescriptionNew(objuploadPrescription);
            if (LstPrescriptionModel.Count > 0)
            {
                resp = 1;
                SendEmail se = new SendEmail();
                se.SendOneEmail(LstPrescriptionModel[0].Email, LstPrescriptionModel[0].Name, LstPrescriptionModel[0].TransactionPrescriptionID);
            }
            return resp;

        }

        [HttpPost]
        public int ByteArray(byte[] array, string userid,string FileExtension)
        {
            int resp = 0;
            List<UploadPrescriptionModel> LstPrescriptionModel = new List<UploadPrescriptionModel>();
            IRxOutletService rxService = new RxOutletService();
            string imageFullPath = null;
            try
            {
                CloudStorageAccount cloudStorageAccount = ConnectionString.GetConnectionString();
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("rxoutlet");

                if (cloudBlobContainer.CreateIfNotExists())
                {
                    cloudBlobContainer.SetPermissionsAsync(
                       new BlobContainerPermissions
                       {
                           PublicAccess = BlobContainerPublicAccessType.Blob
                       }
                       );
                }
                string imageName = Guid.NewGuid().ToString() + "-" + FileExtension;

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
               // cloudBlockBlob.Properties.ContentType = .ContentType;
                cloudBlockBlob.UploadFromByteArray(array,0,1);


                imageFullPath = cloudBlockBlob.Uri.ToString();
            }
            catch (Exception ex)
            {

            }
            UploadPrescriptionModel objuploadPrescription = new UploadPrescriptionModel();
            objuploadPrescription.Filepath = imageFullPath;
            LstPrescriptionModel = rxService.UploadingPrescriptionNew(objuploadPrescription);
            if (LstPrescriptionModel.Count > 0)
            {
                resp = 1;
                SendEmail se = new SendEmail();
                se.SendOneEmail(LstPrescriptionModel[0].Email, LstPrescriptionModel[0].Name, LstPrescriptionModel[0].TransactionPrescriptionID);
            }
            return resp;
            //return imageFullPath;
        
            
        }

        [HttpPost]
        public int UploadingPrescription(UploadPrescriptionModel uploadPrescription)
        {

            IRxOutletService rxService = new RxOutletService();
            SendEmail obj = new SendEmail();
            obj.SendOneEmail("soujanyareddy.gade@gmail.com");
            return rxService.UploadingPrescription(uploadPrescription);

        }


        [HttpPost]
        public async Task<RegistrationResponseModel> SignUp(RegistrationModel model)
        {
            RegistrationResponseModel respModel;
            try
            {
                IRxOutletService RxOutletSvc = new RxOutletService();
                var user = new ApplicationUser { Name = model.Name, UserName = model.Email, Email = model.Email, PhoneNumber = model.MobileNum };
                var result = await System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().CreateAsync(user, model.Password);
                respModel = new RegistrationResponseModel(result.Succeeded, result.Errors.ToList());
                if(result.Succeeded == true)
                {
                    string activationCode = Guid.NewGuid().ToString();
                    string InsertResult = RxOutletSvc.InsertActivationCode(activationCode, model.Email);
                    if(InsertResult != string.Empty)
                    {
                        SendEmail se = new SendEmail();
                        var EmailResult = se.SendOneEmail(activationCode, model.Email, model.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                var x = new List<string>();
                x.Add(ex.Message);
                respModel = new RegistrationResponseModel(false, x);
            }
            return respModel;
        }


        [HttpPost]
        public async Task<LoginResponse> Login(LoginModel model)
        {

            LoginResponse retObj = null;
            try
            {
                string email = model.Email;
                string name = User.Identity.Name;
                var result = SignInStatus.Failure;
                result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: true);
                if (result == SignInStatus.Success)
                {
                    var userid = await UserManager.FindByNameAsync(model.Email);
                    retObj = new LoginResponse(userid.EmailConfirmed, userid.Id, true, "");
                    // retObj = 1;
                }
                else
                {
                    retObj = new LoginResponse(false, "", false, "Login Failed");
                }
            }
            catch (Exception ex)
            {
                retObj = new LoginResponse(false, "", false, ex.Message);
            }
            return retObj;
        }

      
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

        [HttpGet]
        public int UpdateVerifiedEmail(string objectId)
        {
            IRxOutletService RxOutletSvc = new RxOutletService();
            int resp = RxOutletSvc.UpdateVerificationEmail(objectId);            
            return resp;
        }

    }
}
