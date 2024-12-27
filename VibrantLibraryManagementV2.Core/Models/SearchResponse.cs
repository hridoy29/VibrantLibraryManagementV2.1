using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models
{
    public class SearchResponse
    {
        public ResponseHeader ResponseHeader { get; set; }
        public ResponseObj Response { get; set; }
        public FacetCounts FacetCounts { get; set; }
    }
}
