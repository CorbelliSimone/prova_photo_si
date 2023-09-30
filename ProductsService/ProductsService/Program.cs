using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using System.Threading.Tasks;

namespace ProductsService
{
    /// <summary>
    /// Classe principale per l'avvio dell'applicazione.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Metodo principale per l'avvio dell'applicazione.
        /// </summary>
        /// <param name="args">Argomenti della riga di comando.</param>
        public static async Task Main(string[] args)
        {
            // Crea un oggetto WebApplicationBuilder per la configurazione dell'applicazione.
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Configura i servizi all'interno del container di dependency injection.
            Startup startup = new Startup(builder);
            await startup.ConfigureServices();

            // Costruisci l'applicazione Web.
            WebApplication app = builder.Build();

            // Configura l'applicazione Web.
            startup.Configure(app);

            // Avvia l'applicazione.
            app.Run();
        }
    }
}
