using System.Runtime.Serialization;

namespace ApiService.Service.AddressBook.Exceptionz
{
    /// <summary>
    /// Eccezione personalizzata per gestire errori relativi all'entità AddressBook.
    /// </summary>
    [Serializable]
    public class AddressBookException : Exception
    {
        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="AddressBookException"/>.
        /// </summary>
        public AddressBookException()
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="AddressBookException"/> con un messaggio di errore specifico.
        /// </summary>
        /// <param name="message">Messaggio di errore che descrive la causa dell'eccezione.</param>
        public AddressBookException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="AddressBookException"/> con un messaggio di errore specifico e un'eccezione interna.
        /// </summary>
        /// <param name="message">Messaggio di errore che descrive la causa dell'eccezione.</param>
        /// <param name="innerException">Eccezione interna che è la causa dell'eccezione corrente.</param>
        public AddressBookException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="AddressBookException"/> con i dati serializzati.
        /// </summary>
        /// <param name="info">Oggetto <see cref="SerializationInfo"/> che contiene i dati oggetto serializzati.</param>
        /// <param name="context">Oggetto <see cref="StreamingContext"/> che contiene le informazioni contestuali sull'origine o sulla destinazione.</param>
        protected AddressBookException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
