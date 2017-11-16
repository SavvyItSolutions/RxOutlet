using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
   public  class ConditionBasedResponse:BaseServiceResponse
    {
        public ConditionBased conditionBased { get; set; }

        public ConditionBasedResponse(int errorCode, string errorDesc, ConditionBased cb)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDesc;
            conditionBased = cb;
        }
    }
}
