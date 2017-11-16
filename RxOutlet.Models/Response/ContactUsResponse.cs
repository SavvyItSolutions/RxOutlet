using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
  public  class ContactUsResponse:BaseServiceResponse
    {

        public ContactUs contactUs { get; set; }

        public ContactUsResponse(int errorCode, string errorDesc, ContactUs cu)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDesc;
            contactUs = cu;
        }


    }
}
