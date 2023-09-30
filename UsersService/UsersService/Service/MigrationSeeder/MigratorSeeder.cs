using Microsoft.EntityFrameworkCore;

using UsersService.Model;

namespace UsersService.Service.MigrationSeeder
{
    /// <summary>
    /// Classe per l'applicazione delle migrazioni e il seeding del database.
    /// </summary>
    public class MigratorSeeder : IMigratorSeeder
    {
        private readonly Context _context;

        /// <summary>
        /// Costruttore per inizializzare una nuova istanza del MigratorSeeder.
        /// </summary>
        /// <param name="context">Il contesto del database.</param>
        public MigratorSeeder(Context context)
        {
            this._context = context;
        }

        /// <summary>
        /// Applica le migrazioni al database.
        /// </summary>
        /// <returns>Task asincrono.</returns>
        public Task ApplyMigration()
        {
            return _context.Database.MigrateAsync();
        }

        /// <summary>
        /// Esegue l'inizializzazione del database, inserendo dati di esempio.
        /// </summary>
        /// <returns>Task asincrono.</returns>
        public async Task Seed()
        {
            if (!(await _context.Users.AnyAsync()))
            {
                var users = new List<Model.User>
                {
                    new Model.User { FirstName = "Nome1", Username = "Nome.Cognome1", LastName = "Cognome1", AddressId = 1 },
                    new Model.User { FirstName = "Nome2", Username = "Nome.Cognome2", LastName = "Cognome2", AddressId = 1 }
                };

                await _context.Users.AddRangeAsync(users);
                await _context.SaveChangesAsync();
            }
        }
    }
}
