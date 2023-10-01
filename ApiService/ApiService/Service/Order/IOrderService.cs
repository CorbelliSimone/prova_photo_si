using ApiService.Service.Order.Dto;

namespace ApiService.Service.Order
{
    /// <summary>
    /// Interfaccia per il servizio di gestione degli ordini.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Elimina un ordine in base al suo ID.
        /// </summary>
        /// <param name="id">ID dell'ordine da eliminare.</param>
        /// <returns>True se l'ordine è stato eliminato con successo, false altrimenti.</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Ottiene i dettagli completi di un ordine in base al suo ID.
        /// </summary>
        /// <param name="id">ID dell'ordine.</param>
        /// <returns>Dettagli completi dell'ordine.</returns>
        Task<OrderMapperCompleteDto> GetAsync(int id);

        /// <summary>
        /// Ottiene una lista di tutti gli ordini con i dettagli completi.
        /// </summary>
        /// <returns>Lista di ordini con i dettagli completi.</returns>
        Task<List<OrderMapperCompleteDto>> GetAsync();

        /// <summary>
        /// Effettua un nuovo ordine.
        /// </summary>
        /// <param name="orderDto">Dati dell'ordine.</param>
        /// <returns>Ordine effettuato.</returns>
        Task<object> PlaceOrder(OrderDto orderDto);
    }
}
