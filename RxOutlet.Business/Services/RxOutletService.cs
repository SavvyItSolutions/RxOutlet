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
      


        public GetDrugNameResponse GetProductDetails(int id)
        {
            GetDrugNameResponse DrugListResponse = new GetDrugNameResponse();
            List<GetDrugList> itemList = new List<GetDrugList>();

            IMenuDBManger menuDBManager = new MenuDBManager();
            IList<GetProductDetailsResult> MainMenuResults = menuDBManager.GetProductDetails(id).ToList();

            foreach (GetProductDetailsResult result in MainMenuResults)
            {
                itemList.Add(new GetDrugList
                {

                    DrugName = result.Drugname,
                    DrugTypeName = result.drugtypename,
                    ImageNum = Convert.ToInt32( result.ImageNum),
                    RegularPrice = result.RegularPrice,
                    RetailPrice = result.RetailPrice,
                    SupplierName = result.SupplierName
                   
                });
            }
            DrugListResponse.DrugList = itemList;
            return DrugListResponse;
        }



        public GetDrugNameResponse GetDrugTypes()
        {
            GetDrugNameResponse DrugListResponse = new GetDrugNameResponse();
            List<GetDrugList> itemList = new List<GetDrugList>();

            IMenuDBManger menuDBManager = new MenuDBManager();
            IList<GetDrugTypesResult> MainMenuResults = menuDBManager.GetDrugTypes();

            foreach (GetDrugTypesResult result in MainMenuResults)
            {
                itemList.Add(new GetDrugList
                {
                    DrugTypeID = result.DrugTypeID,
                    DrugTypeName = result.DrugTypeName,
                    DrugCount = result.drugcount
                });
            }
            DrugListResponse.DrugList = itemList;
            return DrugListResponse;
        }


        public GetDrugNameResponse GetSupplierName()
        {
           GetDrugNameResponse DrugListResponse = new GetDrugNameResponse();
            List<GetDrugList> itemList = new List<GetDrugList>();

            IMenuDBManger menuDBManager = new MenuDBManager();
            IList<GetSupplierNameResult> MainMenuResults = menuDBManager.GetSupplierName();

            foreach (GetSupplierNameResult result in MainMenuResults)
            {
                itemList.Add(new GetDrugList
                {
                    SupplierID=result.SupplierId,
                    SupplierName=result.Suppliername,
                    DrugCount=result.drugcount
                });
            }
            DrugListResponse.DrugList = itemList;
            return DrugListResponse;
        }


        public GetDrugNameResponse GetDrugList()
        {
            GetDrugNameResponse DrugListResponse = new GetDrugNameResponse();
            List<GetDrugList> itemList = new List<GetDrugList>();

            IMenuDBManger menuDBManager = new MenuDBManager();
            IList<GetDrugListResult> MainMenuResults = menuDBManager.GetDrugList();

            foreach (GetDrugListResult result in MainMenuResults)
            {
                itemList.Add(new GetDrugList
                {   DrugID=Convert.ToInt32( result.DrugId),
                    ImageNum=Convert.ToInt32(result.ImgNum),
                    DrugName = result.DrugName,
                    RetailPrice= result.RetailPrice,
                    RegularPrice=result.RegularPrice
                   
                });
            }
            DrugListResponse.DrugList = itemList;
            return DrugListResponse;
        }


        //public RxOutletMenuListRespone GetMenuList()
        //{
        //    RxOutletMenuListRespone menuListResponse = new RxOutletMenuListRespone();
        //    List<Menu> itemList = new List<Menu>();

        //    IMenuDBManger menuDBManager = new MenuDBManager();
        //    IList<GetMenuListResult> MainMenuResults = menuDBManager.GetMenuList();

        //    foreach (GetMenuListResult result in MainMenuResults)
        //    {
        //        itemList.Add(new Menu
        //        {
        //            MenuName = result.MenuName
        //        });
        //    }
        //    menuListResponse.MenuList = itemList;
        //    return menuListResponse;
        //}




        //public RxOutletSubMenuListResponse GetSubMenuList(int menuID)
        //{
        //    RxOutletSubMenuListResponse subMenuListResponse = new RxOutletSubMenuListResponse();
        //    List<RxOutlet.Models.Menu> itemList = new List<RxOutlet.Models.Menu>();

        //    IMenuDBManger menuDBManager = new MenuDBManager();
        //    IList<GetSubMenuListResult> SubMenuResults = menuDBManager.GetSubMenuList(menuID).ToList();

        //    foreach (GetSubMenuListResult result in SubMenuResults)
        //    {
        //        itemList.Add(new RxOutlet.Models.Menu
        //        {
        //            MenuName = result.MenuName,
        //            SubMenuName = result.SubMenuName
        //        });
        //    }
        //    subMenuListResponse.SubMenuList = itemList;
        //    return subMenuListResponse;
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








        public List<DrugSearch> GetDrugNamesSearchService()
        {
            IMenuDBManger menuDbManager = new MenuDBManager();
            IList<GetDrugNamesSearchResult> DrugResult = menuDbManager.GetDrugNamesSearch();
            DrugSearch druglistObj = new DrugSearch();
            DrugNames drugNamesobj = new DrugNames();
            Druginfo drugObj = new Druginfo();
            Supplier supplierObj = new Supplier();
            List<DrugSearch> lstObj = new List<DrugSearch>();


          
            for (int i = 0; i < DrugResult.Count; i++)
            {
                DrugSearch testObj = lstObj.Find(x => x.SupplierID == DrugResult[i].SupplierID);
                if (testObj == null)
                {
                    druglistObj = new DrugSearch();
                    druglistObj.SupplierID = Convert.ToInt32(DrugResult[i].SupplierID);
                    druglistObj.SupplierName = DrugResult[i].SupplierName.ToString();
                    int DrugNameCount = 0;
                    for (int j = 0; j < DrugResult.Count; j++)
                    {
                        DrugNames testSub = null;
                        if (druglistObj.DrugNamesList != null)
                            testSub = druglistObj.DrugNamesList.Find(x => x.DrugID == DrugResult[j].DrugID);
                        if (testSub == null)
                        {
                            if (DrugResult[j].SupplierID == druglistObj.SupplierID)
                            {
                                drugNamesobj = new DrugNames();
                                drugNamesobj.SupplierID = Convert.ToInt32(DrugResult[j].SupplierID);
                                drugNamesobj.DrugID = Convert.ToInt32(DrugResult[j].DrugID);
                                drugNamesobj.DrugName = DrugResult[j].DrugName.ToString();
                                drugNamesobj.ImageNum = Convert.ToInt32(DrugResult[j].ImageNum);
                                DrugNameCount++;
                               
                                if (druglistObj.DrugNamesList == null)
                                    druglistObj.DrugNamesList = new List<DrugNames>();
                                druglistObj.DrugNamesList.Add(drugNamesobj);
                            }
                        }
                    }
                    if (DrugNameCount == 0)
                    {
                        drugNamesobj = new DrugNames();
                        drugNamesobj.SupplierID = 0;
                        drugNamesobj.DrugID = 0;
                        drugNamesobj.ImageNum = 0;
                        drugNamesobj.DrugName = "";
                      
                       
                        if (druglistObj.DrugNamesList == null)
                            druglistObj.DrugNamesList = new List<DrugNames>();
                        druglistObj.DrugNamesList.Add(drugNamesobj);
                    }
                    lstObj.Add(druglistObj);
                }
            }
            return lstObj;
        }




    }
}
