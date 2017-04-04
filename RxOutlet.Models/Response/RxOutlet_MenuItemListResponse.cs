using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
  public  class RxOutLet_MenuItemListResponse:BaseServiceResponse
    {
        public IList<E_Menu> MenuItemList { get; set; }
    }
}
