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
    public interface IImagesServices
    {
        Task<ImageModel> GetImageUrl(string ImagePath, string token);
    }
}

