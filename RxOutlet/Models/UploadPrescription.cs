using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RxOutlet.Models
{
    public class UploadPrescription
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string BlobURL { get; set; }
        public string Status { get; set; }
        public string Filepath { get; set; }
    }
}