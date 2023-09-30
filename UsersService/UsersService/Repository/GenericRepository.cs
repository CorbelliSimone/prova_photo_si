using Microsoft.EntityFrameworkCore;

using UsersService.Model;

namespace UsersService.Repository
{
    /// <summary>
    /// Implementazione generica di un repository.
    /// </summary>
    /// <typeparam name="TEntity">Il tipo di entità gestita dal repository.</typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly Context _context;

        /// <summary>
        /// Crea una nuova istanza di GenericRepository.
        /// </summary>
        /// <param name="context">Il contesto del database.</param>
        public GenericRepository(Context context)
        {
            this._context = context;
        }

        /// <summary>
        /// Aggiunge un'entità al contesto e la salva nel database.
        /// </summary>
        /// <param name="entity">L'entità da aggiungere.</param>
        /// <returns>Task asincrono che restituisce l'entità aggiunta.</returns>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Cancella un'entità dal database per ID.
        /// </summary>
        /// <param name="id">L'ID dell'entità da cancellare.</param>
        /// <returns>Task asincrono che restituisce l'entità cancellata, null se non trovata.</returns>
        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Ottiene un'entità per ID.
        /// </summary>
        /// <param name="id">L'ID dell'entità da ottenere.</param>
        /// <returns>ValueTask asincrono che restituisce l'entità, null se non trovata.</returns>
        public ValueTask<TEntity> GetAsync(int id)
        {
            return _context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Ottiene tutte le entità del tipo gestito dal repository.
        /// </summary>
        /// <returns>Task asincrono che restituisce una lista delle entità.</returns>
        public Task<List<TEntity>> GetAsync()
        {
            return _context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Salva le modifiche apportate al contesto nel database.
        /// </summary>
        /// <returns>Task asincrono che restituisce il numero di entità modificate.</returns>
        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
