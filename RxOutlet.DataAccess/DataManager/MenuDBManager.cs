using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using RxOutlet.DataAccess.Interfaces;
using System.Configuration;
using RxOutlet.Models;

namespace RxOutlet.DataAccess.DataManager
{
  public  class MenuDBManager:IMenuDBManger
    {
        public RxOutletDataContext DBContext;

        public MenuDBManager()
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DBContext = new DataAccess.RxOutletDataContext(connection);
        }


        public IList<GetMenuListResult> GetMenuList()
        {
            try
            {
                ISingleResult<GetMenuListResult> result =
                DBContext.GetMenuList();
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public IList<GetSubMenuListResult> GetSubMenuList(int menuID)
        {
            try
            {
                ISingleResult<GetSubMenuListResult> result =
                DBContext.GetSubMenuList(menuID);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public IList<GetMenuItemListResult> GetMenuItemList(int menuID, int subMenuID)
        {
            try
            {
                ISingleResult<GetMenuItemListResult> result =
                DBContext.GetMenuItemList(menuID, subMenuID);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //public IList<GetMenuResult> GetCompleteMenuList()
        //{
        //    try
        //    {
        //        ISingleResult<GetMenuResult> result =
        //          DBContext.GetMenu();
        //        return result.ToList();


        //        //var ConfigItems = from e in DBContext.GetMenu()
        //        //                  select e;

        //        //var result = ConfigItems.GroupBy(c => c.MenuName).Select(g => new
        //        //{
        //        //    MenuName = g.Key,
        //        //    SubMenu = g.ToList().Select(c => new
        //        //    {
        //        //        Submenu = c.SubMenuName

        //        //    })
        //        //}).ToList();





        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        //public IList<GetMenuDetailsResult> GetCompleteMenuList()
        //{
        //    try
        //    {
        //       IMultipleResults result =
        //        DBContext.GetCompleteMenuList();
        //        return result.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}






        public IList<GetMenuResult> GetCompleteMenuList()
        {
            try
            {
                ISingleResult<GetMenuResult> result =
                DBContext.GetMenu();
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }





            //try
            //{
            //   IMultipleResults  result = DBContext.GetMenuDetails1();

            //    //ISingleResult<GetMenuDetailsResult> result =
            //    //  DBContext.GetMenuDetails();

            //    //var Menu1 = result.GetResult<tblMainMenu>().ToList();
            //    //var SubMenu = result.GetResult<tblSubMenus>().ToList();
            //    //var MenuItem = result.GetResult<tblMenuItem>().ToList();

            //    //var myList = new List<KeyValuePair<int, string>>();
            //    //myList.Add(new KeyValuePair<int, string>(, "One");

            //    //foreach (var menu in myList)
            //    //{
            //    //    int i = menu;
            //    //    string s = menu.MenuName;
            //    //}





            //    List<int> MenuIDs = new List<int>();
            //    List<int?> SubMenuIDs = new List<int?>();



            //    //foreach (tblMainMenu m in Menu1)
            //    //{
            //    //    MenuIDs.Add(m.MenuID);
            //    //}

            //    //foreach (tblSubMenus m in SubMenu)

            //    //{
            //    //    SubMenuIDs.Add(m.MenuID);
            //    //}

            //    IList<tblMainMenu> Menu = result.GetResult<tblMainMenu>().ToList();
            //    IList<tblSubMenus> submenu = result.GetResult<tblSubMenus>().ToList();
            //    IList<tblMenuItem> menuitem = result.GetResult<tblMenuItem>().ToList();
            //    MenuDetailsResponse detObj = new MenuDetailsResponse();

            //    CompleteMenu menuObj = new CompleteMenu();

            //    for (int i = 0; i < Menu.Count(); i++)
            //    {
            //        // Menu[i].MenuName;
            //        //menuObj.menuid = Menu[i].MenuID;
            //        //menuObj.menuname = Menu[i].MenuName;
            //        menuObj.MenuID = Menu[i].MenuID;
            //        menuObj.MenuName = Menu[i].MenuName;

            //        for (int j = 0; j < submenu.Count(); j++)
            //        {
            //            if (submenu[j].MenuID == Menu[i].MenuID)
            //            {
            //                //subObj.submenuid = submenu[j].SubMenuID;
            //                //subObj.submenuname = submenu[j].SubMenuName;


            //                for (int k = 0; k < menuitem.Count(); k++)
            //                {
            //                    if (menuitem[k].SubMenuID == submenu[j].SubMenuID)
            //                    {
            //                        itemObj.menuitemid = menuitem[k].MenuItemID;
            //                        itemObj.menuitemname = menuitem[k].MenuItemName;
            //                    }
            //                    else
            //                    {
            //                        itemObj.menuitemid = 0;
            //                        itemObj.menuitemname = "";
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                subObj.submenuid = 0;
            //                subObj.submenuname = "";
            //                itemObj.menuitemid = 0;
            //                itemObj.menuitemname = "";
            //            }

            //        }
            //        //detObj.MenuList.Add(menuObj);
            //        //detObj.subMenuList.Add(subObj);
            //        //detObj.MenuitemList.Add(itemObj);
            //    }


            //    //List<string> MenuNames = new List<string>();
            //    //List<string> submenu = new List<string>();
            //    //List<string> menuitem = new List<string>();

            //    //foreach (tblMainMenu m in Menu)
            //    //{
            //    //    var Menuid = m.MenuID;
            //    //    var menuname = m.MenuName;
            //    //    Menu.Add(Menu);
            //    //}

            //    //foreach (tblSubMenus m in SubMenu)
            //    //{
            //    //    var subMenu = m.SubMenuName;
            //    //    submenu.Add(subMenu);
            //    //}

            //    //foreach (tblMenuItem m in MenuItem)
            //    //{
            //    //    var Menuitem = m.MenuItemName;
            //    //    menuitem.Add(Menuitem);
            //    //}




            //    //return detObj;


            //}
            //catch (Exception ex)
            //{
            //   // return null;
            //}



            public IList<GetMenuResult> GetCompleteMenu()
        {
            ISingleResult<GetMenuResult> result = DBContext.GetMenu();
            return result.ToList();
        }


    }




    }


