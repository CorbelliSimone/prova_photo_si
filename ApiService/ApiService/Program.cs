namespace ApiService
{
    /// <summary>
    /// Classe principale che avvia l'applicazione.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Metodo principale che avvia l'applicazione.
        /// </summary>
        /// <param name="args">Argomenti passati alla riga di comando.</param>
        public static void Main(string[] args)
        {
            // Crea il builder per l'applicazione Web.
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Crea un'istanza della classe Startup e configura i servizi.
            Startup startup = new Startup(builder);
            startup.ConfigureServices();

            // Costruisci l'applicazione Web.
            WebApplication app = builder.Build();

            // Configura l'applicazione.
            startup.Configure(app);

            // Avvia l'applicazione.
            app.Run();
        }
    }
}
