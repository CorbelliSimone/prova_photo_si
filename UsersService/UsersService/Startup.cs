using Microsoft.EntityFrameworkCore;

using UsersService.Model;
using UsersService.Repository.User;
using UsersService.Service.MigrationSeeder;
using UsersService.Service.User;

namespace UsersService
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
            await migratorSeeder.Seed();
        }

        private void ConfigureMyServices(IServiceCollection services)
        {
            _ = services
                .AddScoped<IMigratorSeeder, MigratorSeeder>()
                .AddScoped<IUserService, UserService>()
            ;
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            _ = services
                .AddScoped<IUserRepository, UserRepository>()
            ;
        }
    }
}
