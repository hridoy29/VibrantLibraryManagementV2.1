using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VibrantLibraryManagementV2.Core.Models.UserModels;
using VibrantLibraryManagementV2.ServiceLayer.Services.ProfileService;

namespace VibrantLibraryManagementV2.ServiceLayer.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jSRuntime;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly string clientId;

        public ProfileService(HttpClient httpClient, IConfiguration configuration, IJSRuntime jSRuntime, IServiceProvider serviceProvider)
        {
            _httpClient = httpClient;
            _jSRuntime = jSRuntime;
            _serviceProvider = serviceProvider;
            clientId = configuration["Api:ClientId"];
        }

        public async Task<UserProfileResponse> GetUserProfile(string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new UnauthorizedAccessException("JWT token not found in localStorage");
                }

                var userProfileUrl = $"/Loans/profile?clientId={clientId}";

                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetAsync(userProfileUrl);

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var userProfileResponse = await response.Content.ReadFromJsonAsync<UserProfileResponse>();
                        return userProfileResponse;
                    }
                    catch (Exception ex )
                    {
                        return null;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new ApplicationException("Error while fetching interests.", ex);
            }
        }
    }
}
