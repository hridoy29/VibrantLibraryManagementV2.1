using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models
{
    public class FacetCounts
    {
        public Dictionary<string, int> FacetQueries { get; set; }
        public Dictionary<string, List<object>> FacetFields { get; set; }
        public Dictionary<string, object> FacetRanges { get; set; }
        public Dictionary<string, object> FacetIntervals { get; set; }
        public Dictionary<string, object> FacetHeatmaps { get; set; }
    }
}
