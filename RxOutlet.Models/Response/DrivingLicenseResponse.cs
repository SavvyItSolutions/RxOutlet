using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
    public class DrivingLicenseResponse: BaseServiceResponse
    {
        public DrivingLicense DrivingLicense { get; set; }

        public DrivingLicenseResponse(int errorCode, string errorDesc, DrivingLicense dl)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDesc;
            DrivingLicense = dl;
        }
    }
}
