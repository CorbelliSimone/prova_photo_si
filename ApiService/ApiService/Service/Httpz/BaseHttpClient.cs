using System.Net;

namespace ApiService.Service.Httpz
{
    public abstract class BaseHttpClient
    {
        private readonly string _baseUrl;

        protected readonly HttpClient _httpClient;

        protected BaseHttpClient(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        public async Task<object> Put(string url, object dataPayload)
        {
            var response = await _httpClient.PutAsJsonAsync<object>(url, dataPayload);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(string url)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}{url}");
            return response.IsSuccessStatusCode;
        }

        public async Task<T> Get<T>(string url)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}{url}");
            return await ManageResponse<T>(response);
        }

        public async Task<T> Post<T>(string url, object dataPayload)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}{url}", dataPayload);
            return await ManageResponse<T>(response);
        }

        private Task<T> ManageResponse<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new BaseHttpClientException("");
            }

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return Task.FromResult<T>(default(T));
            }

            return response.Content.ReadFromJsonAsync<T>();
        }
    }
}
