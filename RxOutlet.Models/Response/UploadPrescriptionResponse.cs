using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
public class UploadPrescriptionResponse:BaseServiceResponse
    {
        public UploadPrescription UploadPrescription { get; set; }

        public UploadPrescriptionResponse(int errorCode, string errorDesc, UploadPrescription tp)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDesc;
            UploadPrescription = tp;
        }
    }
}
