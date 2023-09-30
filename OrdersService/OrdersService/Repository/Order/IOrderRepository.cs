namespace OrdersService.Repository.Order
{
    /// <summary>
    /// Interfaccia per il repository degli ordini.
    /// </summary>
    public interface IOrderRepository : IGenericRepository<Model.Order>
    {
        /// <summary>
        /// Ottiene un ordine specifico includendo le informazioni correlate.
        /// </summary>
        /// <param name="id">L'ID dell'ordine da recuperare.</param>
        /// <returns>L'ordine recuperato con le informazioni correlate.</returns>
        Task<Model.Order> GetAndInclude(int id);

        /// <summary>
        /// Ottiene tutti gli ordini includendo le informazioni correlate.
        /// </summary>
        /// <returns>Una lista di ordini con le informazioni correlate.</returns>
        Task<List<Model.Order>> GetAllAndInclude();
    }
}
