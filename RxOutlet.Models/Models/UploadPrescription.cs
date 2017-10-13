using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
  public  class UploadPrescription
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

        public UploadPrescription()
        { }
        public UploadPrescription(string email, string name, string transactionID)
        {
            Email = email;
            Name = name;
            TransactionID = transactionID;
        }


    }
}
