using System.Runtime.Serialization;

namespace ApiService.Service.User.Exceptionz
{
    /// <summary>
    /// Eccezione personalizzata per gestire errori legati agli utenti.
    /// </summary>
    [Serializable]
    public class UserException : Exception
    {
        /// <summary>
        /// Crea una nuova istanza della classe UserException.
        /// </summary>
        public UserException()
        {
        }

        /// <summary>
        /// Crea una nuova istanza della classe UserException con un messaggio specifico.
        /// </summary>
        /// <param name="message">Il messaggio di errore che descrive l'eccezione.</param>
        public UserException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Crea una nuova istanza della classe UserException con un messaggio specifico e un riferimento all'eccezione interna.
        /// </summary>
        /// <param name="message">Il messaggio di errore che descrive l'eccezione.</param>
        /// <param name="innerException">L'eccezione interna che ha causato questa eccezione.</param>
        public UserException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe UserException con dati serializzati.
        /// </summary>
        /// <param name="info">I dati necessari per serializzare o deserializzare l'oggetto.</param>
        /// <param name="context">Il contesto di destinazione.</param>
        protected UserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
