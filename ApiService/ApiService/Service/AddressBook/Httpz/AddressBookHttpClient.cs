using ApiService.Service.Httpz;

namespace ApiService.Service.AddressBook.Httpz
{
    public class AddressBookHttpClient : BaseHttpClient, IAddressBookHttpClient
    {
        public AddressBookHttpClient(HttpClient httpClient) : base(httpClient, "v1/address-book/")
        {
        }

        public Task<List<object>> GetAllAsync()
        {
            return base.Get<List<object>>(string.Empty);
        }
    }
}
