using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models
{
    public class InterestedApiResponse
    {
        public ResponseHeader ResponseHeader { get; set; }
        public InterestedResponseObj Response { get; set; }
        public InterestedFacetCounts FacetCounts { get; set; }
    }
}
