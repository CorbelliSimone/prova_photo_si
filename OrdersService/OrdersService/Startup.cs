using Microsoft.EntityFrameworkCore;

using OrdersService.Model;
using OrdersService.Repository.Order;
using OrdersService.Service.Order;
using OrdersService.Service.Seeder;

namespace OrdersService
{
    /// <summary>
    /// Classe di configurazione per l'applicazione.
    /// </summary>
    public class Startup
    {
        private readonly WebApplicationBuilder _builder;

        /// <summary>
        /// Crea una nuova istanza della classe Startup.
        /// </summary>
        /// <param name="builder">L'oggetto WebApplicationBuilder utilizzato per la configurazione dell'applicazione.</param>
        public Startup(WebApplicationBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Configura i servizi dell'applicazione.
        /// </summary>
        /// <returns>Un'attività asincrona che rappresenta l'esecuzione della configurazione dei servizi.</returns>
        public async Task ConfigureServices()
        {
            _ = _builder.Services.AddControllers();

            _builder.Services.AddAutoMapper(typeof(Startup));
            ConfigureMyServices(_builder.Services);
            ConfigureRepositories(_builder.Services);
            await ConfigureDb();
        }

        /// <summary>
        /// Configura l'applicazione.
        /// </summary>
        /// <param name="app">L'oggetto IApplicationBuilder utilizzato per la configurazione dell'applicazione.</param>
        public void Configure(IApplicationBuilder app)
        {
            _ = app.UseRouting();
            _ = app.UseAuthorization();
            _ = app.UseEndpoints(x => x.MapControllers());
        }

        private async Task ConfigureDb()
        {
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
            _ = services
                .AddScoped<IMigratorSeeder, MigratorSeeder>()
                .AddScoped<IOrderService, OrderService>()
            ;
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            _ = services
                .AddScoped<IOrderRepository, OrderRepository>()
            ;
        }
    }
}