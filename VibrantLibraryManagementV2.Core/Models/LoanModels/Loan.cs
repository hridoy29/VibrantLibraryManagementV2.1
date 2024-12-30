using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models.LoanModels
{
    public class Loan
    {
        public int Count { get; set; }
        public List<LoanItem> Current { get; set; } = new();
    }
}
