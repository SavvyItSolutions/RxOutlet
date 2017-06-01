using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
  public  class GetDrugNameResponse : BaseServiceResponse
    {
       
            public IList<GetDrugList> DrugList { get; set; }
        
    }
}

