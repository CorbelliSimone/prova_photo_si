using System;
using System.Runtime.Serialization;

namespace AddressBooksService.Service.AddressBook.Exceptionz
{
    /// <summary>
    /// Eccezione personalizzata per gestire errori relativi al libro degli indirizzi.
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
        /// Inizializza una nuova istanza della classe <see cref="AddressBookException"/> con un messaggio di errore specificato.
        /// </summary>
        /// <param name="message">Messaggio di errore che descrive la ragione per cui l'eccezione è stata generata.</param>
        public AddressBookException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="AddressBookException"/> con un messaggio di errore specificato
        /// e un riferimento all'eccezione interna che è la causa dell'eccezione corrente.
        /// </summary>
        /// <param name="message">Messaggio di errore che descrive la ragione per cui l'eccezione è stata generata.</param>
        /// <param name="innerException">Eccezione interna che è la causa dell'eccezione corrente.</param>
        public AddressBookException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="AddressBookException"/> con i dati serializzati.
        /// </summary>
        /// <param name="info">Oggetto che contiene i dati oggetto serializzati.</param>
        /// <param name="context">Struttura che descrive l'origine o la destinazione di un flusso specifico di serializzazione.</param>
        protected AddressBookException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
