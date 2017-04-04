using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RxOutlet.Models;

namespace RxOutlet.Business
{
    public interface IRxOutletService

    {
        RxOutlet_MenuListRespone GetMenuList();
        RxOutlet_SubMenuListResponse GetSubMenuList(int menuID);
        RxOutLet_MenuItemListResponse GetMenuItemList(int menuID, int subMenuID);
    }
}
