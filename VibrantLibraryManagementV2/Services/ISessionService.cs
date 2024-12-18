namespace VibrantLibraryManagementV2.Services
{
    public interface ISessionService
    {
        Task Set<T>(string key, T value);
        Task<T> Get<T>(string key);
        Task Remove(string key);
    }
}
