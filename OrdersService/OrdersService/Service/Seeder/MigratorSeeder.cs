using Microsoft.EntityFrameworkCore;

using OrdersService.Model;

namespace OrdersService.Service.Seeder
{
    public class MigratorSeeder : IMigratorSeeder
    {
        private readonly Context _context;

        public MigratorSeeder(Context context)
        {
            _context = context;
        }

        public Task ApplyMigration()
        {
            return _context.Database.MigrateAsync();
        }

        public async Task SeedDb()
        {
            if (!(await _context.Orders.AnyAsync()))
            {
                var orderProducts = new List<OrderProducts>
                {
                    new OrderProducts()
                    {
                        ProductId = 1,
                        Quantity = 3
                    },
                    new OrderProducts()
                    {
                        ProductId = 2,
                        Quantity = 5
                    }
                };

                var order = new Model.Order()
                {
                    OrderProducts = orderProducts,
                    OrderName = "Primo ordine",
                    UserId = 1
                };

                await _context.AddAsync(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
