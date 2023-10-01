using ApiService.Service.Httpz;
using ApiService.Service.Order.Dto;

namespace ApiService.Service.Order.Httpz
{
    /// <summary>
    /// Interfaccia per un client HTTP specifico per le operazioni legate agli ordini.
    /// </summary>
    public interface IOrderHttpClient : IBaseHttpClient
    {
        /// <summary>
        /// Ottiene una lista di ordini basati su un ID prodotto.
        /// </summary>
        /// <param name="id">ID del prodotto.</param>
        /// <returns>Lista di ordini associati al prodotto.</returns>
        Task<List<OrderDto>> GetByProductIdAsync(int id);

        /// <summary>
        /// Ottiene una lista di ordini basati su un ID indirizzo.
        /// </summary>
        /// <param name="id">ID dell'indirizzo.</param>
        /// <returns>Lista di ordini associati all'indirizzo.</returns>
        Task<List<OrderDto>> GetByAddressIdAsync(int id);
    }
}
