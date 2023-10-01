using System.Runtime.Serialization;

namespace ApiService.Service.Product.Exceptionz
{
    /// <summary>
    /// Eccezione personalizzata per gestire errori legati ai prodotti.
    /// </summary>
    [Serializable]
    public class ProductException : Exception
    {
        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="ProductException"/>.
        /// </summary>
        public ProductException()
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="ProductException"/> con un messaggio di errore specifico.
        /// </summary>
        /// <param name="message">Messaggio di errore che descrive la causa dell'eccezione.</param>
        public ProductException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="ProductException"/> con un messaggio di errore specifico e un riferimento all'eccezione interna che è la causa dell'eccezione corrente.
        /// </summary>
        /// <param name="message">Messaggio di errore che descrive la causa dell'eccezione.</param>
        /// <param name="innerException">Eccezione interna che è la causa dell'eccezione corrente.</param>
        public ProductException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="ProductException"/> con dati serializzati.
        /// </summary>
        /// <param name="info">Oggetto <see cref="SerializationInfo"/> contenente le informazioni richieste per serializzare o deserializzare l'oggetto.</param>
        /// <param name="context">Oggetto <see cref="StreamingContext"/> contenente la sorgente e la destinazione dell'oggetto serializzato.</param>
        protected ProductException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
