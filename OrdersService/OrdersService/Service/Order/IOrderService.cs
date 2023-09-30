using OrdersService.Service.Order.Dto;

namespace OrdersService.Service.Order
{
    /// <summary>
    /// Interfaccia per il servizio di gestione degli ordini.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Elimina un ordine in base all'ID specificato.
        /// </summary>
        /// <param name="id">ID dell'ordine da eliminare.</param>
        /// <returns>Task che rappresenta l'operazione asincrona di eliminazione.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Ottiene tutti gli ordini presenti.
        /// </summary>
        /// <returns>Task che restituisce una lista di oggetti OrderDto rappresentanti gli ordini.</returns>
        Task<List<OrderDto>> GetAsync();

        /// <summary>
        /// Ottiene un ordine in base all'ID specificato.
        /// </summary>
        /// <param name="id">ID dell'ordine da ottenere.</param>
        /// <returns>Task che restituisce l'oggetto OrderDto corrispondente all'ID specificato.</returns>
        Task<OrderDto> GetAsync(int id);

        /// <summary>
        /// Aggiunge un nuovo ordine.
        /// </summary>
        /// <param name="orderDto">Oggetto OrderDto che rappresenta l'ordine da aggiungere.</param>
        /// <returns>Task che restituisce l'oggetto OrderDto aggiunto.</returns>
        Task<OrderDto> AddAsync(OrderDto orderDto);
        Task<List<OrderDto>> GetByProductIdAsync(int productId);
    }
}
