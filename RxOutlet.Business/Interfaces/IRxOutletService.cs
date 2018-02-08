using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RxOutlet.Models;
using RxOutlet.DataAccess;

namespace RxOutlet.Business
{
    public interface IRxOutletService

    {
        //RxOutletMenuListRespone GetMenuList();
        //RxOutletSubMenuListResponse GetSubMenuList(int menuID);
        //RxOutLetMenuItemListResponse GetMenuItemList(int menuID, int subMenuID);     
        List<CompleteMenu> GetCompleteMenu();
        GetDrugNameResponse GetDrugList();
        GetDrugNameResponse GetSupplierName();
        List<DrugSearch> GetDrugNamesSearchService();
        GetDrugTypeResponse GetDrugTypes(int pagesize,int pagenumber);
        GetDrugNameResponse GetProductDetails(int id);
        //  GetDrugNameResponse GetCartItems(string UserName);

        //    int UploadingPrescription(UploadPrescriptionModel uploadingPrescription);


        PrescriptionResponse GetUserPrescriptionList(string UserID);
        PrescriptionResponse GetPrescriptionList();
        // ConfirmationEmailResponse ConfirmationMail(string UserID);
        string InsertActivationCode(string ActivationCode, string Email);
        int UpdateVerificationEmail(string ActivationCode);

        PatientRegistrationResponse PatientRegistration(PateintRegistration patientRegistration);

        UploadPrescriptionResponse UploadingPrescriptionNew(UploadPrescription uploadingPrescription);
        TransferPrescriptionResponse TransferPrescription(TransferPrescription transferPrescription);
        DrivingLicenseResponse CheckDL(string userid);
        List<RegistrationModel> GetSecurityQuestions();
        List<ContactUs> GetContactUsSubjectHeading();
        List<PateintRegistration> GetStates();
        ContactUsResponse ContactUs(ContactUs contactUs);
     //   ProfileResponse GetSignupDetails(string userid);
        ConditionBasedResponse LocateCustomer(ConditionBased conditionBased);

    }
}
