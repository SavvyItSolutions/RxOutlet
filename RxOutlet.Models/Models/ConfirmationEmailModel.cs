using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Models
{ 
   public class ConfirmationEmailModel
    {
        public string UserID { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
    }
}
