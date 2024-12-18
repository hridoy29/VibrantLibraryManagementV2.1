using Microsoft.JSInterop;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace VibrantLibraryManagementV2.Services
{
    public class SessionService : ISessionService
    {
        private readonly IJSRuntime _jSRuntime;

        public SessionService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public async Task Set<T>(string key, T value)
        {
            await _jSRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
        }

        public async Task<T> Get<T>(string key)
        {
            var json = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", key);
            if (string.IsNullOrEmpty(json))
            {
                return default(T);
            }
            if (typeof(T)==typeof(string))
            {
                return (T)(object)json;
            }
            return JsonSerializer.Deserialize<T>(json);
        }


        public async Task Remove(string key)
        {
            await _jSRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
