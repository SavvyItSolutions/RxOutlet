using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
  public  class ConditionBased
    {
        public string UserID { get; set; }
        public string RXNumber { get; set; }
        public string StoreNumber { get; set; }
        public string DOB { get; set; }

        public string CustomerStatus { get; set; }

        public ConditionBased()
        { }
        public ConditionBased( string rxnumber)
        {
            rxnumber = RXNumber;
        }


    }
}
