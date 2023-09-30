using System;
using System.Runtime.Serialization;

namespace ProductsService.Service.Product.Exceptionz
{
    /// <summary>
    /// Eccezione personalizzata per i casi relativi ai prodotti.
    /// </summary>
    [Serializable]
    public class ProductException : Exception
    {
        /// <summary>
        /// Crea una nuova istanza della classe ProductException.
        /// </summary>
        public ProductException()
        {
        }

        /// <summary>
        /// Crea una nuova istanza della classe ProductException con un messaggio di errore.
        /// </summary>
        /// <param name="message">Messaggio di errore.</param>
        public ProductException(string message) : base(message)
        {
        }

        /// <summary>
        /// Crea una nuova istanza della classe ProductException con un messaggio di errore e un'eccezione interna.
        /// </summary>
        /// <param name="message">Messaggio di errore.</param>
        /// <param name="innerException">Eccezione interna.</param>
        public ProductException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Crea una nuova istanza della classe ProductException a partire dai dati di serializzazione.
        /// </summary>
        /// <param name="info">Dati di serializzazione.</param>
        /// <param name="context">Contesto di serializzazione.</param>
        protected ProductException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
