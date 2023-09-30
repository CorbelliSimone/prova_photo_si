using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrdersService.Model;

namespace OrdersService.Repository
{
    /// <summary>
    /// Implementazione generica di un repository per le entità.
    /// </summary>
    /// <typeparam name="TEntity">Il tipo dell'entità gestita dal repository.</typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly Context _context;

        /// <summary>
        /// Crea una nuova istanza del repository generico.
        /// </summary>
        /// <param name="context">Il contesto del database.</param>
        public GenericRepository(Context context)
        {
            this._context = context;
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
        /// Ottiene un'entità per ID in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'entità da ottenere.</param>
        /// <returns>L'entità recuperata.</returns>
        public ValueTask<TEntity> GetAsync(int id)
        {
            return _context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Ottiene tutte le entità nel repository in modo asincrono.
        /// </summary>
        /// <returns>Una lista di tutte le entità nel repository.</returns>
        public Task<List<TEntity>> GetAsync()
        {
            return _context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Salva le modifiche apportate all'unità di lavoro del repository in modo asincrono.
        /// </summary>
        /// <returns>Il numero di entità modificate nel database.</returns>
        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
