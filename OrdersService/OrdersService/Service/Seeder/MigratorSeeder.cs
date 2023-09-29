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

        }
    }
}
