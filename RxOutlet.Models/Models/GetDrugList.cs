using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{

    public class GetDrugList
    {
        public int DrugID { get; set; }
        public string DrugName { get; set; }
        public string RetailPrice { get; set; }
        public string RegularPrice { get; set; }
        public int? SupplierID { get; set; }
        public string SupplierName { get; set; }
        public int? DrugCount { get; set; }
        public int? ImageNum { get; set; }
        public int? DrugTypeID { get; set; }
        public string DrugTypeName { get; set; }

       
    }
}
