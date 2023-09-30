using System.Threading.Tasks;

namespace UsersService.Service.MigrationSeeder
{
    /// <summary>
    /// Interfaccia per l'applicazione delle migrazioni e il seeding del database.
    /// </summary>
    public interface IMigratorSeeder
    {
        /// <summary>
        /// Applica le migrazioni al database.
        /// </summary>
        /// <returns>Task asincrono.</returns>
        Task ApplyMigration();

        /// <summary>
        /// Esegue l'inizializzazione del database, inserendo dati di esempio.
        /// </summary>
        /// <returns>Task asincrono.</returns>
        Task Seed();
    }
}
