using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
 public  class PatientRegistrationResponse:BaseServiceResponse
    {
        public PateintRegistration PatientRegistration { get; set; }

        public PatientRegistrationResponse(int errorCode, string errorDesc, PateintRegistration rp)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDesc;
            PatientRegistration = rp;
        }
    }
}
