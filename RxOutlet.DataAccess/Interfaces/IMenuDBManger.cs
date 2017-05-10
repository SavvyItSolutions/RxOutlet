using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RxOutlet.Models;

namespace RxOutlet.DataAccess.Interfaces
{
    
        public interface IMenuDBManger
        {

            IList<GetMenuListResult> GetMenuList();
            IList<GetSubMenuListResult> GetSubMenuList(int menuID);
            IList<GetMenuItemListResult> GetMenuItemList(int menuID, int subMenuID);
           // IList<GetMenuResult> GetCompleteMenuList();


        IList<GetMenuResult> GetCompleteMenu();

        //   MenuDetailsResponse GetCompleteMenuList();

        // void GetCompleteMenuList();

        // IList<GetMenuDetailsResult> menudetails();

    }

}
