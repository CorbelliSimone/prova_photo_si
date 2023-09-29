using ApiService.Controllers;

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

        public async Task<T> Put<T>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"{_baseUrl}{url}");
            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new BaseHttpClientException("");
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> Get<T>(string url)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}{url}");
            if (!response.IsSuccessStatusCode)
            {
                throw new BaseHttpClientException("");
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> Post<T>(string url, object dataPayload)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}{url}", dataPayload);
            if (!response.IsSuccessStatusCode)
            {
                throw new BaseHttpClientException("");
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
