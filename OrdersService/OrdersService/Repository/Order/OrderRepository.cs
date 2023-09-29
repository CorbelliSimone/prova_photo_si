using Microsoft.EntityFrameworkCore;

using OrdersService.Model;

namespace OrdersService.Repository.Order
{
    public class OrderRepository : GenericRepository<Model.Order>, IOrderRepository
    {
        public OrderRepository(Context context) : base(context)
        {
        }

        public Task<List<Model.Order>> GetAllAndInclude()
        {
            return base._context.Orders
                .Include(x => x.OrderProducts)
                .AsNoTracking()
                .ToListAsync()
                ;
        }

        public Task<Model.Order> GetAndInclude(int id)
        {
            return base._context.Orders
                .Include(x => x.OrderProducts)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id)
                ;
        }
    }
}
