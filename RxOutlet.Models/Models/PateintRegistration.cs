using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
   public class PateintRegistration
    {

        [Required]
        [DataType(DataType.Text)]
        public string UserId { get; set; }

        public string PateintRegistrationID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MI { get; set; }

        public string Address { get; set; }

        public string city { get; set; }

        public string State { get; set; }

        public int StateID { get; set; }

        public string PostalCode { get; set; }

        public string DOB    { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }


     


        public PateintRegistration()
        { }
        public PateintRegistration(string pateintRegistrationID)
        {
        
            pateintRegistrationID = PateintRegistrationID;
        }

        
        public string PateintInsuranceID { get; set; }

        public string Medicare { get; set; }

        public string MedicareID { get; set; }

        public string PrescriptionInsuranceCompany { get; set; }

        public string InsurancePhoneNumber { get; set; }

        public string BIN { get; set; }

        public string PCN { get; set; }

        public string ID { get; set; }

        public string GroupNum { get; set; }

        public string AdditionalInfomartion { get; set; }

        public string InsuranceImagePath { get; set; }


    }
}
