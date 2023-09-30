using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsService.Model;
using ProductsService.Repository.Category;
using ProductsService.Repository.Product;
using ProductsService.Service.Product;
using ProductsService.Service.Seeder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ProductsService
{
    /// <summary>
    /// Classe per la configurazione dell'applicazione e dei servizi.
    /// </summary>
    public class Startup
    {
        private readonly WebApplicationBuilder _builder;

        /// <summary>
        /// Crea una nuova istanza della classe Startup.
        /// </summary>
        /// <param name="builder">L'oggetto WebApplicationBuilder.</param>
        public Startup(WebApplicationBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Configura i servizi dell'applicazione.
        /// </summary>
        /// <returns>Task completato.</returns>
        public async Task ConfigureServices()
        {
            // Aggiunge i controller all'applicazione.
            _ = _builder.Services.AddControllers();

            // Configura AutoMapper.
            _builder.Services.AddAutoMapper(typeof(Startup));

            // Configura i propri servizi.
            ConfigureMyServices(_builder.Services);

            // Configura i repository.
            ConfigureRepositories(_builder.Services);

            // Configura il database.
            await ConfigureDb();
        }

        /// <summary>
        /// Configura l'applicazione.
        /// </summary>
        /// <param name="app">L'oggetto IApplicationBuilder.</param>
        public void Configure(IApplicationBuilder app)
        {
            _ = app.UseRouting();
            _ = app.UseAuthorization();
            _ = app.UseEndpoints(x => x.MapControllers());
        }

        private async Task ConfigureDb()
        {
            // Configura il DbContext e utilizza PostgreSQL come provider.
            _ = _builder.Services.AddDbContext<Context>(options =>
                options.UseNpgsql(_builder.Configuration.GetConnectionString("PostgreSql"))
            );

            using ServiceProvider serviceProvider = _builder.Services.BuildServiceProvider();
            IMigratorSeeder migratorSeeder = serviceProvider.GetRequiredService<IMigratorSeeder>();
            await migratorSeeder.ApplyMigration();
            await migratorSeeder.SeedDb();
        }

        private void ConfigureMyServices(IServiceCollection services)
        {
            // Aggiunge i propri servizi al container di dependency injection.
            _ = services
                .AddScoped<IMigratorSeeder, MigratorSeeder>()
                .AddScoped<IProductService, ProductService>();
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            // Aggiunge i repository al container di dependency injection.
            _ = services
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
