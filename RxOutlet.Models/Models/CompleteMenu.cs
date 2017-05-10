using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
   public class CompleteMenu
    {
        public int MainMenuID { get; set; }
        public string MainMenuName { get; set; }
        public List<SubMenu> SubMenuList { get; set; }
    }
}
