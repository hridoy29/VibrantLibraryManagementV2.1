namespace VibrantLibraryManagementV2.Services
{
    public interface ISessionService
    {
        /// <summary>
        /// Set data to local storage
        /// </summary>
        /// <typeparam name="T">Provide the Type of the object</typeparam>
        /// <param name="key">Name of the session object</param>
        /// <param name="value">Value to store on session</param>
        /// <returns>Void</returns>
        Task Set<T>(string key, T value);

        /// <summary>
        /// Get data from local storage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> Get<T>(string key);

        /// <summary>
        /// Remove data from local storage
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task Remove(string key);
    }
}
