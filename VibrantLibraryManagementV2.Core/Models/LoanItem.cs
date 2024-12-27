using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models
{
    public class LoanItem
    {
        public string? BorrowDate { get; set; }
        public string? Branch { get; set; }
        public string? Collection { get; set; }
        public bool DigitalLoans { get; set; }
        public string? DueDate { get; set; }
        public string? IssueDescription { get; set; }
        public int ItemId { get; set; }
        public string? ItemNo { get; set; }
        public string? ItemType { get; set; }
        public string? ItemTypeDesc { get; set; }
        public string? Location { get; set; }
        public bool Overdue { get; set; }
        public string? ResourceType { get; set; }
        public string? ReturnDate { get; set; }
        public string? ReviewId { get; set; }
        public string? Volume { get; set; }
        public string? Url { get; set; }
        public int TotalInQueue { get; set; }
        public int BibId { get; set; }
        public string? Title { get; set; }
        public string? BookCover { get; set; }
        public string? Author { get; set; }
        public string? InfoType { get; set; }
        public string? PubDate { get; set; }
        public string? Abstract { get; set; }
        public string? Source { get; set; }
        public string? Isbn { get; set; }
        public string? Synopsis { get; set; }
        public string? BibCreatedOn { get; set; }
        public string? LastItemCreatedOn { get; set; }
        public QuickAccess? QuickAccess { get; set; }
        public AllReviews? AllReviews { get; set; }
    }
}
