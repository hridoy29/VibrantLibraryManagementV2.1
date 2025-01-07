using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models.ReservationModels
{
    public class ReservationQuickAccess
    {
        public int? ItemId { get; set; }
        public string? ResourceType { get; set; }
        public string? ProxiedLink { get; set; }
        public string? UserGuide { get; set; }
    }
}
