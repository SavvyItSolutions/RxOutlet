using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
    public class RegistrationResponseModel
    {
        public List<string> Error { get; set; }
        public bool Success { get; set; }

        public RegistrationResponseModel(bool _success, List<string> _error)
        {

            Error = _error;
            Success = _success;
        }
    }
}
