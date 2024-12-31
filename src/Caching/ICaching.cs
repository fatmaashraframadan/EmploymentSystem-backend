namespace Caching
{
    public interface ICaching
    {
        Task<T> SetAsync<T>(string key, T value);
        Task<T> GetAsync<T>(string key);
    }
}