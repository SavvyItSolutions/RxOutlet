using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using RxOutlet.DataAccess.Interfaces;
using System.Configuration;
using RxOutlet.Models;
using System.Security.Claims;
using System.Web;
using System.IO;

namespace RxOutlet.DataAccess.DataManager
{
    public class MenuDBManager : IMenuDBManger
    {
        public RxOutletDataContext DBContext;
        public RxOutletDataContext DBContextRxOutlet;

        public string path { get; set; }

        public string imageFullPath;

       
        public MenuDBManager()
        {
            try
            {
                string connection = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                DBContext = new DataAccess.RxOutletDataContext(connection);
            }
            catch (Exception ex)
            {

            }
        }


        public ISingleResult<ContactUSInfoResult> ContactUs(ContactUs contactUs)
        {
            contactUs.ContactUsID = Guid.NewGuid().ToString();

            try
            {
                ISingleResult<ContactUSInfoResult> result = DBContext.ContactUSInfo(
                   contactUs.ContactUsID,
                    contactUs.SubjectHeadingID,
                      contactUs.Email,
                    contactUs.OrderReference,
                     contactUs.Message    
                    );
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


      


        public ISingleResult<GetSignupDetailsResult> GetSingupDetails(string userid)
        {
            try
            {
                ISingleResult<GetSignupDetailsResult> result =
                DBContext.GetSignupDetails(userid);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        public IList<GetStatesResult> GetStates()
        {
            try
            {
                ISingleResult<GetStatesResult> result =
                DBContext.GetStates();

                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public IList<GetSubjectHeadingResult> GetContactUsSubjectHeading()
        {
            try
            {
                ISingleResult<GetSubjectHeadingResult> result =
                DBContext.GetSubjectHeading();

                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<GetSingUpSecurityQuestionsResult> SecurityQuestions()
        {
            try
            {
                ISingleResult<GetSingUpSecurityQuestionsResult> result =
                DBContext.GetSingUpSecurityQuestions();

                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ISingleResult<CheckDLResult> CheckDL(string userid)
        {
            try
            {
                ISingleResult<CheckDLResult> result =
                DBContext.CheckDL(userid);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ISingleResult<ConditionBasedResult> LocateCustomer(ConditionBased conditionBased)
        {
            try
            {
                ISingleResult<ConditionBasedResult> result = DBContext.ConditionBased(
                    conditionBased.UserID,
                    conditionBased.RXNumber,
                    conditionBased.StoreNumber
                    );
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public ISingleResult<PateintRegistrationResult> PatientRegistration(PateintRegistration patientRegistration)
        {
            patientRegistration.PateintRegistrationID = Guid.NewGuid().ToString();

            try
            {
                ISingleResult<PateintRegistrationResult> result = DBContext.PateintRegistration(
                    patientRegistration.PateintRegistrationID,
                    patientRegistration.FirstName,
                    patientRegistration.LastName,
                    patientRegistration.MI,
                    patientRegistration.Address,
                    patientRegistration.city,
                    patientRegistration.PostalCode,
                    Convert.ToInt16(patientRegistration.State),
                    patientRegistration.Gender,
                    Convert.ToDateTime(patientRegistration.DOB),
                    patientRegistration.PhoneNumber,
                    patientRegistration.UserId,

                    patientRegistration.PateintInsuranceID,
                    patientRegistration.Medicare,
                    patientRegistration.MedicareID,
                    patientRegistration.PrescriptionInsuranceCompany,
                    patientRegistration.InsurancePhoneNumber,
                    patientRegistration.BIN,
                    patientRegistration.PCN,
                    patientRegistration.ID,
                    patientRegistration.GroupNum,
                    patientRegistration.AdditionalInfomartion,
                    patientRegistration.InsuranceImagePath

                    );
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public ISingleResult<TransferPrescriptionResult> TransferPrescription(TransferPrescription transferPrescription)
        {
            transferPrescription.TransferPrescriptionID = Guid.NewGuid().ToString();

            try
            {
                ISingleResult<TransferPrescriptionResult> result = DBContext.TransferPrescription(
                   transferPrescription.TransferPrescriptionID,
                    transferPrescription.PharmacyName,
                    transferPrescription.PharmacyNumaber,
                    transferPrescription.PharmacyFax,
                    transferPrescription.MedicationFor,
                    transferPrescription.RxNumber,
                    transferPrescription.UserID
                    );
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


       
        public ISingleResult<UploadingPrescriptionNewResult> UploadingPrescriptionNew(UploadPrescription uploadPrescription)
        {
            uploadPrescription.TransactionID = Guid.NewGuid().ToString();
            try
            {
                ISingleResult<UploadingPrescriptionNewResult> result = DBContext.UploadingPrescriptionNew(
                     uploadPrescription.TransactionID,
                     uploadPrescription.Filepath,
                     uploadPrescription.UserID,
                     uploadPrescription.PhysicianName,
                     uploadPrescription.PhysicianNumber,
                     uploadPrescription.MedicationFor
                    );

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //public  int UploadingPrescription(UploadPrescriptionModel uploadPrescription)
        //{
        //    try
        //    {
        //        int result = DBContext.PrescriptionsUpload(
        //           uploadPrescription.Title,
        //            uploadPrescription.Description,
        //            uploadPrescription.Filepath ,
        //            uploadPrescription.UserID   
        //                                                );
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}


       

        //public IList<ConfirmationEmailResult> ConfirmationEmail(string UserID)
        //{
        //    try
        //    {
        //        ISingleResult<ConfirmationEmailResult> result =
        //        DBContext.ConfirmationEmail(UserID);
        //        return result.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public IList<PrescriptionListResult> GetPrescriptionList()
        //{
        //    try
        //    {
        //        ISingleResult<PrescriptionListResult> result =
        //        DBContext.GetPrescriptionList();
        //        return result.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        public IList<GetPrescriptionListResult> GetPrescriptionList()
        {
            try
            {
                ISingleResult<GetPrescriptionListResult> result =
                DBContext.GetPrescriptionList();
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<GetUserPrescriptionListResult> GetUserPrescriptionList(string UserID)
        {
            try
            {
                ISingleResult<GetUserPrescriptionListResult> result =
                DBContext.GetUserPrescriptionList(UserID);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //public IList<GetCartItemsResult> GetCartItems(string UserName)
        //{
        //    try
        //    {
        //        ISingleResult<GetCartItemsResult> result =
        //        DBContext.GetCartItems(UserName);
        //        return result.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        public IList<GetProductDetailsResult> GetProductDetails(int id)
        {
            try
            {
                ISingleResult<GetProductDetailsResult> result =
                DBContext.GetProductDetails(id);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public IList<GetDrugTypesResult> GetDrugTypes(int pagesize,int pagenumber)
        {
            try
            {
                ISingleResult<GetDrugTypesResult> result =
                DBContext.GetDrugTypes(pagesize, pagenumber);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<GetSupplierNameResult> GetSupplierName()
        {
            try
            {
                ISingleResult<GetSupplierNameResult> result =
                DBContext.GetSupplierName();
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public IList<GetDrugListResult> GetDrugList()
        {
            try
            {
                ISingleResult<GetDrugListResult> result =
                DBContext.GetDrugList();
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        //public IList<GetMenuListResult> GetMenuList()
        //{
        //    try
        //    {
        //        ISingleResult<GetMenuListResult> result =
        //        DBContext.GetMenuList();
        //        return result.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}



        //public IList<GetSubMenuListResult> GetSubMenuList(int menuID)
        //{
        //    try
        //    {
        //        ISingleResult<GetSubMenuListResult> result =
        //        DBContext.GetSubMenuList(menuID);
        //        return result.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        //public IList<GetMenuItemListResult> GetMenuItemList(int menuID, int subMenuID)
        //{
        //    try
        //    {
        //        ISingleResult<GetMenuItemListResult> result =
        //        DBContext.GetMenuItemList(menuID, subMenuID);
        //        return result.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}




        //public IList<GetMenuResult> GetCompleteMenuList()
        //{
        //    try
        //    {
        //        ISingleResult<GetMenuResult> result =
        //        DBContext.GetMenu();
        //        return result.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        public IList<GetMenuResult> GetCompleteMenu()
        {
            ISingleResult<GetMenuResult> result = DBContext.GetMenu();
            return result.ToList();
        }




        public IList<GetDrugNamesSearchResult> GetDrugNamesSearch()
        {
            ISingleResult<GetDrugNamesSearchResult> result = DBContext.GetDrugNamesSearch();
            return result.ToList();
        }

        public IList<InsertActivationCodeResult> InsertActivationCode(string ActivationCode, string Email)
        {            
            try
            {
                ISingleResult<InsertActivationCodeResult> result = DBContext.InsertActivationCode(ActivationCode, Email);
                return result.ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public int UpdateVerificationMail(string ActivationCode)
        {
            try
            {
                int result = DBContext.UpdateVerificationMail(ActivationCode);
                return result;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

     





    }




}


