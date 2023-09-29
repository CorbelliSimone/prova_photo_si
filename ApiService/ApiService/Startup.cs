using ApiService.Controllers;
using ApiService.Service.AddressBook;
using ApiService.Service.AddressBook.Httpz;
using ApiService.Service.Order;
using ApiService.Service.Order.Httpz;
using ApiService.Service.Product;
using ApiService.Service.Product.Httpz;
using ApiService.Service.User;
using ApiService.Service.User.Httpz;
using ApiService.Settings;

using Microsoft.Extensions.Configuration;

namespace ApiService
{
    public class Startup
    {
        private readonly WebApplicationBuilder _builder;

        public Startup(WebApplicationBuilder builder)
        {
            _builder = builder;
        }

        public void ConfigureServices()
        {
            _ = _builder.Services.AddControllers();

            //_builder.Services.AddAutoMapper(typeof(Startup));
            ConfigureMyServices();
            ConfigureCache();

            var appSettings = _builder.Configuration.GetSection("Settings").Get<ApplicationSettings>();
            ConfigureSettings(appSettings);
            ConfigureHttp(appSettings);
        }

        private void ConfigureCache()
        {
            _ = _builder.Services
                .AddSingleton<UserLoggedHandler>()
            ;
        }

        public void Configure(IApplicationBuilder app)
        {
            _ = app.UseRouting();
            _ = app.UseAuthorization();
            _ = app.UseEndpoints(x => x.MapControllers());
        }

        private void ConfigureSettings(ApplicationSettings appSettings)
        {
            _ = _builder.Services.AddSingleton(appSettings);
        }

        private void ConfigureHttp(ApplicationSettings appSettings)
        {
            _builder.Services.AddHttpClient<IUserHttpClient, UserHttpClient>(x => x.BaseAddress = appSettings.UserServiceUrl);
            _builder.Services.AddHttpClient<IProductHttpClient, ProductHttpClient>(x => x.BaseAddress = appSettings.ProductServiceUrl);
            _builder.Services.AddHttpClient<IOrderHttpClient, OrderHttpClient>(x => x.BaseAddress = appSettings.OrderServiceUrl);
            _builder.Services.AddHttpClient<IAddressBookHttpClient, AddressBookHttpClient>(x => x.BaseAddress = appSettings.AddressBookServiceUrl);
        }

        private void ConfigureMyServices()
        {
            _ = _builder.Services
                .AddScoped<IUserService, UserService>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IAddressBookService, AddressBookService>()
            ;
        }
    }
}
