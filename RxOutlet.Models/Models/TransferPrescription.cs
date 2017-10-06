using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
   public class TransferPrescription
    {
        public string TransferPrescriptionID { get; set; }

        public string PharmacyName { get; set; }
        public string PharmacyNumaber { get; set; }
        public string PharmacyFax { get; set; }
        public string MedicationFor { get; set; }
        public string RxNumber { get; set; }
        public string UserID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public TransferPrescription()
        { }
        public TransferPrescription(string email, string name, string transferPrescriptionID)
        {
            Email = email;
            Name = name;
            TransferPrescriptionID = transferPrescriptionID;
        }
    }
}
