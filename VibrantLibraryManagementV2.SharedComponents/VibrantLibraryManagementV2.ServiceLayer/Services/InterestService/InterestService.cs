using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VibrantLibraryManagementV2.Core.Models.InterestAlertsModel;
using VibrantLibraryManagementV2.Core.Models.LoanModels;
using VibrantLibraryManagementV2.Core.Models.ReservationModels;
using VibrantLibraryManagementV2.Core.Models.SearchModels;

namespace VibrantLibraryManagementV2.ServiceLayer.Services
{
    public class InterestService: IInterestService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jSRuntime;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly string clientId;

        public InterestService(HttpClient httpClient, IConfiguration configuration, IJSRuntime jSRuntime, IServiceProvider serviceProvider)
        {
            _httpClient = httpClient;
            _jSRuntime = jSRuntime;
            _serviceProvider = serviceProvider;
            clientId = configuration["Api:ClientId"];
        }

        public async Task<InterestResponse> GetInterests()
        {
            try
            {
                // Retrieve the JWT token from localStorage
                var token = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new UnauthorizedAccessException("JWT token not found in localStorage");
                }

                // Construct the URL
                var interestUrl = $"/Loans/interest?page=-1&pageSize=99999&clientId={clientId}";

                // Add Authorization header with the token
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                // Make the GET request
                var response = await _httpClient.GetAsync(interestUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response body
                    var interestResponse = await response.Content.ReadFromJsonAsync<InterestResponse>();
                    return interestResponse;
                }

                // Handle specific status codes or return null if needed
                return null;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new ApplicationException("Error while fetching interests.", ex);
            }
        }

        public async Task<SearchResponse> FetchAreaOfInterestAsync(string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new UnauthorizedAccessException("JWT token is not provided.");
                }

                // Construct the JSON query parameter
                //var jsonPayload = new
                //{
                //    collection = "areaofinterestprofile", // Required collection property
                //    offset,
                //    sort,
                //    limit
                //};

                //// Serialize and URL encode the JSON payload
                //var jsonParam = System.Text.Json.JsonSerializer.Serialize(jsonPayload);
                //var encodedJsonParam = Uri.EscapeDataString(jsonParam);

                // Construct the URL
                var searchUrl = $"/Search/Search?json=%7B%22collection%22%3A%22areaofinterestprofile%22%2C%22offset%22%3A0%2C%22sort%22%3A%22score%20desc%22%2C%22limit%22%3A12%7D&clientId={clientId}";

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

                // Throw an exception if the response is not successful
                throw new HttpRequestException($"Error fetching data: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching area of interest.", ex);
            }
        }

        public async Task<InterestedApiResponse> FetchInterestedResourcesAsync(string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new UnauthorizedAccessException("JWT token is not provided.");
                }

                // Construct the JSON query parameter
                //var jsonPayload = new
                //{
                //    collection = "similarresources", // Updated collection property
                //    offset,
                //    sort,
                //    limit
                //};

                //// Serialize and URL encode the JSON payload
                //var jsonParam = System.Text.Json.JsonSerializer.Serialize(jsonPayload);
                //var encodedJsonParam = Uri.EscapeDataString(jsonParam);

                // Construct the URL
                var searchUrl = $"/Search/Search?json=%7B%22collection%22%3A%22 similarresources%22%2C%22offset%22%3A0%2C%22sort%22%3A%22score%20desc%22%2C%22limit%22%3A12%7D&clientId={clientId}";

                // Add Authorization header with the token
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                // Make the GET request
                var response = await _httpClient.GetAsync(searchUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response body
                    var searchResponse = await response.Content.ReadFromJsonAsync<InterestedApiResponse>();
                    return searchResponse;
                }

                // Throw an exception if the response is not successful
                throw new HttpRequestException($"Error fetching data: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching similar resources.", ex);
            }
        }

        public async Task<LoanResponse> GetLoans(string token)
        {
            try
            {
                // Construct the URL
                var loanUrl = $"/Loans/Loans/current?sort=duedate_asc&pageNo=1&pageSize=15&filter=all&clientId={clientId}";

                // Add Authorization header with the token
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                // Make the GET request
                var response = await _httpClient.GetAsync(loanUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response body
                    var loanResponse = await response.Content.ReadFromJsonAsync<LoanResponse>();
                    return loanResponse;
                }

                // Handle specific status codes or return null if needed
                return null;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new ApplicationException("Error while fetching loans.", ex);
            }
        }

        public async Task<ReservationResponse> GetReservations(string token)
        {
            try
            {
                // Construct the URL
                var reservationUrl = $"/Loans/reservation?sort=createdon_desc&pageNo=1&pageSize=15&filter=all&clientId={clientId}";

                // Add Authorization header with the token
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                // Make the GET request
                var response = await _httpClient.GetAsync(reservationUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response body
                    var reservationResponse = await response.Content.ReadFromJsonAsync<ReservationResponse>();
                    return reservationResponse;
                }

                // Handle specific status codes or return null if needed
                return null;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new ApplicationException("Error while fetching reservations.", ex);
            }
        }

    }
}
