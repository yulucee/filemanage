using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManageDAL.BusinessLayer.Models
{
    public class ServiceResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public dynamic ExternalData { get; set; }

    }
}
