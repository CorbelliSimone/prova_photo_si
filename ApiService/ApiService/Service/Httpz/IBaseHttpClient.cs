namespace ApiService.Service.Httpz
{
    /// <summary>
    /// Interfaccia per un client HTTP base.
    /// </summary>
    public interface IBaseHttpClient
    {
        /// <summary>
        /// Invia una richiesta HTTP di tipo PUT.
        /// </summary>
        /// <param name="url">URL specifico della richiesta.</param>
        /// <param name="dataPayload">Dati da inviare nella richiesta.</param>
        /// <returns>True se la richiesta è andata a buon fine, altrimenti False.</returns>
        Task<object> Put(string url, object dataPayload);

        /// <summary>
        /// Invia una richiesta HTTP di tipo DELETE.
        /// </summary>
        /// <param name="url">URL specifico della richiesta.</param>
        /// <returns>True se la richiesta è andata a buon fine, altrimenti False.</returns>
        Task<bool> Delete(string url);

        /// <summary>
        /// Invia una richiesta HTTP di tipo GET e deserializza la risposta nel tipo specificato.
        /// </summary>
        /// <typeparam name="T">Tipo di dati da deserializzare.</typeparam>
        /// <param name="url">URL specifico della richiesta.</param>
        /// <returns>Dati deserializzati.</returns>
        Task<T> Get<T>(string url);

        /// <summary>
        /// Invia una richiesta HTTP di tipo POST e deserializza la risposta nel tipo specificato.
        /// </summary>
        /// <typeparam name="T">Tipo di dati da deserializzare.</typeparam>
        /// <param name="url">URL specifico della richiesta.</param>
        /// <param name="dataPayload">Dati da inviare nella richiesta.</param>
        /// <returns>Dati deserializzati.</returns>
        Task<T> Post<T>(string url, object dataPayload);
    }
}
