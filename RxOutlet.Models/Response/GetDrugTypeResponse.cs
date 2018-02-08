using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
 public class GetDrugTypeResponse:BaseServiceResponse
    {

        public IList<GetDrugTypes> DrugList { get; set; }
    }
}
