using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTest.Models.Views
{
    public class UploadViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public HttpPostedFileBase UserFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
    }
}