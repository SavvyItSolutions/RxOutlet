using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
   public  class RxOutletMenuResponse:BaseServiceResponse
    {


        public IList<RxOutletMenuListRespone> menuList { get; set; }
        public IList<RxOutLetMenuItemListResponse> itemList { get; set; }
        public IList<RxOutletSubMenuListResponse> subMenuList { get; set; }




    }
}
