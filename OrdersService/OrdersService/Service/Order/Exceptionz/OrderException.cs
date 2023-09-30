using System.Runtime.Serialization;

namespace OrdersService.Service.Order.Exceptionz
{
    /// <summary>
    /// Eccezione personalizzata per gestire errori relativi agli ordini.
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
        /// Inizializza una nuova istanza della classe <see cref="OrderException"/> con un messaggio di errore specificato.
        /// </summary>
        /// <param name="message">Messaggio di errore che spiega la ragione dell'eccezione.</param>
        public OrderException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="OrderException"/> con un messaggio di errore specificato
        /// e un riferimento all'eccezione interna che è la causa dell'eccezione corrente.
        /// </summary>
        /// <param name="message">Messaggio di errore che spiega la ragione dell'eccezione.</param>
        /// <param name="innerException">Eccezione interna che è la causa dell'eccezione corrente.</param>
        public OrderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="OrderException"/> con dati serializzati.
        /// </summary>
        /// <param name="info">Oggetto che contiene i dati oggetto serializzati.</param>
        /// <param name="context">Oggetto che descrive la sorgente e la destinazione di una serializzazione specifica.</param>
        protected OrderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
