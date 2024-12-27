using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models
{
    public class InterestResponse
    {
        public int Count { get; set; }
        public List<InterestObj> Results { get; set; }
    }
}
