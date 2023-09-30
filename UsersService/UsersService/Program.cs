using UsersService;

namespace UsersService
{
    /// <summary>
    /// Classe principale dell'applicazione che contiene il metodo di ingresso.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Metodo di ingresso dell'applicazione.
        /// </summary>
        /// <param name="args">Argomenti passati all'avvio dell'applicazione.</param>
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            // Aggiungi i servizi al contenitore.
            Startup startup = new(builder);
            await startup.ConfigureServices();
            WebApplication app = builder.Build();
            startup.Configure(app);
            app.Run();
        }
    }

}