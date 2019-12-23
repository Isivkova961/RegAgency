using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecrutmentAgency.Data;

namespace RecrutmentAgency.Files
{
    public class PhotoFileWrapper
    {
        public PhotoFile PhotoFile { get; set; }

        public HttpPostedFileBase PostedFile { get; set; }
    }
}