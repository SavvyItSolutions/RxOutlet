using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
  public  class ContactUs
    {

        public string ContactUsID { get; set; }
        public int? SubjectHeadingID { get; set; }
        public string SubjectHeadingName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        public string OrderReference { get; set; }
        public string Message { get; set; }


        public ContactUs()
        { }
        public ContactUs( string contactUsID,string email)
        {

            ContactUsID = contactUsID;
        }


    }
}
