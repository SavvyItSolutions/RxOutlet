using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RxOutlet.Models;

namespace RxOutlet.Models

{
    public abstract class BaseServiceResponse
    {
        public int ErorCode { get; set; }
        public string ErrorDescription { get; set; }
    }
}
