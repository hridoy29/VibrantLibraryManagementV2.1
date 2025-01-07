using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibrantLibraryManagementV2.Core.Models.LoginModels;

namespace VibrantLibraryManagementV2.ServiceLayer.Services
{
    public interface ILoginService
    {
        public Task<LoginResponse> Login(LoginEntity loginEntity);
    }
}
