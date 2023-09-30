using ApiService.Service.AddressBook.Httpz;
using ApiService.Service.User.Dto;
using ApiService.Service.User.Exceptionz;
using ApiService.Service.User.Httpz;

namespace ApiService.Service.User
{
    public class UserService : IUserService
    {
        private readonly IUserHttpClient _userHttpClient;
        private readonly IAddressBookHttpClient _addressBookHttpClient;

        public UserService
        (
            IUserHttpClient userHttpClient,
            IAddressBookHttpClient addressBookHttpClient
        )
        {
            _userHttpClient = userHttpClient;
            _addressBookHttpClient = addressBookHttpClient;
        }

        public Task<object> UpdateAddressAsync(int addressId, int id)
        {
            var address = _addressBookHttpClient.Get<object>($"{addressId}");
            if (address == null)
            {
                throw new UserException($"AddressBook {addressId} non esistente");
            }

            return _userHttpClient.Put($"{id}/{addressId}", null);
        }

        public Task<List<UserDto>> GetAsync()
        {
            return _userHttpClient.Get<List<UserDto>>(string.Empty);
        }

        public Task<UserDto> GetAsync(int id)
        {
            return _userHttpClient.Get<UserDto>($"{id}");
        }

        public Task<UserDto> AddAsync(object user)
        {
            return _userHttpClient.Post<UserDto>(string.Empty, user);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _userHttpClient.Delete($"{id}");
        }
    }
}
