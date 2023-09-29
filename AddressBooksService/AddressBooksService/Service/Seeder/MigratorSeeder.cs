using AddressBooksService.Model;

using Microsoft.EntityFrameworkCore;

namespace AddressBooksService.Service.Seeder
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
            if (!(await _context.Countries.AnyAsync()))
            {
                // Seed countries
                var countries = new List<Country>
                {
                    new Country { Name = "Country1", Alpha3 = "AAA", Alpha2 = "AA" },
                    new Country { Name = "Country2", Alpha3 = "BBB", Alpha2 = "BB" },
                    // Add more countries as needed
                };

                // Seed cities
                var cities = new List<City>
                {
                    new City { Name = "City1", CadastralCode = "111", Country = countries.First() },
                    new City { Name = "City2", CadastralCode = "222", Country = countries.Last() },
                    // Add more cities as needed
                };

                // Seed address books
                var addressBooks = new List<Model.AddressBook>
                {
                    new Model.AddressBook { StreetName = "Street1", Cap = "12345", StreetNumber = "123", City = cities.First() },
                    new Model.AddressBook { StreetName = "Street2", Cap = "67890", StreetNumber = "456", City = cities.Last() },
                    // Add more address books as needed
                };
                await _context.AddressBooks.AddRangeAsync(addressBooks);
                await _context.SaveChangesAsync();
            }
        }
    }
}
