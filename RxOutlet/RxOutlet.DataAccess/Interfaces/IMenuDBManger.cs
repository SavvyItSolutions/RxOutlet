using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.DataAccess.Interfaces
{
    
        public interface IMenuDBManger
        {

            IList<sp_Elixir_GetMenuListResult> GetMenuList();
            IList<sp_Elixir_GetSubMenuListResult> GetSubMenuList(int menuID);
            IList<sp_Elixir_GetMenuItemListResult> GetMenuItemList(int menuID, int subMenuID);

        }
    
}
