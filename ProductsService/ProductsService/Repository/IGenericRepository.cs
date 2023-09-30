namespace ProductsService.Repository
{
    /// <summary>
    /// Interfaccia generica per un repository.
    /// </summary>
    /// <typeparam name="TEntity">Tipo dell'entità gestita dal repository.</typeparam>
    public interface IGenericRepository<TEntity>
    {
        /// <summary>
        /// Aggiunge un'entità al repository in modo asincrono.
        /// </summary>
        /// <param name="entity">L'entità da aggiungere.</param>
        /// <returns>L'entità aggiunta.</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Elimina un'entità dal repository in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'entità da eliminare.</param>
        /// <returns>L'entità eliminata.</returns>
        Task<TEntity> DeleteAsync(int id);

        /// <summary>
        /// Ottiene un'entità dal repository in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'entità da ottenere.</param>
        /// <returns>L'entità con l'ID specificato.</returns>
        ValueTask<TEntity> GetAsync(int id);

        /// <summary>
        /// Ottiene tutte le entità dal repository in modo asincrono.
        /// </summary>
        /// <returns>Una lista di tutte le entità.</returns>
        Task<List<TEntity>> GetAsync();

        /// <summary>
        /// Salva le modifiche apportate al repository in modo asincrono.
        /// </summary>
        /// <returns>Il numero di entità modificate nel contesto del database.</returns>
        Task<int> SaveAsync();
    }
}
