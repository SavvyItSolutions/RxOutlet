using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RxOutlet.Models;
using System.Data.Linq;

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
        ISingleResult< UploadingPrescriptionNewResult> UploadingPrescriptionNew(UploadPrescription uploadPrescription);
        ISingleResult<TransferPrescriptionResult> TransferPrescription(TransferPrescription transferPrescription);
        // ISingleResult<TransferPrescriptionResult>  TransferPrescriptionNew(TransferPrescriptionModel transferPrescription);
        ISingleResult<CheckDLResult> CheckDL(string userid);
        IList<GetSingUpSecurityQuestionsResult> SecurityQuestions();
    }

}
