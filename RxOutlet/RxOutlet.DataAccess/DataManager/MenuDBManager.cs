using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using RxOutlet.DataAccess.Interfaces;
using System.Configuration;

namespace RxOutlet.DataAccess
{
  public  class MenuDBManager:IMenuDBManger
    {
        public RxOutletDataContext DBContext;

        public MenuDBManager()
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["DBCON_Elixir"].ConnectionString;
            DBContext = new DataAccess.RxOutletDataContext(connection);
        }


        public IList<sp_Elixir_GetMenuListResult> GetMenuList()
        {
            try
            {
                ISingleResult<sp_Elixir_GetMenuListResult> result =
                DBContext.sp_Elixir_GetMenuList();
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public IList<sp_Elixir_GetSubMenuListResult> GetSubMenuList(int menuID)
        {
            try
            {
                ISingleResult<sp_Elixir_GetSubMenuListResult> result =
                DBContext.sp_Elixir_GetSubMenuList(menuID);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public IList<sp_Elixir_GetMenuItemListResult> GetMenuItemList(int menuID, int subMenuID)
        {
            try
            {
                ISingleResult<sp_Elixir_GetMenuItemListResult> result =
                DBContext.sp_Elixir_GetMenuItemList(menuID, subMenuID);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
