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
using System.Web.Http.Cors;

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



        [HttpPost]
        public ContactUsResponse ContactUs(ContactUs contactUs)
        {

            ContactUsResponse objcontactUs = new ContactUsResponse(2, "Default", null);
            try
            {
                IRxOutletService rxService = new RxOutletService();
                objcontactUs = rxService.ContactUs(contactUs);
            }
            catch (Exception ex)
            {
                objcontactUs = new ContactUsResponse(3, ex.Message, null);

            }


            return objcontactUs;
        }



        [HttpGet]
        public List<PateintRegistration> GetStates()
        {

            PatientRegistrationResponse resp = new PatientRegistrationResponse(2, "Default", null);

            List<PateintRegistration> respModel = new List<PateintRegistration>();
            try
            {
                IRxOutletService rxoutletService = new RxOutletService();
                respModel = rxoutletService.GetStates();
            }
            catch (Exception ex) { resp = new PatientRegistrationResponse(3, ex.Message, null); }
            return respModel;

        }



        [HttpGet]
        public List<ContactUs> GetContactUsSubjectHeading()
        {

            ContactUsResponse resp = new ContactUsResponse(2, "Default", null);

            List<ContactUs> respModel = new List<ContactUs>();
            try
            {
                IRxOutletService rxoutletService = new RxOutletService();
                respModel = rxoutletService.GetContactUsSubjectHeading();
            }
            catch (Exception ex) { resp = new ContactUsResponse(3, ex.Message, null); }
            return respModel;

        }




        [HttpGet]
        public List<RegistrationModel> GetSignUpSecurityQuestions()
        {

        RegistrationResponseModel resp = new RegistrationResponseModel(2,"Default",null);

            List<RegistrationModel> respModel = new List<RegistrationModel>();
            try
            {
                IRxOutletService rxoutletService = new RxOutletService();
                respModel = rxoutletService.GetSecurityQuestions();
            }
            catch (Exception ex) { resp = new RegistrationResponseModel(3, ex.Message, null); }
            return respModel;

        }

        [HttpGet]
   
        public PrescriptionResponse GetPrescriptionList()
        {          
            PrescriptionResponse resp = new PrescriptionResponse();
            try
            {
                IRxOutletService rxoutletService = new RxOutletService();
                resp = rxoutletService.GetPrescriptionList();
            }
            catch(Exception ex) { }
            return resp;
        }



        [HttpGet]
        public PrescriptionResponse GetUserPrescriptionList(string objectId)
        {
            PrescriptionResponse resp = new PrescriptionResponse();
            try
            {
                IRxOutletService rxoutletService = new RxOutletService();
                resp = rxoutletService.GetUserPrescriptionList(objectId);
            }
            catch(Exception ex) { }
            return resp;
        }



        [HttpPost]
        public PatientRegistrationResponse PatientRegistration(PateintRegistration patientRegistration)
        {
            PatientRegistrationResponse objPrescriptionModel = new PatientRegistrationResponse(2, "Default", null);
            try
            {
                IRxOutletService rxService = new RxOutletService();
                objPrescriptionModel = rxService.PatientRegistration(patientRegistration);
            }
            catch (Exception ex)
            {
                // objPrescriptionModel = new TransferPrescriptionResponse(3, ex.Message, new TransferPrescription());
                objPrescriptionModel = new PatientRegistrationResponse(3, ex.Message, null);

            }
            return objPrescriptionModel;
        }



        [HttpPost]
        public TransferPrescriptionResponse TransferPrescription(TransferPrescription transferPrescription)
        {

            TransferPrescriptionResponse objPrescriptionModel = new TransferPrescriptionResponse(2, "Default", null);
            try
            {           
                IRxOutletService rxService = new RxOutletService();
                objPrescriptionModel = rxService.TransferPrescription(transferPrescription);          
            }
            catch (Exception ex) {
                // objPrescriptionModel = new TransferPrescriptionResponse(3, ex.Message, new TransferPrescription());
                objPrescriptionModel = new TransferPrescriptionResponse(3, ex.Message, null);

            }


            return objPrescriptionModel;
        }


        [HttpGet]
        public DrivingLicenseResponse CheckDL(string objectId)
        {

            DrivingLicenseResponse objPrescriptionModel = new DrivingLicenseResponse(2, "Default", null);
            try
            {
                IRxOutletService rxService = new RxOutletService();
                objPrescriptionModel = rxService.CheckDL(objectId);
            }
            catch (Exception ex)
            {
                // objPrescriptionModel = new TransferPrescriptionResponse(3, ex.Message, new TransferPrescription());
                objPrescriptionModel = new DrivingLicenseResponse(3, ex.Message, null);

            }


            return objPrescriptionModel;
        }


        [HttpPost]
        public UploadPrescriptionResponse UploadingPrescriptionNew(UploadPrescription uploadPrescription)
        {
            UploadPrescriptionResponse objPrescriptionModel = new UploadPrescriptionResponse(2,"Default", null);

            try
            {
                IRxOutletService rxService = new RxOutletService();
                objPrescriptionModel = rxService.UploadingPrescriptionNew(uploadPrescription);
            }
            catch(Exception ex) {
                objPrescriptionModel = new UploadPrescriptionResponse(3, ex.Message, null);

            }

            return objPrescriptionModel;

        }

      

        [HttpPost]
        public int ByteArray(ByteArrayModel byt)
        {
            byte[] array = byt.array;
           // string userid = "bdab1060-9dcd-47ce-a9c5-3eb305e29e91";
            string FileExtension = byt.FileExtension;

            int resp = 0;
            UploadPrescriptionModel objPrescriptionModel = new UploadPrescriptionModel();
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
                cloudBlockBlob.Properties.ContentType = "image/jpg";
                cloudBlockBlob.UploadFromByteArray(array, 0, array.Length);


                imageFullPath = cloudBlockBlob.Uri.ToString();
            }
            catch (Exception ex)
            {

            }
            UploadPrescriptionModel objuploadPrescription = new UploadPrescriptionModel();
            objuploadPrescription.Filepath = imageFullPath;
            objuploadPrescription.UserID = "bdab1060-9dcd-47ce-a9c5-3eb305e29e91";

          ///  objPrescriptionModel = rxService.UploadingPrescriptionNew(objuploadPrescription);
            if (objPrescriptionModel!=null)
            {
                resp = 1;
                SendEmail se = new SendEmail();
                se.SendOneEmail(objPrescriptionModel.Email, objPrescriptionModel.Name, objPrescriptionModel.TransactionID);
            }
            return resp;

        }

        //[HttpPost]
        //public int ByteArray_3(byte[] array, string userid,string FileExtension)
        //{
        //    int resp = 0;
        //    List<UploadPrescriptionModel> LstPrescriptionModel = new List<UploadPrescriptionModel>();
        //    IRxOutletService rxService = new RxOutletService();
        //    string imageFullPath = null;
        //    try
        //    {
        //        CloudStorageAccount cloudStorageAccount = ConnectionString.GetConnectionString();
        //        CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
        //        CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("rxoutlet");

        //        if (cloudBlobContainer.CreateIfNotExists())
        //        {
        //            cloudBlobContainer.SetPermissionsAsync(
        //               new BlobContainerPermissions
        //               {
        //                   PublicAccess = BlobContainerPublicAccessType.Blob
        //               }
        //               );
        //        }
        //        string imageName = Guid.NewGuid().ToString() + "-" + FileExtension;

        //        CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
        //        cloudBlockBlob.Properties.ContentType = "image/jpg"; 
        //        cloudBlockBlob.UploadFromByteArray(array,0,1);


        //        imageFullPath = cloudBlockBlob.Uri.ToString();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    UploadPrescriptionModel objuploadPrescription = new UploadPrescriptionModel();
        //    objuploadPrescription.Filepath = imageFullPath;
        //    LstPrescriptionModel = rxService.UploadingPrescriptionNew(objuploadPrescription);
        //    if (LstPrescriptionModel.Count > 0)
        //    {
        //        resp = 1;
        //        SendEmail se = new SendEmail();
        //        se.SendOneEmail(LstPrescriptionModel[0].Email, LstPrescriptionModel[0].Name, LstPrescriptionModel[0].TransactionID);
        //    }
        //    return resp;
        //    //return imageFullPath;
        
            
        //}

        //[HttpPost]
        //public int ByteArray_Array(byte[] array)
        //{
        //    int resp = 0;
        //    List<UploadPrescriptionModel> LstPrescriptionModel = new List<UploadPrescriptionModel>();
        //    IRxOutletService rxService = new RxOutletService();
        //    string imageFullPath = null;
        //    try
        //    {
        //        CloudStorageAccount cloudStorageAccount = ConnectionString.GetConnectionString();
        //        CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
        //        CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("rxoutlet");

        //        if (cloudBlobContainer.CreateIfNotExists())
        //        {
        //            cloudBlobContainer.SetPermissionsAsync(
        //               new BlobContainerPermissions
        //               {
        //                   PublicAccess = BlobContainerPublicAccessType.Blob
        //               }
        //               );
        //        }
        //        string imageName = Guid.NewGuid().ToString() + "-" +".jpg";

        //        CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
        //        cloudBlockBlob.Properties.ContentType = "image/jpg";
        //        cloudBlockBlob.UploadFromByteArray(array, 0, array.Length);


        //        imageFullPath = cloudBlockBlob.Uri.ToString();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    UploadPrescriptionModel objuploadPrescription = new UploadPrescriptionModel();
        //    objuploadPrescription.Filepath = imageFullPath;
        //    objuploadPrescription.UserID = array.Length.ToString();
        //    LstPrescriptionModel = rxService.UploadingPrescriptionNew(objuploadPrescription);
        //    if (LstPrescriptionModel.Count > 0)
        //    {
        //        resp = 1;
        //        SendEmail se = new SendEmail();
        //        se.SendOneEmail(LstPrescriptionModel[0].Email, LstPrescriptionModel[0].Name, LstPrescriptionModel[0].TransactionID);
        //    }
        //    return resp;
        //    //return imageFullPath;
        //}

        [HttpPost]
        public async Task<RegistrationResponseModel> SignUp(RegistrationModel model)
        {
            RegistrationResponseModel respModel;

            try
            {
               
                IRxOutletService RxOutletSvc = new RxOutletService();
                var user = new ApplicationUser { Name = model.Name, UserName = model.Email, Email = model.Email, PhoneNumber = model.MobileNum ,SecurityQuestionID=model.SecurityQuestionID,SecurityAnswer=model.SecurityAnswer,PrivacyAcceptance=model.PrivacyAcceptance,SplOffersEmail=model.SplOffersEmail,PrescriptionEmail=model.PrescriptionEmail};
                var result = await System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().CreateAsync(user, model.Password);
                respModel = new RegistrationResponseModel(result.Succeeded, result.Errors.ToList());
                if(result.Succeeded == true)
                {
                    string activationCode = Guid.NewGuid().ToString();
                    string InsertResult = RxOutletSvc.InsertActivationCode(activationCode, model.Email);

                    if (InsertResult != string.Empty)
                    {
                        SendEmail se = new SendEmail();
                        //List<string> maildetails = new List<string>();
                        //maildetails.Add(model.Email);
                        //maildetails.Add(model.Name);
                        ////  maildetails.Add(LstPrescriptionModel[0].TransactionID);
                        ////subject
                        //maildetails.Add("Confirmation Mail for Registration");
                        ////Mail HTMLContent
                        //maildetails.Add("<strong> Hello " + model.Name + "!</strong ><br /><br /> We're glad to have you onboard with RxOutlet! Please click the following link to activate your account<br /><a href =" + "http://rxoutlet.azurewebsites.net/Account/VerificationCode?ActivationCode=" + activationCode + ">Click here to activate your account.</a><br /><br />Thanks");
                        ////message
                        //maildetails.Add("RxOutlet Conformation Mail");
                        var EmailResult=   se.SendOneEmail(activationCode,model.Email,model.Name);
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
        public GetDrugTypeResponse GetDrugTypes(int objectId, int userid)
        {

            GetDrugTypeResponse resp = new GetDrugTypeResponse();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetDrugTypes(objectId, userid);

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
            int resp=0;
            IRxOutletService RxOutletSvc = new RxOutletService();
            try
            {
                resp = RxOutletSvc.UpdateVerificationEmail(objectId);
            }
            catch(Exception ex) { }        
            return resp;
        }


        //[HttpGet]
        //public int ConditionBased(string objectId)
        //{
        //    int resp = 0;
        //    IRxOutletService RxOutletSvc = new RxOutletService();
        //    try
        //    {
        //        resp = RxOutletSvc.conditionbased(objectId);
        //    }
        //    catch (Exception ex) { }
        //    return resp;
        //}


    }
}
