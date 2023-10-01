namespace ApiService.Service.Product
{
    /// <summary>
    /// Interfaccia che definisce i metodi per le operazioni sui prodotti.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Ottiene la lista dei prodotti in modo asincrono.
        /// </summary>
        /// <returns>La lista dei prodotti.</returns>
        Task<List<object>> GetAsync();

        /// <summary>
        /// Aggiunge un nuovo prodotto in modo asincrono.
        /// </summary>
        /// <param name="productDto">Oggetto rappresentante il prodotto da aggiungere.</param>
        /// <returns>L'oggetto prodotto aggiunto.</returns>
        Task<object> AddAsync(object productDto);

        /// <summary>
        /// Ottiene un prodotto in modo asincrono dato l'ID.
        /// </summary>
        /// <param name="id">L'ID del prodotto da ottenere.</param>
        /// <returns>L'oggetto prodotto corrispondente all'ID specificato.</returns>
        Task<object> GetAsync(int id);

        /// <summary>
        /// Cancella un prodotto in modo asincrono dato l'ID.
        /// </summary>
        /// <param name="id">L'ID del prodotto da cancellare.</param>
        /// <returns>True se la cancellazione ha avuto successo, altrimenti false.</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Aggiorna un prodotto in modo asincrono dato l'ID e i nuovi dati del prodotto.
        /// </summary>
        /// <param name="id">L'ID del prodotto da aggiornare.</param>
        /// <param name="productDto">Oggetto rappresentante i nuovi dati del prodotto.</param>
        /// <returns>L'oggetto prodotto aggiornato.</returns>
        Task<object> PutAsync(int id, object productDto);
    }
}
