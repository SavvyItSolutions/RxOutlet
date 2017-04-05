using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using RxOutlet.DataAccess.Interfaces;
using System.Configuration;

namespace RxOutlet.DataAccess.DataManager
{
  public  class MenuDBManager:IMenuDBManger
    {
        public RxOutletDataContext DBContext;

        public MenuDBManager()
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["DBCON_Elixir"].ConnectionString;
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

    }
}
