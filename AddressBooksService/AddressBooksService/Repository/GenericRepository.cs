using AddressBooksService.Model;

using Microsoft.EntityFrameworkCore;

namespace AddressBooksService.Repository
{
    /// <summary>
    /// Implementazione generica del repository per le operazioni CRUD su entità specificate.
    /// </summary>
    /// <typeparam name="TEntity">Tipo dell'entità gestita dal repository.</typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly Context _context;

        /// <summary>
        /// Costruttore per inizializzare il repository con un contesto di database.
        /// </summary>
        /// <param name="context">Il contesto del database.</param>
        public GenericRepository(Context context)
        {
            this._context = context;
        }

        /// <summary>
        /// Aggiunge un'entità al contesto del database in modo asincrono.
        /// </summary>
        /// <param name="entity">L'entità da aggiungere.</param>
        /// <returns>L'entità aggiunta.</returns>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Elimina un'entità in base all'ID specificato in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'entità da eliminare.</param>
        /// <returns>L'entità eliminata o null se non trovata.</returns>
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
        /// Ottiene un'entità in base all'ID specificato in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'entità da ottenere.</param>
        /// <returns>L'entità corrispondente all'ID o null se non trovata.</returns>
        public ValueTask<TEntity> GetAsync(int id)
        {
            return _context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Ottiene tutte le entità di questo tipo in modo asincrono.
        /// </summary>
        /// <returns>Una lista di entità.</returns>
        public Task<List<TEntity>> GetAsync()
        {
            return _context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Salva le modifiche apportate al contesto del database in modo asincrono.
        /// </summary>
        /// <returns>Il numero di entità nel contesto del database la cui stato è stato modificato.</returns>
        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
