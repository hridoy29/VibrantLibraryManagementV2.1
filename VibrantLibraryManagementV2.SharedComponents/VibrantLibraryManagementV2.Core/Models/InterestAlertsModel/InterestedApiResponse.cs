using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibrantLibraryManagementV2.Core.Models.ResponseModels;

namespace VibrantLibraryManagementV2.Core.Models.InterestAlertsModel
{
    public class InterestedApiResponse
    {
        public ResponseHeader ResponseHeader { get; set; }
        public InterestedResponse Response { get; set; }
        public InterestedFacetCounts FacetCounts { get; set; }
    }
}
