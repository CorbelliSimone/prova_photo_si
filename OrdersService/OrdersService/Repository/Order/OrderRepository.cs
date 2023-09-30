using Microsoft.EntityFrameworkCore;

using OrdersService.Model;

namespace OrdersService.Repository.Order
{
    /// <summary>
    /// Implementazione del repository per gli ordini.
    /// </summary>
    public class OrderRepository : GenericRepository<Model.Order>, IOrderRepository
    {
        /// <summary>
        /// Crea una nuova istanza del repository degli ordini.
        /// </summary>
        /// <param name="context">Il contesto del database.</param>
        public OrderRepository(Context context) : base(context)
        {
        }

        /// <summary>
        /// Ottiene tutti gli ordini inclusi con le informazioni correlate.
        /// </summary>
        /// <returns>Una lista di ordini con le informazioni correlate.</returns>
        public Task<List<Model.Order>> GetAllAndInclude()
        {
            return base._context.Orders
                .Include(x => x.OrderProducts)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Ottiene un ordine specifico inclusi con le informazioni correlate.
        /// </summary>
        /// <param name="id">L'ID dell'ordine da recuperare.</param>
        /// <returns>L'ordine recuperato con le informazioni correlate.</returns>
        public Task<Model.Order> GetAndInclude(int id)
        {
            return base._context.Orders
                .Include(x => x.OrderProducts)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Model.Order>> GetByAddressIdAsync(int addressId)
        {
            return base._context.Orders
                .Where(x => x.AddressId == addressId)
                .AsNoTracking()
                .ToListAsync()
                ;
        }

        public Task<List<Model.Order>> GetByProductIdAsync(int productId)
        {
            return base._context.Orders
                .Where(x => x.OrderProducts.Any(y => y.ProductId == productId))
                .AsNoTracking()
                .ToListAsync()
                ;
        }
    }
}
