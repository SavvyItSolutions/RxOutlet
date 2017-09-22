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
       

            IList<GetMenuResult> GetCompleteMenu();
            IList<GetDrugListResult> GetDrugList();
            IList<GetSupplierNameResult> GetSupplierName();
      IList<GetDrugNamesSearchResult> GetDrugNamesSearch();
        IList<GetDrugTypesResult> GetDrugTypes();
        IList<GetProductDetailsResult> GetProductDetails(int id);  
        IList<GetUserPrescriptionListResult> GetUserPrescriptionList(string UserID);
        IList<PrescriptionListResult> GetPrescriptionList();
        IList<InsertActivationCodeResult> InsertActivationCode(string ActivationCode, string Email);
        int UpdateVerificationMail(string ActivationCode);
       IList< UploadingPrescriptionNewResult> UploadingPrescriptionNew(UploadPrescriptionModel uploadPrescription);
        IList<TransferPrescriptionResult> TransferPrescription(TransferPrescriptionModel transferPrescription);
        IList<CheckingDrivingLicenseResult> CheckDl(string Email);
    }

}
