namespace OrdersService
{
    /// <summary>
    /// Classe che contiene il punto di ingresso dell'applicazione.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Metodo principale che avvia l'applicazione.
        /// </summary>
        /// <param name="args">Argomenti della riga di comando.</param>
        /// <returns>Un'attività asincrona che rappresenta l'esecuzione dell'applicazione.</returns>
        public static async Task Main(string[] args)
        {
            // Creazione del builder dell'applicazione web.
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Aggiunta dei servizi al contenitore.
            Startup startup = new Startup(builder);
            await startup.ConfigureServices();

            // Costruzione dell'applicazione web.
            WebApplication app = builder.Build();

            // Configurazione dell'applicazione.
            startup.Configure(app);

            // Avvio dell'applicazione.
            app.Run();
        }
    }
}