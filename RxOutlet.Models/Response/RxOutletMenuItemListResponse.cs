using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
  public  class RxOutLetMenuItemListResponse:BaseServiceResponse
    {
        public IList<Menu> MenuItemList { get; set; }
    }
}
