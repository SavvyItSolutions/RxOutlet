using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RxOutlet.DataAccess;
using RxOutlet.DataAccess.Interfaces;
using RxOutlet.Models;

namespace RxOutlet.Business.Services
{
   public class RxOutletService : IRxOutletService
    {
        public RxOutlet_MenuListRespone GetMenuList()
        {
            RxOutlet_MenuListRespone menuListResponse = new RxOutlet_MenuListRespone();
            List<E_Menu> itemList = new List<E_Menu>();

            IMenuDBManger menuDBManager = new MenuDBManager();
            IList<sp_Elixir_GetMenuListResult> MainMenuResults = menuDBManager.GetMenuList();

            foreach (sp_Elixir_GetMenuListResult result in MainMenuResults)
            {
                itemList.Add(new E_Menu
                {
                    MenuName = result.MenuName
                });
            }
            menuListResponse.MenuList = itemList;
            return menuListResponse;
        }




        public RxOutlet_SubMenuListResponse GetSubMenuList(int menuID)
        {
            RxOutlet_SubMenuListResponse subMenuListResponse = new RxOutlet_SubMenuListResponse();
            List<RxOutlet.Models.E_Menu> itemList = new List<RxOutlet.Models.E_Menu>();

            IMenuDBManger menuDBManager = new MenuDBManager();
            IList<sp_Elixir_GetSubMenuListResult> SubMenuResults = menuDBManager.GetSubMenuList(menuID).ToList();

            foreach (sp_Elixir_GetSubMenuListResult result in SubMenuResults)
            {
                itemList.Add(new RxOutlet.Models.E_Menu
                {
                    MenuName = result.MenuName,
                    SubMenuName = result.SubMenuName
                });
            }
            subMenuListResponse.SubMenuList = itemList;
            return subMenuListResponse;
        }



        public RxOutLet_MenuItemListResponse GetMenuItemList(int menuID, int subMenuID)
        {
            RxOutLet_MenuItemListResponse menuItemListResponse = new RxOutLet_MenuItemListResponse();
            List<RxOutlet.Models.E_Menu> itemList = new List<RxOutlet.Models.E_Menu>();

            IMenuDBManger menuDBManager1 = new MenuDBManager();
            IList<sp_Elixir_GetMenuItemListResult> MenuitemListResults = menuDBManager1.GetMenuItemList(menuID, subMenuID).ToList();

            foreach (sp_Elixir_GetMenuItemListResult result in MenuitemListResults)
            {
                itemList.Add(new RxOutlet.Models.E_Menu
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
