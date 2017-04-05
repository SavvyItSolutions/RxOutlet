using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.DataAccess.Interfaces
{
    
        public interface IMenuDBManger
        {

            IList<GetMenuListResult> GetMenuList();
            IList<GetSubMenuListResult> GetSubMenuList(int menuID);
            IList<GetMenuItemListResult> GetMenuItemList(int menuID, int subMenuID);

        }
    
}
