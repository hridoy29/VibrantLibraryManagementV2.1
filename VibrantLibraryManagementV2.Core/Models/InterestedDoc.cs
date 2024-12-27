using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models
{
    public class InterestedDoc
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<string> Subject { get; set; }
        public List<string> Synopsis { get; set; }
        public string Publisher { get; set; }
        public int PubYear { get; set; }
        public string InfoType { get; set; }
        public string BibCreatedOn { get; set; }
        public double AvgRatings { get; set; }
        public int NoReviews { get; set; }
        public string EResourceType { get; set; }
        public int ItemId { get; set; }
        public string LastItemCreatedOn { get; set; }
    }
}
