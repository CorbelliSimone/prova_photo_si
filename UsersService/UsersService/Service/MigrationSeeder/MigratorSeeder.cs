using Microsoft.EntityFrameworkCore;

using UsersService.Model;

namespace UsersService.Service.MigrationSeeder
{
    public class MigratorSeeder : IMigratorSeeder
    {
        private readonly Context _context;

        public MigratorSeeder(Context context)
        {
            this._context = context;
        }

        public Task ApplyMigration()
        {
            return _context.Database.MigrateAsync();
        }

        public async Task Seed()
        {
            if (!(await _context.Users.AnyAsync()))
            {
                var users = new List<Model.User>();
                users.Add(new Model.User()
                {
                    FirstName = "Nome1",
                    Username = "Nome.Cognome1",
                    LastName = "Cognome1"
                });
                users.Add(new Model.User()
                {
                    FirstName = "Nome2",
                    Username = "Nome.Cognome2",
                    LastName = "Cognome2"
                });

                await _context.Users.AddRangeAsync(users);
                await _context.SaveChangesAsync();
            }
        }
    }
}
