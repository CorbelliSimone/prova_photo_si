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

            return _userHttpClient.UpdateAddressId(id, addressId);
        }

        public Task<List<UserDto>> GetAsync()
        {
            return _userHttpClient.Get<List<UserDto>>(string.Empty);
        }

        public async Task<UserDto> LoginAsync(int id)
        {
            var userToLog = await _userHttpClient.Get<UserDto>($"{id}");
            if (userToLog == null)
            {
                throw new UserException($"Utente {id} non esistente");
            }
            return userToLog;
        }

        public Task<UserDto> GetAsync(int id)
        {
            return _userHttpClient.Get<UserDto>($"{id}");
        }

        public async Task<UserDto> AddAsync(UserDto user)
        {
            if (user.AddressId.HasValue)
            {
                var addressBook = await _addressBookHttpClient.Get<object>($"{user.AddressId}");
                if (addressBook == null)
                {
                    throw new UserException($"Non posso creare l'utente per indirizzo {user.AddressId} non esistente");
                }
            }

            return await _userHttpClient.Post<UserDto>(string.Empty, user);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _userHttpClient.Delete($"{id}");
        }

        public Task<object> UpdateAsync(int id, object userDto)
        {
            return _userHttpClient.Put($"{id}", userDto);
        }
    }
}
