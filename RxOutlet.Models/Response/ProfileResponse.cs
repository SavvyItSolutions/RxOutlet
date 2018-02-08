using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
   public class ProfileResponse:BaseServiceResponse
    {
        public Profile Profile { get; set; }

        public ProfileResponse(int errorCode, string errorDesc, Profile p)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDesc;
            Profile = p;
        }
    }
}
