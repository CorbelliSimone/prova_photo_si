using ApiService.Service.AddressBook.Exceptionz;
using ApiService.Service.AddressBook.Httpz;
using ApiService.Service.Order.Httpz;

namespace ApiService.Service.AddressBook
{
    public class AddressBookService : IAddressBookService
    {
        private readonly IOrderHttpClient _orderHttpClient;
        private readonly IAddressBookHttpClient _addressBookHttpClient;

        public AddressBookService
        (
            IOrderHttpClient orderHttpClient,
            IAddressBookHttpClient addressBookHttpClient
        )
        {
            _orderHttpClient = orderHttpClient;
            _addressBookHttpClient = addressBookHttpClient;
        }

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

        public Task<List<object>> Get()
        {
            return _addressBookHttpClient.Get<List<object>>(string.Empty);
        }

        public Task<object> Get(int id)
        {
            return _addressBookHttpClient.Get<object>($"{id}");
        }

        public Task<object> Post(object addressBookDto)
        {
            return _addressBookHttpClient.Post<object>(string.Empty, addressBookDto);
        }

        public Task<object> Put(int id, object addressBookDto)
        {
            return _addressBookHttpClient.Put($"{id}", addressBookDto);
        }
    }
}
