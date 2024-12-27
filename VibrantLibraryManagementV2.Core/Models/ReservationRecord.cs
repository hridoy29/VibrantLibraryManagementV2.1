using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models
{
    public class ReservationRecord
    {
        public List<ReservationItem> Reservations { get; set; } = new();
    }
}
