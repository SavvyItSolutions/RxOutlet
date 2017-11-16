using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
   public class PateintRegistrationResponse:BaseServiceResponse
    {
        public PateintRegistration pateintRegistration { get; set; }

        public PateintRegistrationResponse(int errorCode, string errorDesc, PateintRegistration pr)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDesc;
            pateintRegistration = pr;
        }

    }
}
