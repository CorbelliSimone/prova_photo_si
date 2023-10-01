using System.Net;

namespace ApiService.Service.Httpz
{
    /// <summary>
    /// Classe astratta per un client HTTP di base.
    /// </summary>
    public abstract class BaseHttpClient
    {
        private readonly string _baseUrl;
        protected readonly HttpClient _httpClient;

        protected BaseHttpClient(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        /// <summary>
        /// Invia una richiesta HTTP di tipo PUT.
        /// </summary>
        /// <param name="url">L'URL per la richiesta.</param>
        /// <param name="dataPayload">I dati da inviare nel payload.</param>
        /// <returns>True se la richiesta ha avuto successo, altrimenti false.</returns>
        public async Task<object> Put(string url, object dataPayload)
        {
            var response = await _httpClient.PutAsJsonAsync<object>($"{_baseUrl}{url}", dataPayload);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Invia una richiesta HTTP di tipo DELETE.
        /// </summary>
        /// <param name="url">L'URL per la richiesta.</param>
        /// <returns>True se la richiesta ha avuto successo, altrimenti false.</returns>
        public async Task<bool> Delete(string url)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}{url}");
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Invia una richiesta HTTP di tipo GET.
        /// </summary>
        /// <typeparam name="T">Il tipo di dati da deserializzare dalla risposta.</typeparam>
        /// <param name="url">L'URL per la richiesta.</param>
        /// <returns>Il risultato della richiesta.</returns>
        public async Task<T> Get<T>(string url)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}{url}");
            return await ManageResponse<T>(response);
        }

        /// <summary>
        /// Invia una richiesta HTTP di tipo POST.
        /// </summary>
        /// <typeparam name="T">Il tipo di dati da deserializzare dalla risposta.</typeparam>
        /// <param name="url">L'URL per la richiesta.</param>
        /// <param name="dataPayload">I dati da inviare nel payload.</param>
        /// <returns>Il risultato della richiesta.</returns>
        public async Task<T> Post<T>(string url, object dataPayload)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}{url}", dataPayload);
            return await ManageResponse<T>(response);
        }

        /// <summary>
        /// Gestisce la risposta HTTP e deserializza i dati nel tipo specificato.
        /// </summary>
        /// <typeparam name="T">Il tipo di dati da deserializzare.</typeparam>
        /// <param name="response">La risposta HTTP ricevuta.</param>
        /// <returns>I dati deserializzati.</returns>
        private async Task<T> ManageResponse<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new BaseHttpClientException(await response.Content.ReadAsStringAsync());
            }

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return default(T);
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
