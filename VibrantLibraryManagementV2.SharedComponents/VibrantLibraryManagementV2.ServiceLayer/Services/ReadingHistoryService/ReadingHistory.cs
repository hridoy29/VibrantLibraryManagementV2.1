using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VibrantLibraryManagementV2.Core.Models.SearchModels;

namespace VibrantLibraryManagementV2.ServiceLayer.Services.ReadingHistoryService
{
    public class ReadingHistoryServices : IReadingHistory
    {
        private readonly HttpClient _httpClient;
        private readonly IServiceProvider _serviceProvider;
        private readonly string clientId = string.Empty;

        public ReadingHistoryServices(HttpClient httpClient, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _httpClient = httpClient;
            _serviceProvider = serviceProvider;
            clientId = configuration["Api:ClientId"];

        }
        public async Task<SearchResponse> GetReadingHistory(string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new UnauthorizedAccessException("JWT token is not provided.");
                }

                var searchUrl = $"/Search/Search?json=%7B%22collection%22%3A%22recommendpastsearches%22%2C%22offset%22%3A0%2C%22sort%22%3A%22score%20desc%22%2C%22limit%22%3A16%2C%22query%22%3A%22recommendpastsearches%22%7D&clientId={clientId}";

                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetAsync(searchUrl);

                if (response.IsSuccessStatusCode)
                {
                    var searchResponse = await response.Content.ReadFromJsonAsync<SearchResponse>();
                    return searchResponse;
                }

                throw new HttpRequestException($"Error fetching reading history data: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Errow while loading ReadingHistory data", ex);
            }
        }
    }
}
