using Microsoft.EntityFrameworkCore;

using ProductsService.Model;

namespace ProductsService.Service.Seeder
{
    /// <summary>
    /// Classe per l'applicazione delle migrazioni e il seeding del database.
    /// </summary>
    public class MigratorSeeder : IMigratorSeeder
    {
        private readonly Context _context;

        /// <summary>
        /// Crea una nuova istanza della classe MigratorSeeder.
        /// </summary>
        /// <param name="context">Il contesto del database.</param>
        public MigratorSeeder(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Applica le migrazioni al database in modo asincrono.
        /// </summary>
        /// <returns>Task completato.</returns>
        public Task ApplyMigration()
        {
            return _context.Database.MigrateAsync();
        }

        /// <summary>
        /// Esegue il seeding del database in modo asincrono.
        /// </summary>
        /// <returns>Task completato.</returns>
        public async Task SeedDb()
        {
            if (!await _context.Categories.AnyAsync())
            {
                var products = new List<Model.Product>();

                for (int i = 0; i < 3; i++)
                {
                    // tabella categorie
                    var category = new Category
                    {
                        Name = $"Categoria {i}"
                    };

                    // Tabelle prodotti
                    products.Add(new Model.Product
                    {
                        Name = $"Nome prodotto {i}",
                        Description = $"Descrizione prodotto {i}",
                        Category = category
                    });

                    products.Add(new Model.Product
                    {
                        Name = $"Nome prodotto {i}",
                        Description = $"Descrizione prodotto {i}",
                        Category = category
                    });
                }

                await _context.Products.AddRangeAsync(products);
                _ = await _context.SaveChangesAsync();
            }
        }
    }
}
