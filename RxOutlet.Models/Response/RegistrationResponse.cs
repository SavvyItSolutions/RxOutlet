﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models.Response
{
    public class RegistrationResponse:BaseServiceResponse
    {
        public IList<RegistrationModel> DrugSearch { get; set; }
    }
}
