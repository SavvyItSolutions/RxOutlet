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

        // LINQ QUERIES FOR MENU 
        // public RxOutletMenuResponse GetCompleteMenuList()
        // {
        //     RxOutletMenuResponse menuResponse = new RxOutletMenuResponse();
        //     List<RxOutlet.Models.Menu> itemList = new List<RxOutlet.Models.Menu>();

        //     IMenuDBManger menuDBManager1 = new MenuDBManager();
        //     IList<GetMenuResult> MenuResults = menuDBManager1.GetCompleteMenuList().ToList();



        //     //foreach (GetMenuResult result in MenuResults)
        //     //{
        //     //    itemList.Add(new RxOutlet.Models.Menu
        //     //    {
        //     //        //        MenuName = result.MenuName,
        //     //        //        SubMenuName = result.SubMenuName,
        //     //        //        MenuItemName = result.MenuItemName
        //     //    });
        //     //}


        //     var ConfigItems = from e in MenuResults
        //                       select e;

        //     var result = ConfigItems.GroupBy(c => c.MenuName).Select(g => new
        //     {
        //         MenuName = g.Key,

        //         SubMenuName = (g.ToList().Select(c => new
        //         {
        //             Submenu = c.SubMenuName

        //         }).Distinct()).ToList(),


        //     //MenuItemName =g.ToList().Select(c => new
        //     //{
        //     //    MenuItem = c.MenuItemName

        //     //}).Distinct(),

        // }).ToList();



        //     var resultSub = ConfigItems.GroupBy(c => c.SubMenuName).Select(g => new
        //     {
        //         SubMenuName = g.Key,

        //         MenuItemName = (g.ToList().Select(c => new
        //         {
        //             MenuItem = c.MenuItemName
        //         }).Distinct()).ToList(),
        //     }).ToList();


        //     var subMenu = (from tech in MenuResults
        //                       group tech by tech.MenuName into grptech
        //                       select new
        //                       {
        //                           menu = grptech.Key,
        //                           submenu=grptech.ToList().Select(c => new
        //                           {
        //                               submenu = c.SubMenuName.ToString()
        //                           }).Distinct()

        //                       }).ToList();

        //     //var menuitem = (from tech in MenuResults
        //     //               group tech by tech.SubMenuName into grptech
        //     //               select new
        //     //               {
        //     //                   submenu = grptech.Key.ToString(),
        //     //                   menuitem = grptech.ToList().Select(c => new
        //     //                   {
        //     //                       subMenu=c.SubMenuName,
        //     //                       MenuItem = c.MenuItemName
        //     //                   }).Distinct()
        //     //               }).ToList();




        ////     var Menu =
        ////from c in MenuResults
        ////group c by new
        ////{
        ////    c.MenuName,
        ////    c.SubMenuName,

        ////} into gcs
        ////select new 
        ////{
        ////    Menuname = gcs.Key.MenuName.Distinct(),
        ////    submenu = gcs.Key.SubMenuName.Distinct(),
        ////    menuitem = gcs.Key.MenuItemName,
        ////   Children = gcs.ToList(),
        ////};





        //     //   var something = result.Union(resultSub);


        //     //var LocationWise = from T in subMenu
        //     //                   join c in menuitem on T.submenu equals c.submenu

        //     //                              join l in location.tblLocations
        //     //on new { k.MemberID, k.LocationID } equals
        //     //new { MemberID = l.MemberId, LocationID = l.LocationId }
        //     //// join c in menuitem on T.submenu equals c.submenu into cLast
        //     //                              from c in cLast.DefaultIfEmpty()
        //     //                              select new
        //     //                              {
        //     //                                  TechinicianName = T.TechnicianName,
        //     //                                  opencount = o != null ? o.OpenCount.ToString() : string.Empty,



        //     menuResponse.CompleteMenuList =itemList;
        //     return menuResponse;

        //   //  return result.AsEnumerable();












        // }



        //public MenuDetailsResponse GetMenuDetails()
        //{
        //    MenuDetailsResponse menuItemListResponse = new MenuDetailsResponse();
        //    List<RxOutlet.Models.CompleteMenu> itemList = new List<RxOutlet.Models.CompleteMenu>();

        //    IMenuDBManger menuDBManager1 = new MenuDBManager();
        //    IList<GetMenuResult> MenuItemList = menuDBManager1.GetCompleteMenuList();
        //    CompleteMenu obj = new CompleteMenu();


           

        //    return menuItemListResponse;
        //    }

        //public void GetMenuDetails1()
        //{
        //    //RxOutletMenuResponse menuItemListResponse = new RxOutletMenuResponse();
        //    //List<RxOutlet.Models.Menu> itemList = new List<RxOutlet.Models.Menu>();

        //     IMenuDBManger menuDBManager1 = new MenuDBManager();
        //      menuDBManager1.GetCompleteMenuList();





         
        //}

        //public RxOutLetMenuItemListResponse GetMenuItemList(int menuID, int subMenuID)
        //{
        //    RxOutLetMenuItemListResponse menuItemListResponse = new RxOutLetMenuItemListResponse();
        //    List<RxOutlet.Models.Menu> itemList = new List<RxOutlet.Models.Menu>();

        //    IMenuDBManger menuDBManager1 = new MenuDBManager();
        //    IList<GetMenuItemListResult> MenuitemListResults = menuDBManager1.GetMenuItemList(menuID, subMenuID).ToList();

        //    foreach (GetMenuItemListResult result in MenuitemListResults)
        //    {
        //        itemList.Add(new RxOutlet.Models.Menu
        //        {
        //            MenuName = result.MenuName,
        //            SubMenuName = result.SubMenuName,
        //            MenuItemName = result.MenuItemName
        //        });
        //    }
        //    menuItemListResponse.MenuItemList = itemList;
        //    return menuItemListResponse;
        //}

        public List<CompleteMenu> GetCompleteMenu()
        {
            IMenuDBManger menuDbManager = new MenuDBManager();
            IList<GetMenuResult> menuResult = menuDbManager.GetCompleteMenu();
            CompleteMenu menuObj = new CompleteMenu();
            SubMenu subObj = new SubMenu();
            MenuItem itemObj = new MenuItem();
            List<CompleteMenu> lstObj = new List<CompleteMenu>();
            //List<SubMenu> SubMenuLst = new List<SubMenu>();
            //List<MenuItem> LstItem = new List<MenuItem>();
            for (int i = 0; i < menuResult.Count; i++)
            {
                CompleteMenu testObj = lstObj.Find(x => x.MainMenuID == menuResult[i].MainMenuID);
                if (testObj == null)
                {
                    menuObj = new CompleteMenu();
                    menuObj.MainMenuID = Convert.ToInt32(menuResult[i].MainMenuID);
                    menuObj.MainMenuName = menuResult[i].MainMenuName.ToString();
                    int SubMenuCount = 0;
                    for (int j = 0; j < menuResult.Count; j++)
                    {
                        SubMenu testSub = null;
                        if (menuObj.SubMenuList != null)
                            testSub = menuObj.SubMenuList.Find(x => x.SubMenuID == menuResult[j].SubMenuID);
                        if (testSub == null)
                        {
                            if (menuResult[j].SubMainMenuID == menuObj.MainMenuID)
                            {
                                subObj = new SubMenu();
                                subObj.SubMainMenuId = Convert.ToInt32(menuResult[j].SubMainMenuID);
                                subObj.SubMenuID = Convert.ToInt32(menuResult[j].SubMenuID);
                                subObj.SubMenuName = menuResult[j].SubMenuName.ToString();
                                SubMenuCount++;
                                int itemCount = 0;
                                for (int k = 0; k < menuResult.Count; k++)
                                {
                                    if (menuResult[k].ItemSubMenuID == subObj.SubMenuID)
                                    {
                                        itemCount++;
                                        itemObj = new MenuItem();
                                        itemObj.ItemMainMenuId = Convert.ToInt32(menuResult[k].ItemMainMenuID);
                                        itemObj.ItemSubMenuId = Convert.ToInt32(menuResult[k].SubMenuID);
                                        itemObj.ItemId = Convert.ToInt32(menuResult[k].MenuItemID);
                                        itemObj.ItemName = menuResult[k].MenuItemName.ToString();
                                        if (subObj.menuItemList == null)
                                            subObj.menuItemList = new List<MenuItem>();
                                        subObj.menuItemList.Add(itemObj);
                                    }
                                }
                                if (itemCount == 0)
                                {
                                    itemObj = new MenuItem();
                                    itemObj.ItemMainMenuId = 0;
                                    itemObj.ItemSubMenuId = 0;
                                    itemObj.ItemId = 0;
                                    itemObj.ItemName = "";
                                    if (subObj.menuItemList == null)
                                        subObj.menuItemList = new List<MenuItem>();
                                    subObj.menuItemList.Add(itemObj);
                                }
                                if (menuObj.SubMenuList == null)
                                    menuObj.SubMenuList = new List<SubMenu>();
                                menuObj.SubMenuList.Add(subObj);
                            }
                        }
                    }
                    if (SubMenuCount == 0)
                    {
                        subObj = new SubMenu();
                        subObj.SubMainMenuId = 0;
                        subObj.SubMenuID = 0;
                        subObj.SubMenuName = "";
                        itemObj = new MenuItem();
                        itemObj.ItemMainMenuId = 0;
                        itemObj.ItemSubMenuId = 0;
                        itemObj.ItemId = 0;
                        itemObj.ItemName = "";
                        if (subObj.menuItemList == null)
                            subObj.menuItemList = new List<MenuItem>();
                        subObj.menuItemList.Add(itemObj);
                        if (menuObj.SubMenuList == null)
                            menuObj.SubMenuList = new List<SubMenu>();
                        menuObj.SubMenuList.Add(subObj);
                    }
                    lstObj.Add(menuObj);
                }
            }
            return lstObj;
        }






    }
}
