﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
   public class RxOutletSubMenuListResponse:BaseServiceResponse
    {
        public IList<Menu> SubMenuList { get; set; }
    }
}




