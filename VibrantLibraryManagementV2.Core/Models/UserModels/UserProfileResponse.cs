using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.Core.Models.UserModels
{
    public class UserProfileResponse
    {
        public string Message { get; set; }
        public decimal? Responsetime { get; set; }
        public int Status { get; set; }
        public decimal Timestamp { get; set; }
        public List<User> User { get; set; }
    }
}
