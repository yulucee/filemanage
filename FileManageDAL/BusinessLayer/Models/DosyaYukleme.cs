using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileManageDAL.Models
{
    public class DosyaYukleme 
    {
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

    }
}