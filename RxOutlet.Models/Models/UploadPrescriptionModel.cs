
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



      
        
    }
   
}
