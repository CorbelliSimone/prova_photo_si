namespace AddressBooksService.Service.Seeder
{
    /// <summary>
    /// Interfaccia per l'applicazione delle migrazioni e il popolamento del database.
    /// </summary>
    public interface IMigratorSeeder
    {
        /// <summary>
        /// Applica le migrazioni al database.
        /// </summary>
        /// <returns>Task asincrono.</returns>
        Task ApplyMigration();

        /// <summary>
        /// Popola il database con dati iniziali.
        /// </summary>
        /// <returns>Task asincrono.</returns>
        Task SeedDb();
    }
}
