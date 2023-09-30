using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Threading.Tasks;

namespace AddressBooksService
{
    /// <summary>
    /// Classe di avvio dell'applicazione.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Metodo principale per l'avvio dell'applicazione.
        /// </summary>
        /// <param name="args">Argomenti della riga di comando.</param>
        public static async Task Main(string[] args)
        {
            // Crea il builder dell'applicazione web
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Configura i servizi dell'applicazione
            Startup startup = new(builder);
            await startup.ConfigureServices();

            // Costruisci l'applicazione web
            WebApplication app = builder.Build();

            // Configura l'applicazione web
            startup.Configure(app);

            // Avvia l'applicazione
            app.Run();
        }
    }
}
