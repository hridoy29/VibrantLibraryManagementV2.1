using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibrantLibraryManagementV2.Core.Models.FacetModels;

namespace VibrantLibraryManagementV2.Core.Models.InterestAlertsModel
{
    public class InterestedFacetCounts
    {
        public FacetQueries FacetQueries { get; set; }
        public FacetFields FacetFields { get; set; }
        public FacetRanges FacetRanges { get; set; }
        public FacetIntervals FacetIntervals { get; set; }
        public FacetHeatmaps FacetHeatmaps { get; set; }
    }
}
