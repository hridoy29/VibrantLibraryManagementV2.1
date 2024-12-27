using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models
{
    public class ImageObject
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string FileUrl { get; set; }
        public bool? Result { get; set; }
    }
}
