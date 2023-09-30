namespace ApiService.Service.Httpz
{
    public interface IBaseHttpClient
    {
        Task<object> Put(string url, object dataPayload);
        Task<bool> Delete(string url);
        Task<T> Get<T>(string url);
        Task<T> Post<T>(string url, object dataPayload);
    }
}
