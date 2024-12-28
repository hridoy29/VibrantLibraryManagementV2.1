using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VibrantLibraryManagementV2.Core.Models;

namespace VibrantLibraryManagementV2.ServiceLayer.Services
{
    public class RecommendedService: IRecommendedService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jSRuntime;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly string clientId;

        public RecommendedService(HttpClient httpClient, IConfiguration configuration, IJSRuntime jSRuntime, IServiceProvider serviceProvider)
        {
            _httpClient = httpClient;
            _jSRuntime = jSRuntime;
            _serviceProvider = serviceProvider;
            clientId = configuration["Api:ClientId"];
        }

        public async Task<SearchResponse> FetchEditorsPicksAsync(string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new UnauthorizedAccessException("JWT token is not provided.");
                }

                // Construct the URL
                var searchUrl = $"/Search/Search?json=%7B%22collection%22%3A%22editorspick%22%2C%22offset%22%3A0%2C%22sort%22%3A%22bibcreatedon%20desc%22%2C%22limit%22%3A12%2C%22query%22%3A%22editorspick%22%7D&clientId={clientId}";

                // Add Authorization header with the token
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                // Make the GET request
                var response = await _httpClient.GetAsync(searchUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response body
                    var searchResponse = await response.Content.ReadFromJsonAsync<SearchResponse>();
                    return searchResponse;
                }
                //if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                //{
                //    var searchResponse = await response.Content.ReadFromJsonAsync<SearchResponse>();
                //    return searchResponse;
                //}
                // Throw an exception if the response is not successful
                throw new HttpRequestException($"Error fetching data: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching editor's picks.", ex);
            }
        }
    }
}
