using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VibrantLibraryManagementV2.Core.Models.ImagesModel;

namespace VibrantLibraryManagementV2.ServiceLayer.Services.ImagesService
{
    public class ImagesServices : IImagesServices
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jSRuntime;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly string clientId;

        public ImagesServices(HttpClient httpClient, IConfiguration configuration, IJSRuntime jSRuntime, IServiceProvider serviceProvider)
        {
            _httpClient = httpClient;
            _jSRuntime = jSRuntime;
            _serviceProvider = serviceProvider;
            clientId = configuration["Api:ClientId"];
        }

        public async Task<ImageModel> GetImageUrl(string ImagePath, string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new UnauthorizedAccessException("JWT token is not provided.");
                }

                int firstSlashIndex = ImagePath.IndexOf('/', 1);
                int secondSlashIndex = ImagePath.IndexOf('/', firstSlashIndex + 1);
                int thirdSlashIndex = ImagePath.IndexOf('/', secondSlashIndex + 1);
                int nextSlashIndex = ImagePath.IndexOf('/', thirdSlashIndex + 1);
                string bibId = ImagePath.Substring(secondSlashIndex + 1, thirdSlashIndex - secondSlashIndex - 1);

                int lastIndex = ImagePath.LastIndexOf('/');
                string manupulated = ImagePath.Substring(lastIndex + 1);

                var filePath = $"/File/File?module=Bibs&tagNo=857&fileName={manupulated}&bibId={bibId}&clientId={clientId}";

                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetAsync(filePath);

                if (response.IsSuccessStatusCode)
                {
                    var ImageObject = await response.Content.ReadFromJsonAsync<ImageModel>();
                    return ImageObject;
                }

                return new ImageModel();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while fetching editor's picks.", ex);
            }
        }
    }
}
