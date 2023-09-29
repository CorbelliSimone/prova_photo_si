using ApiService;

namespace ApiService
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            Startup startup = new(builder);
            startup.ConfigureServices();
            WebApplication app = builder.Build();
            startup.Configure(app);
            app.Run();
        }
    }
}