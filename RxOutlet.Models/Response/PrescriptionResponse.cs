using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
   public class PrescriptionResponse
    {
        public IList<UploadPrescriptionModel> GetUserPrescriptionList { get; set; }
        public IList<UploadPrescriptionModel> GetPrescriptionList { get; set; }
    }
}
