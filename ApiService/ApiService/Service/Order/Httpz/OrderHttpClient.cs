using ApiService.Service.Httpz;
using ApiService.Service.Order.Dto;

namespace ApiService.Service.Order.Httpz
{
    /// <summary>
    /// Implementazione del client HTTP per operazioni legate agli ordini.
    /// </summary>
    public class OrderHttpClient : BaseHttpClient, IOrderHttpClient
    {
        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="OrderHttpClient"/>.
        /// </summary>
        /// <param name="httpClient">Istanza di <see cref="HttpClient"/> per effettuare richieste HTTP.</param>
        public OrderHttpClient(HttpClient httpClient) : base(httpClient, "v1/order/")
        {
        }

        /// <summary>
        /// Ottiene una lista di ordini basati su un ID indirizzo.
        /// </summary>
        /// <param name="id">ID dell'indirizzo.</param>
        /// <returns>Lista di ordini associati all'indirizzo.</returns>
        public Task<List<OrderDto>> GetByAddressIdAsync(int id)
        {
            return Get<List<OrderDto>>($"address/{id}");
        }

        /// <summary>
        /// Ottiene una lista di ordini basati su un ID prodotto.
        /// </summary>
        /// <param name="id">ID del prodotto.</param>
        /// <returns>Lista di ordini associati al prodotto.</returns>
        public Task<List<OrderDto>> GetByProductIdAsync(int id)
        {
            return Get<List<OrderDto>>($"product/{id}");
        }
    }
}
