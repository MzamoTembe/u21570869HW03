using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21570869_HW03.Models
{
    public class FileModel
    {
        public string FileName { get; set; }
        public string MediaType { get; set; }
        public HttpPostedFileBase[] Files { get; set; }
    }
}