using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RxOutlet.Models
{
    public class PopulatingDropdown
    {
        public List<SelectListItem> SignupsecurityQuestions { get; set; }
        public string SecurityQuestions { get; set; }
        public int? SecurityQuestionID { get; set; }
    }
}