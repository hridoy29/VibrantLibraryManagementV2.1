using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models.ReservationModels
{
    public class ReservationResponse
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public double ResponseTime { get; set; }
        public int Count { get; set; }
        public ReservationRecord? Record { get; set; }
    }
}
