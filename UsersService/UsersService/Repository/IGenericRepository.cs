using System.Collections.Generic;
using System.Threading.Tasks;

namespace UsersService.Repository
{
    /// <summary>
    /// Interfaccia generica per un repository.
    /// </summary>
    /// <typeparam name="TEntity">Il tipo di entità gestita dal repository.</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Aggiunge un'entità al repository e la salva.
        /// </summary>
        /// <param name="entity">L'entità da aggiungere.</param>
        /// <returns>Task asincrono che restituisce l'entità aggiunta.</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Cancella un'entità dal repository per ID.
        /// </summary>
        /// <param name="id">L'ID dell'entità da cancellare.</param>
        /// <returns>Task asincrono che restituisce l'entità cancellata, null se non trovata.</returns>
        Task<TEntity> DeleteAsync(int id);

        /// <summary>
        /// Ottiene un'entità per ID.
        /// </summary>
        /// <param name="id">L'ID dell'entità da ottenere.</param>
        /// <returns>ValueTask asincrono che restituisce l'entità, null se non trovata.</returns>
        ValueTask<TEntity> GetAsync(int id);

        /// <summary>
        /// Ottiene tutte le entità del tipo gestito dal repository.
        /// </summary>
        /// <returns>Task asincrono che restituisce una lista delle entità.</returns>
        Task<List<TEntity>> GetAsync();

        /// <summary>
        /// Salva le modifiche apportate al repository.
        /// </summary>
        /// <returns>Task asincrono che restituisce il numero di entità modificate.</returns>
        Task<int> SaveAsync();
    }
}
