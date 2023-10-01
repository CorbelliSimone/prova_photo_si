using ApiService.Service.AddressBook.Exceptionz;
using ApiService.Service.AddressBook.Httpz;
using ApiService.Service.Order.Httpz;

namespace ApiService.Service.AddressBook
{
    /// <summary>
    /// Servizio per la gestione dell'address book.
    /// </summary>
    public class AddressBookService : IAddressBookService
    {
        private readonly IOrderHttpClient _orderHttpClient;
        private readonly IAddressBookHttpClient _addressBookHttpClient;

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="AddressBookService"/>.
        /// </summary>
        /// <param name="orderHttpClient">Client HTTP per le operazioni relative agli ordini.</param>
        /// <param name="addressBookHttpClient">Client HTTP per le operazioni relative all'address book.</param>
        public AddressBookService(IOrderHttpClient orderHttpClient, IAddressBookHttpClient addressBookHttpClient)
        {
            _orderHttpClient = orderHttpClient;
            _addressBookHttpClient = addressBookHttpClient;
        }

        /// <summary>
        /// Elimina un indirizzo.
        /// </summary>
        /// <param name="id">ID dell'indirizzo da eliminare.</param>
        /// <returns>True se l'eliminazione è avvenuta con successo, altrimenti False.</returns>
        public async Task<bool> Delete(int id)
        {
            // se trovo qualcosa di associato non posso eliminare l'indirizzo
            var ordersWithAddress = await _orderHttpClient.GetByAddressIdAsync(id);
            if (ordersWithAddress.Any())
            {
                throw new AddressBookException($"Ordini con id {string.Join(", ", ordersWithAddress.Select(x => x.Id))} associati all'indirizzo, non posso eliminarlo");
            }

            return await _addressBookHttpClient.Delete($"{id}");
        }

        /// <summary>
        /// Ottiene tutti gli indirizzi.
        /// </summary>
        /// <returns>Lista degli indirizzi.</returns>
        public Task<List<object>> Get()
        {
            return _addressBookHttpClient.Get<List<object>>(string.Empty);
        }

        /// <summary>
        /// Ottiene un indirizzo per ID.
        /// </summary>
        /// <param name="id">ID dell'indirizzo.</param>
        /// <returns>L'indirizzo corrispondente all'ID specificato.</returns>
        public Task<object> Get(int id)
        {
            return _addressBookHttpClient.Get<object>($"{id}");
        }

        /// <summary>
        /// Crea un nuovo indirizzo.
        /// </summary>
        /// <param name="addressBookDto">Dati del nuovo indirizzo.</param>
        /// <returns>L'indirizzo creato.</returns>
        public Task<object> Post(object addressBookDto)
        {
            return _addressBookHttpClient.Post<object>(string.Empty, addressBookDto);
        }

        /// <summary>
        /// Aggiorna un indirizzo.
        /// </summary>
        /// <param name="id">ID dell'indirizzo da aggiornare.</param>
        /// <param name="addressBookDto">Dati dell'indirizzo da aggiornare.</param>
        /// <returns>L'indirizzo aggiornato.</returns>
        public Task<object> Put(int id, object addressBookDto)
        {
            return _addressBookHttpClient.Put($"{id}", addressBookDto);
        }
    }
}
