namespace ProductsService
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            Startup startup = new(builder);
            await startup.ConfigureServices();
            WebApplication app = builder.Build();
            startup.Configure(app);
            app.Run();
        }
    }
}