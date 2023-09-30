using Microsoft.EntityFrameworkCore;

using ProductsService.Model;

namespace ProductsService.Repository
{
    /// <summary>
    /// Implementazione generica del repository.
    /// </summary>
    /// <typeparam name="TEntity">Tipo dell'entità gestita dal repository.</typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly Context _context;

        /// <summary>
        /// Crea una nuova istanza del GenericRepository.
        /// </summary>
        /// <param name="context">Il contesto del database.</param>
        public GenericRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Aggiunge un'entità al repository in modo asincrono.
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
        /// Elimina un'entità dal repository in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'entità da eliminare.</param>
        /// <returns>L'entità eliminata.</returns>
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
        /// Ottiene un'entità dal repository in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'entità da ottenere.</param>
        /// <returns>L'entità con l'ID specificato.</returns>
        public ValueTask<TEntity> GetAsync(int id)
        {
            return _context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Ottiene tutte le entità dal repository in modo asincrono.
        /// </summary>
        /// <returns>Una lista di tutte le entità.</returns>
        public Task<List<TEntity>> GetAsync()
        {
            return _context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Salva le modifiche apportate al repository in modo asincrono.
        /// </summary>
        /// <returns>Il numero di entità modificate nel contesto del database.</returns>
        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
