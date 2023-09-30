namespace OrdersService.Service.Seeder
{
    /// <summary>
    /// Interfaccia per il migratore e il seeder del database.
    /// </summary>
    public interface IMigratorSeeder
    {
        /// <summary>
        /// Applica le migrazioni al database.
        /// </summary>
        /// <returns>Un'attività asincrona che rappresenta l'esecuzione dell'operazione.</returns>
        Task ApplyMigration();

        /// <summary>
        /// Inserisce dati di esempio nel database.
        /// </summary>
        /// <returns>Un'attività asincrona che rappresenta l'esecuzione dell'operazione.</returns>
        Task SeedDb();
    }
}