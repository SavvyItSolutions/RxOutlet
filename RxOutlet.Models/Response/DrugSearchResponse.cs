﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models.Response
{
      public class DrugSearchResponse:BaseServiceResponse
    {
        public IList<DrugSearch> DrugSearch { get; set; }
    }
}
