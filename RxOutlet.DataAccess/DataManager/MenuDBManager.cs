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
    public class MenuDBManager : IMenuDBManger
    {
        public RxOutletDataContext DBContext;
        public RxOutletDataContext DBContextRxOutlet;

        public MenuDBManager()
          {
            //string connection = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //DBContext = new DataAccess.RxOutletDataContext(connection);

            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["RxOutlet"].ConnectionString;
            DBContext = new DataAccess.RxOutletDataContext(connection);
        }

        public IList<GetCartItemsResult> GetCartItems(string UserName)
        {
            try
            {
                ISingleResult<GetCartItemsResult> result =
                DBContext.GetCartItems(UserName);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public IList<GetProductDetailsResult> GetProductDetails(int id)
        {
            try
            {
                ISingleResult<GetProductDetailsResult> result =
                DBContext.GetProductDetails(id);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<GetDrugTypesResult> GetDrugTypes()
        {
            try
            {
                ISingleResult<GetDrugTypesResult> result =
                DBContext.GetDrugTypes();
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<GetSupplierNameResult> GetSupplierName()
        {
            try
            {
                ISingleResult<GetSupplierNameResult> result =
                DBContext.GetSupplierName();
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public IList<GetDrugListResult> GetDrugList()
        {
            try
            {
                ISingleResult<GetDrugListResult> result =
                DBContext.GetDrugList();
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        //public IList<GetMenuListResult> GetMenuList()
        //{
        //    try
        //    {
        //        ISingleResult<GetMenuListResult> result =
        //        DBContext.GetMenuList();
        //        return result.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}



        //public IList<GetSubMenuListResult> GetSubMenuList(int menuID)
        //{
        //    try
        //    {
        //        ISingleResult<GetSubMenuListResult> result =
        //        DBContext.GetSubMenuList(menuID);
        //        return result.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        //public IList<GetMenuItemListResult> GetMenuItemList(int menuID, int subMenuID)
        //{
        //    try
        //    {
        //        ISingleResult<GetMenuItemListResult> result =
        //        DBContext.GetMenuItemList(menuID, subMenuID);
        //        return result.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}




        //public IList<GetMenuResult> GetCompleteMenuList()
        // {
        //     try
        //     {
        //         ISingleResult<GetMenuResult> result =
        //         DBContext.GetMenu();
        //         return result.ToList();
        //     }
        //     catch (Exception ex)
        //     {
        //         return null;
        //     }
        // }












        public IList<GetMenuResult> GetCompleteMenu()
        {
            ISingleResult<GetMenuResult> result = DBContext.GetMenu();
            return result.ToList();
        }




        public IList<GetDrugNamesSearchResult> GetDrugNamesSearch()
        {
            ISingleResult<GetDrugNamesSearchResult> result = DBContext.GetDrugNamesSearch();
            return result.ToList();
        }

    }




}


