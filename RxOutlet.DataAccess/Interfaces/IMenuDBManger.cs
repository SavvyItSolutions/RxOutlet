using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RxOutlet.Models;

namespace RxOutlet.DataAccess.Interfaces
{
    
        public interface IMenuDBManger
        {
            //IList<GetMenuListResult> GetMenuList();
            //IList<GetSubMenuListResult> GetSubMenuList(int menuID);
            //IList<GetMenuItemListResult> GetMenuItemList(int menuID, int subMenuID);
            IList<GetMenuResult> GetCompleteMenu();
            IList<GetDrugListResult> GetDrugList();
            IList<GetSupplierNameResult> GetSupplierName();
      IList<GetDrugNamesSearchResult> GetDrugNamesSearch();
        IList<GetDrugTypesResult> GetDrugTypes();
        IList<GetProductDetailsResult> GetProductDetails(int id);
        //   IList<GetCartItemsResult> GetCartItems(string UserName);
        //int Registration(RegistrationModel register);
        int UploadingPrescription(UploadPrescriptionModel uploadPrescription);
        //IList<LoginResult> Login(string email);

        IList<GetUserPrescriptionListResult> GetUserPrescriptionList(string UserID);
        IList<PrescriptionListResult> GetPrescriptionList();
        IList<ConfirmationEmailResult> ConfirmationEmail(string UserID);
        IList<InsertActivationCodeResult> InsertActivationCode(string ActivationCode, string Email);
        int UpdateVerificationMail(string ActivationCode);

        int UploadingPrescriptionNew(UploadPrescriptionModel uploadPrescription);
    }

}
