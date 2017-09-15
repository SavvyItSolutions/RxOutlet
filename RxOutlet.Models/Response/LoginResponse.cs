using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{
  public  class LoginResponse
    {
        public bool IsMailConfirmed { get; set; }
        public string UserID { get; set; }

        public LoginResponse(bool _ismailconfirmed, string _userId)
        {

            IsMailConfirmed = _ismailconfirmed;
            UserID = _userId;
        }

    }
}
