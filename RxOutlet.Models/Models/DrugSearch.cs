using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
   public class DrugSearch
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public List<DrugNames> DrugNamesList { get; set; }
       
    }
}
