using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using RxOutlet.DataAccess.Interfaces;
using System.Configuration;
using RxOutlet.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace RxOutlet.DataAccess.DataManager
{
    public class MenuDBManager : IMenuDBManger
    {
        public RxOutletDataContext DBContext;
        public RxOutletDataContext DBContextRxOutlet;

        

        public string path { get; set; }

        public string imageFullPath;

       
        public MenuDBManager()
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DBContext = new DataAccess.RxOutletDataContext(connection);

            //string connection = System.Configuration.ConfigurationManager.ConnectionStrings["RxOutlet"].ConnectionString;
            //DBContext = new DataAccess.RxOutletDataContext(connection);
        }
       

    public  int UploadingPrescription(UploadPrescriptionModel uploadPrescription)
        {
            try
            {
                int result = DBContext.PrescriptionsUpload(
                   uploadPrescription.Title,
                    uploadPrescription.Description,
                    uploadPrescription.Filepath ,
                    uploadPrescription.UserID   
                                                        );
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


       

        public IList<ConfirmationEmailResult> ConfirmationEmail(string UserID)
        {
            try
            {
                ISingleResult<ConfirmationEmailResult> result =
                DBContext.ConfirmationEmail(UserID);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IList<GetPrescriptionListResult> GetPrescriptionList()
        {
            try
            {
                ISingleResult<GetPrescriptionListResult> result =
                DBContext.GetPrescriptionList();
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<GetUserPrescriptionListResult> GetUserPrescriptionList(string UserID)
        {
            try
            {
                ISingleResult<GetUserPrescriptionListResult> result =
                DBContext.GetUserPrescriptionList(UserID);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //public IList<GetCartItemsResult> GetCartItems(string UserName)
        //{
        //    try
        //    {
        //        ISingleResult<GetCartItemsResult> result =
        //        DBContext.GetCartItems(UserName);
        //        return result.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


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
        //{
        //    try
        //    {
        //        ISingleResult<GetMenuResult> result =
        //        DBContext.GetMenu();
        //        return result.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}












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


