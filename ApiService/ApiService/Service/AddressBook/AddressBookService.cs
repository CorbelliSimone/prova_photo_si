using ApiService.Service.AddressBook.Httpz;

namespace ApiService.Service.AddressBook
{
    public class AddressBookService : IAddressBookService
    {
        private readonly IAddressBookHttpClient _addressBookHttpClient;

        public AddressBookService(IAddressBookHttpClient addressBookHttpClient)
        {
            _addressBookHttpClient = addressBookHttpClient;
        }

        public Task<bool> Delete(int id)
        {
            return _addressBookHttpClient.Delete($"{id}");
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
