using System.Runtime.Serialization;

namespace ApiService.Service.Order.Exceptionz
{
    /// <summary>
    /// Eccezione specifica per gestire gli errori legati agli ordini.
    /// </summary>
    [Serializable]
    public class OrderException : Exception
    {
        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="OrderException"/>.
        /// </summary>
        public OrderException()
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="OrderException"/> con un messaggio di errore specifico.
        /// </summary>
        /// <param name="message">Messaggio di errore che descrive la ragione dell'eccezione.</param>
        public OrderException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="OrderException"/> con un messaggio di errore specifico e un riferimento all'eccezione interna che è la causa dell'eccezione corrente.
        /// </summary>
        /// <param name="message">Messaggio di errore che descrive la ragione dell'eccezione.</param>
        /// <param name="innerException">Eccezione interna che è la causa dell'eccezione corrente.</param>
        public OrderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="OrderException"/> con dati serializzati.
        /// </summary>
        /// <param name="info">Oggetto <see cref="SerializationInfo"/> che contiene i dati oggetto serializzati.</param>
        /// <param name="context">Oggetto <see cref="StreamingContext"/> contenente le informazioni contestuali sull'origine o sulla destinazione.</param>
        protected OrderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
