using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models.ResponseModels
{
    public class Doc
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public List<string> Synopsis { get; set; }
        public string Publisher { get; set; }
        public int? Pubyear { get; set; }
        public string BookCover { get; set; }
        public string InfoType { get; set; }
        public string BibCreatedOn { get; set; }
        public double AvgRatings { get; set; }
        public int NoReviews { get; set; }

        public List<string>? Subject { get; set; }
        public string? Eresourcetype { get; set; }
        public int? ItemId { get; set; }
        public string? Lastitemcreatedon { get; set; }
        public List<string>? Isbn { get; set; }
    }
}
