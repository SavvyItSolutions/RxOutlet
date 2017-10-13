using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
   public class RegistrationResponseModel:BaseServiceResponse
    {
        public List<string> Error { get; set; }
        public bool Success { get; set; }

        public IList<RegistrationModel> SecurityQuestions { get; set; }

        public RegistrationResponseModel(bool _success, List<string> _error)
        {
            Error = _error;
            Success = _success;
        }

        public RegistrationModel Registration { get; set; }

        public RegistrationResponseModel(int errorCode, string errorDesc, RegistrationModel reg)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDesc;
            Registration = reg;
        }
    }
}
