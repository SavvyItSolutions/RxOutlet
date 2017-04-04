using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
 public class RxOutlet_MenuListRespone : BaseServiceResponse
    {
        public IList<E_Menu> MenuList { get; set; }
    }
}



