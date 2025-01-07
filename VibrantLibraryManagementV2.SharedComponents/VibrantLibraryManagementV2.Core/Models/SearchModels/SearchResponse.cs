using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibrantLibraryManagementV2.Core.Models.FacetModels;
using VibrantLibraryManagementV2.Core.Models.ResponseModels;

namespace VibrantLibraryManagementV2.Core.Models.SearchModels
{
    public class SearchResponse
    {
        public ResponseHeader ResponseHeader { get; set; }
        public Response Response { get; set; }
        public FacetCounts FacetCounts { get; set; }
    }
}
