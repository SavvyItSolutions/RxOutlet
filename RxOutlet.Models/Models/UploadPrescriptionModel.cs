
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RxOutlet.Models
{
   public class UploadPrescriptionModel
    {


        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Filepath { get; set; }
        public string UserID { get; set; }
        public string CreatedDate { get; set; }


        //public string imageFullPath=null;

        //public HttpPostedFileBase ImageUrl { get; set; }


        public string TransactionID { get; set; }
        public string ImageUrl { get; set; }
        public string PhysicianName { get; set; }
        public string PhysicianNumber { get; set; }
        public string MedicationFor { get; set; }




   public DateTime LastFilled { get; set; }
        public string PrescriptionNumber { get; set; }
        public string Medication { get; set; }
        public DateTime RefillDate { get; set; }


    }

}
