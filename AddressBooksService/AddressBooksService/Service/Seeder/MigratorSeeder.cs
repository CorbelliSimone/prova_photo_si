using AddressBooksService.Model;

using Microsoft.EntityFrameworkCore;

namespace AddressBooksService.Service.Seeder
{
    /// <summary>
    /// Classe per l'applicazione delle migrazioni e il popolamento del database.
    /// </summary>
    public class MigratorSeeder : IMigratorSeeder
    {
        private readonly Context _context;

        /// <summary>
        /// Costruttore per la classe MigratorSeeder.
        /// </summary>
        /// <param name="context">Il contesto del database.</param>
        public MigratorSeeder(Context context)
        {
            _context = context;
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
        /// Popola il database con dati iniziali se non sono già presenti.
        /// </summary>
        /// <returns>Task asincrono.</returns>
        public async Task SeedDb()
        {
            if (!(await _context.Countries.AnyAsync()))
            {
                // Seed countries
                var countries = new List<Country>
                {
                    new Country { Name = "Country1", Alpha3 = "AAA", Alpha2 = "AA" },
                    new Country { Name = "Country2", Alpha3 = "BBB", Alpha2 = "BB" },
                    // Aggiungere altri paesi se necessario
                };

                // Seed cities
                var cities = new List<City>
                {
                    new City { Name = "City1", CadastralCode = "111", Country = countries.First() },
                    new City { Name = "City2", CadastralCode = "222", Country = countries.Last() },
                    // Aggiungere altre città se necessario
                };

                // Seed address books
                var addressBooks = new List<Model.AddressBook>
                {
                    new Model.AddressBook { StreetName = "Street1", Cap = "12345", StreetNumber = "123", City = cities.First() },
                    new Model.AddressBook { StreetName = "Street2", Cap = "67890", StreetNumber = "456", City = cities.Last() },
                    // Aggiungere altri indirizzi se necessario
                };

                await _context.AddressBooks.AddRangeAsync(addressBooks);
                await _context.SaveChangesAsync();
            }
        }
    }
}
