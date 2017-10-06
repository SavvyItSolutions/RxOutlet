using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
   public class TransferPrescriptionResponse:BaseServiceResponse
    {
        public TransferPrescription TransferPrescription { get; set; }

        public TransferPrescriptionResponse(int errorCode, string errorDesc, TransferPrescription tp)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDesc;
            TransferPrescription = tp;
        }
    }
}
