using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersService.Repository
{
    /// <summary>
    /// Interfaccia per un repository generico che gestisce le operazioni CRUD per le entità.
    /// </summary>
    /// <typeparam name="TEntity">Il tipo dell'entità gestita dal repository.</typeparam>
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
        /// Ottiene un'entità per ID in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'entità da ottenere.</param>
        /// <returns>L'entità recuperata.</returns>
        ValueTask<TEntity> GetAsync(int id);

        /// <summary>
        /// Ottiene tutte le entità nel repository in modo asincrono.
        /// </summary>
        /// <returns>Una lista di tutte le entità nel repository.</returns>
        Task<List<TEntity>> GetAsync();

        /// <summary>
        /// Salva le modifiche apportate all'unità di lavoro del repository in modo asincrono.
        /// </summary>
        /// <returns>Il numero di entità modificate nel database.</returns>
        Task<int> SaveAsync();
    }
}
