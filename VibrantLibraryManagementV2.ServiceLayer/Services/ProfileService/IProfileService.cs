using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibrantLibraryManagementV2.Core.Models.UserModels;

namespace VibrantLibraryManagementV2.ServiceLayer.Services.ProfileService
{
    public interface IProfileService
    {
        public Task<UserProfileResponse> GetUserProfile(string token);
    }
}
