using ApiService.Service.User.Dto;
using ApiService.Service.User.Httpz;

namespace ApiService.Service.User
{
    public class UserService : IUserService
    {
        private readonly IUserHttpClient _userHttpClient;

        public UserService(IUserHttpClient userHttpClient)
        {
            _userHttpClient = userHttpClient;
        }

        public Task<int> AddAddressAsync(int addressId, int id)
        {
            return _userHttpClient.PutAsync(id, addressId);
        }

        public Task<UserDto> Login(int id)
        {
            return _userHttpClient.GetAsync(id);
        }

        public Task<UserDto> Register(UserDto user)
        {
            return _userHttpClient.AddAsync(user);
        }
    }
}
