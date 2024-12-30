using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models.ResponseModels
{
    public class ResponseHeader
    {
        public int Status { get; set; }
        public int QTime { get; set; }
        public Params Params { get; set; }
    }
}
