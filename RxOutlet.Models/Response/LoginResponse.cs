using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
  public  class LoginResponse:BaseServiceResponse
    {
        public bool IsMailConfirmed { get; set; }
        public string UserID { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public LoginResponse(bool _ismailconfirmed, string _userId, bool _success, string _errorMessage)
        {

            IsMailConfirmed = _ismailconfirmed;
            UserID = _userId;
            Success = _success;
            ErrorMessage = _errorMessage;
        }

    }
}
