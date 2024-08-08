namespace ApiConsume.Services
{
    public interface IApiService
    {
        Task<T> GetAsync<T>(string url, string token = null);
        Task<T> PostAsync<T>(string url, T data, string token = null);
        Task<T> PutAsync<T>(string url, T data, string token = null);
        Task<T> PatchAsync<T>(string url, T data, string token = null);
        Task<bool> DeleteAsync(string url, string token = null);
    }
}
