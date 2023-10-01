using ApiService.Service.Httpz;

namespace ApiService.Service.AddressBook.Httpz
{
    /// <summary>
    /// Client HTTP per le operazioni relative all'address book.
    /// </summary>
    public class AddressBookHttpClient : BaseHttpClient, IAddressBookHttpClient
    {
        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="AddressBookHttpClient"/>.
        /// </summary>
        /// <param name="httpClient">Oggetto HttpClient per le richieste HTTP.</param>
        public AddressBookHttpClient(HttpClient httpClient) : base(httpClient, "v1/address-book/")
        {
        }
    }
}
