using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
  public  class MenuDetailsResponse:BaseServiceResponse
    {
        //public IList<MainMenu> MenuList { get; set; }
        //public IList<SubMenu> subMenuList { get; set; }
        //public IList<MenuItem> MenuitemList { get; set; }

        public IList<CompleteMenu> CompleteMenu { get; set; }

    }
}
