
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
   public class SubMenu
    {

        public int SubMainMenuId { get; set; }
        public int SubMenuID { get; set; }
        public string SubMenuName { get; set; }
        public List<MenuItem> menuItemList { get; set; }

    }
}
