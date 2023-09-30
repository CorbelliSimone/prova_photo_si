using AddressBooksService.Model;
using AddressBooksService.Repository.AddressBook;
using AddressBooksService.Service.AddressBook;
using AddressBooksService.Service.Seeder;

using Microsoft.EntityFrameworkCore;

namespace AddressBooksService
{
    /// <summary>
    /// Classe di configurazione iniziale dell'applicazione.
    /// </summary>
    public class Startup
    {
        private readonly WebApplicationBuilder _builder;

        /// <summary>
        /// Costruttore di classe.
        /// </summary>
        /// <param name="builder">Builder dell'applicazione web.</param>
        public Startup(WebApplicationBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Configura i servizi dell'applicazione.
        /// </summary>
        /// <returns>Task asincrono.</returns>
        public async Task ConfigureServices()
        {
            // Aggiungi il supporto per i controller
            _ = _builder.Services.AddControllers();

            // Aggiungi il supporto per AutoMapper
            _builder.Services.AddAutoMapper(typeof(Startup));

            // Configura i propri servizi
            ConfigureMyServices(_builder.Services);

            // Configura i repository
            ConfigureRepositories(_builder.Services);

            // Configura il database
            await ConfigureDb();
        }

        /// <summary>
        /// Configura l'applicazione.
        /// </summary>
        /// <param name="app">Builder dell'applicazione.</param>
        public void Configure(IApplicationBuilder app)
        {
            // Abilita il routing
            _ = app.UseRouting();

            // Abilita l'autorizzazione
            _ = app.UseAuthorization();

            // Configura gli endpoints
            _ = app.UseEndpoints(x => x.MapControllers());
        }

        /// <summary>
        /// Configura il database.
        /// </summary>
        /// <returns>Task asincrono.</returns>
        private async Task ConfigureDb()
        {
            // Aggiungi il contesto del database
            _ = _builder.Services.AddDbContext<Context>(options =>
                options.UseNpgsql(_builder.Configuration.GetConnectionString("PostgreSql"))
            );

            // Ottieni il servizio per l'applicazione
            using ServiceProvider serviceProvider = _builder.Services.BuildServiceProvider();
            IMigratorSeeder migratorSeeder = serviceProvider.GetRequiredService<IMigratorSeeder>();

            // Applica le migrazioni
            await migratorSeeder.ApplyMigration();

            // Esegui il seeding del database
            await migratorSeeder.SeedDb();
        }

        /// <summary>
        /// Configura i propri servizi.
        /// </summary>
        /// <param name="services">Collezione di servizi.</param>
        private void ConfigureMyServices(IServiceCollection services)
        {
            // Aggiungi il servizio per il seeding e migrazione
            _ = services.AddScoped<IMigratorSeeder, MigratorSeeder>();

            // Aggiungi il servizio per la gestione degli address book
            _ = services.AddScoped<IAddressBookService, AddressBookService>();
        }

        /// <summary>
        /// Configura i repository.
        /// </summary>
        /// <param name="services">Collezione di servizi.</param>
        private void ConfigureRepositories(IServiceCollection services)
        {
            // Aggiungi il repository per gli address book
            _ = services.AddScoped<IAddressBookRepository, AddressBookRepository>();
        }
    }
}
