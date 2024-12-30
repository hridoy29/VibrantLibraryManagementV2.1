using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibrantLibraryManagementV2.ServiceLayer.Services.Logout_Service
{
    public class LogOutService : ILogOutService
    {
        private HttpClient _httpClient { get; set; }
        private IConfiguration _configuration { get; set; }
        private string token;
        private readonly string clientId;

        public LogOutService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            clientId = configuration["Api:ClientId"];
        }
        public async Task<bool> LogOutAsync(string token)
        {


            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new UnauthorizedAccessException("JWT token is not provided.");
                }

                var logoutURl = $"/Auth/user/logout?clientId={clientId}";
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync(logoutURl);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching editor's picks.", ex);
            }
        }
    }
}
