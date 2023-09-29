using AddressBooksService.Model;
using AddressBooksService.Repository.AddressBook;
using AddressBooksService.Service.AddressBook;
using AddressBooksService.Service.Seeder;
using Microsoft.EntityFrameworkCore;

namespace AddressBooksService
{
    public class Startup
    {
        private readonly WebApplicationBuilder _builder;

        public Startup(WebApplicationBuilder builder)
        {
            _builder = builder;
        }

        public async Task ConfigureServices()
        {
            _ = _builder.Services.AddControllers();

            _builder.Services.AddAutoMapper(typeof(Startup));
            ConfigureMyServices(_builder.Services);
            ConfigureRepositories(_builder.Services);
            await ConfigureDb();
        }

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
                .AddScoped<IAddressBookService, AddressBookService>()
            ;
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            _ = services
                .AddScoped<IAddressBookRepository, AddressBookRepository>()
            ;
        }
    }
}
