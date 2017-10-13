using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using RxOutlet.Models;



namespace RxOutlet.Models
{
  public class RegistrationModel
    {
        [Required]
        [DataType(DataType.Text)]     
        public string Name { get; set; }


        [Required]
        [EmailAddress]      
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobileNum { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]    
        public string Password { get; set; }

        [DataType(DataType.Password)]      
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Text)]    
        public string Captcha { get; set; }

     
        public string SecurityQuestions { get; set; }


        [Required]            
        public int SecurityQuestionID { get; set; }


        [Required]
        [DataType(DataType.Text)]     
        public string SecurityAnswer { get; set; }

        [Required]
        public string PrivacyAcceptance { get; set; }

        [Required]
        public string SplOffersEmail { get; set; }

        [Required]
        public string PrescriptionEmail { get; set; }


    }
}
