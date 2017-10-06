using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
  public  class DrivingLicense
    {
        public string DrivingLicenseID { get; set; }

        public DrivingLicense()
        {

        }
        public DrivingLicense( string drivingLicenseID)
        {
            DrivingLicenseID = drivingLicenseID;
        }

    }
}
