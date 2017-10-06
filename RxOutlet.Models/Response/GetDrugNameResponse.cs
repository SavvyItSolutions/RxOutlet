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

    //public class GridResponse 
    //{
    //    public IList<Drug> data { get; set; }
    //    public int totalrows;
    //}
}

