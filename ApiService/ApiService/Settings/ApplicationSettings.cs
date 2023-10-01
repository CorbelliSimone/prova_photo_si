namespace ApiService.Settings
{
    /// <summary>
    /// Classe che rappresenta le impostazioni dell'applicazione, come gli URL dei servizi.
    /// </summary>
    public class ApplicationSettings
    {
        /// <summary>
        /// URL del servizio degli ordini.
        /// </summary>
        public Uri OrderServiceUrl { get; set; }

        /// <summary>
        /// URL del servizio dei prodotti.
        /// </summary>
        public Uri ProductServiceUrl { get; set; }

        /// <summary>
        /// URL del servizio degli utenti.
        /// </summary>
        public Uri UserServiceUrl { get; set; }

        /// <summary>
        /// URL del servizio dell'elenco degli indirizzi.
        /// </summary>
        public Uri AddressBookServiceUrl { get; set; }
    }
}
