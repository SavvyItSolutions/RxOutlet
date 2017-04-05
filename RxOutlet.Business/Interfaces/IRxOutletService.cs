﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RxOutlet.Models;

namespace RxOutlet.Business
{
    public interface IRxOutletService

    {
        RxOutletMenuListRespone GetMenuList();
        RxOutletSubMenuListResponse GetSubMenuList(int menuID);
        RxOutLetMenuItemListResponse GetMenuItemList(int menuID, int subMenuID);
    }
}
