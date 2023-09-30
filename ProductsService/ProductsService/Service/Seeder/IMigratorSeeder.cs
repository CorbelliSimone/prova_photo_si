using System.Threading.Tasks;

namespace ProductsService.Service.Seeder
{
    /// <summary>
    /// Interfaccia per l'applicazione delle migrazioni e il seeding del database.
    /// </summary>
    public interface IMigratorSeeder
    {
        /// <summary>
        /// Applica le migrazioni al database in modo asincrono.
        /// </summary>
        /// <returns>Task completato.</returns>
        Task ApplyMigration();

        /// <summary>
        /// Esegue il seeding del database in modo asincrono.
        /// </summary>
        /// <returns>Task completato.</returns>
        Task SeedDb();
    }
}
