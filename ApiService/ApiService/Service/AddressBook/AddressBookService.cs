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

        public Task<List<object>> GetAllAsync()
        {
            return _addressBookHttpClient.GetAllAsync();
        }
    }
}
