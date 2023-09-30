using System;
using System.Runtime.Serialization;

namespace UsersService.Service.User.Exceptionz
{
    /// <summary>
    /// Eccezione personalizzata per gestire errori specifici degli utenti.
    /// </summary>
    [Serializable]
    public class UserException : Exception
    {
        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="UserException"/>.
        /// </summary>
        public UserException()
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="UserException"/> con un messaggio di errore specificato.
        /// </summary>
        /// <param name="message">Il messaggio di errore che descrive l'eccezione.</param>
        public UserException(string message) : base(message)
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="UserException"/> con un messaggio di errore e un riferimento all'eccezione interna che è la causa dell'eccezione corrente.
        /// </summary>
        /// <param name="message">Il messaggio di errore che descrive l'eccezione.</param>
        /// <param name="innerException">L'eccezione interna che è la causa dell'eccezione corrente.</param>
        public UserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="UserException"/> con dati serializzati.
        /// </summary>
        /// <param name="info">Oggetto <see cref="SerializationInfo"/> che contiene i dati oggetto serializzati relativi all'eccezione.</param>
        /// <param name="context">Oggetto <see cref="StreamingContext"/> contenente le informazioni contestuali sull'origine o sulla destinazione.</param>
        protected UserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
