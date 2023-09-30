using Microsoft.EntityFrameworkCore;

using OrdersService.Model;

namespace OrdersService.Service.Seeder
{
    /// <summary>
    /// Implementazione dell'interfaccia IMigratorSeeder per applicare migrazioni e inserire dati nel database.
    /// </summary>
    public class MigratorSeeder : IMigratorSeeder
    {
        private readonly Context _context;

        /// <summary>
        /// Crea una nuova istanza della classe MigratorSeeder.
        /// </summary>
        /// <param name="context">Un'istanza del contesto del database.</param>
        public MigratorSeeder(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Applica le migrazioni al database.
        /// </summary>
        /// <returns>Un'attività asincrona che rappresenta l'esecuzione dell'operazione.</returns>
        public Task ApplyMigration()
        {
            return _context.Database.MigrateAsync();
        }

        /// <summary>
        /// Inserisce dati di esempio nel database se non esistono già ordini.
        /// </summary>
        /// <returns>Un'attività asincrona che rappresenta l'esecuzione dell'operazione.</returns>
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
                    },
                };

                var order = new Model.Order()
                {
                    OrderProducts = orderProducts,
                    OrderName = "Primo ordine",
                    UserId = 1,
                    AddressId = 1
                };

                await _context.AddAsync(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}