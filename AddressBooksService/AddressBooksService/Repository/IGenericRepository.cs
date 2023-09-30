namespace AddressBooksService.Repository
{
    /// <summary>
    /// Interfaccia generica per le operazioni CRUD su un'entità specificata.
    /// </summary>
    /// <typeparam name="TEntity">Tipo dell'entità gestita dall'interfaccia.</typeparam>
    public interface IGenericRepository<TEntity>
    {
        /// <summary>
        /// Aggiunge un'entità al repository in modo asincrono.
        /// </summary>
        /// <param name="entity">L'entità da aggiungere.</param>
        /// <returns>L'entità aggiunta.</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Elimina un'entità in base all'ID specificato in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'entità da eliminare.</param>
        /// <returns>L'entità eliminata o null se non trovata.</returns>
        Task<TEntity> DeleteAsync(int id);

        /// <summary>
        /// Ottiene un'entità in base all'ID specificato in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'entità da ottenere.</param>
        /// <returns>L'entità corrispondente all'ID o null se non trovata.</returns>
        ValueTask<TEntity> GetAsync(int id);

        /// <summary>
        /// Ottiene tutte le entità di questo tipo in modo asincrono.
        /// </summary>
        /// <returns>Una lista di entità.</returns>
        Task<List<TEntity>> GetAsync();

        /// <summary>
        /// Salva le modifiche apportate all'entità nel repository in modo asincrono.
        /// </summary>
        /// <returns>Il numero di entità nel repository la cui stato è stato modificato.</returns>
        Task<int> SaveAsync();
    }
}
