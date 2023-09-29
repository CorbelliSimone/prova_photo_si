using Microsoft.EntityFrameworkCore;

using OrdersService.Model;

namespace OrdersService.Repository.Order
{
    public class OrderRepository : GenericRepository<Model.Order>, IOrderRepository
    {
        public OrderRepository(Context context) : base(context)
        {
        }

        public Task<Model.Order> LastOrDefaultAsync() => base._context.Orders.LastOrDefaultAsync();
    }
}
