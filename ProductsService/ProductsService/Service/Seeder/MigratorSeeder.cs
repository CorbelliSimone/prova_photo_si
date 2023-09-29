using Microsoft.EntityFrameworkCore;

using ProductsService.Model;

namespace ProductsService.Service.Seeder
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
            if (!await _context.Categories.AnyAsync())
            {
                List<Model.Product> products = new();

                for (int i = 0; i < 3; i++)
                {
                    // tabella categorie
                    var category = new Category()
                    {
                        Name = $"Categoria {i}"
                    };

                    // Tabelle prodotti
                    products.Add(new Model.Product()
                    {
                        Name = $"Nome prodotto {i}",
                        Description = $"Descrizione prodotto {i}",
                        Category = category
                    });
                    products.Add(new Model.Product()
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
