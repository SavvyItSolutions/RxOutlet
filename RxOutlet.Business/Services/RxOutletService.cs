using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RxOutlet.DataAccess;
using RxOutlet.DataAccess.Interfaces;
using RxOutlet.DataAccess.DataManager;
using RxOutlet.Models;

namespace RxOutlet.Business
{
   public class RxOutletService: IRxOutletService
    {
        public RxOutletMenuListRespone GetMenuList()
        {
            RxOutletMenuListRespone menuListResponse = new RxOutletMenuListRespone();
            List<Menu> itemList = new List<Menu>();

            IMenuDBManger menuDBManager = new MenuDBManager();
            IList<GetMenuListResult> MainMenuResults = menuDBManager.GetMenuList();

            foreach (GetMenuListResult result in MainMenuResults)
            {
                itemList.Add(new Menu
                {
                    MenuName = result.MenuName
                });



            }
            menuListResponse.MenuList = itemList;
            return menuListResponse;
        }




        public RxOutletSubMenuListResponse GetSubMenuList(int menuID)
        {
            RxOutletSubMenuListResponse subMenuListResponse = new RxOutletSubMenuListResponse();
            List<RxOutlet.Models.Menu> itemList = new List<RxOutlet.Models.Menu>();

            IMenuDBManger menuDBManager = new MenuDBManager();
            IList<GetSubMenuListResult> SubMenuResults = menuDBManager.GetSubMenuList(menuID).ToList();

            foreach (GetSubMenuListResult result in SubMenuResults)
            {
                itemList.Add(new RxOutlet.Models.Menu
                {
                    MenuName = result.MenuName,
                    SubMenuName = result.SubMenuName
                });
            }
            subMenuListResponse.SubMenuList = itemList;
            return subMenuListResponse;
        }



        public RxOutLetMenuItemListResponse GetMenuItemList(int menuID, int subMenuID)
        {
            RxOutLetMenuItemListResponse menuItemListResponse = new RxOutLetMenuItemListResponse();
            List<RxOutlet.Models.Menu> itemList = new List<RxOutlet.Models.Menu>();

            IMenuDBManger menuDBManager1 = new MenuDBManager();
            IList<GetMenuItemListResult> MenuitemListResults = menuDBManager1.GetMenuItemList(menuID, subMenuID).ToList();

            foreach (GetMenuItemListResult result in MenuitemListResults)
            {
                itemList.Add(new RxOutlet.Models.Menu
                {
                    MenuName = result.MenuName,
                    SubMenuName = result.SubMenuName,
                    MenuItemName = result.MenuItemName
                });
            }
            menuItemListResponse.MenuItemList = itemList;
            return menuItemListResponse;
        }

    }
}
