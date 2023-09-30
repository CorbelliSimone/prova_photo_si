using ApiService.Service.User.Dto;
using ApiService.Service.User.Exceptionz;
using ApiService.Service.User.Httpz;

namespace ApiService.Service.User
{
    public class UserService : IUserService
    {
        private readonly IUserHttpClient _userHttpClient;

        public UserService
        (
            IUserHttpClient userHttpClient
        )
        {
            _userHttpClient = userHttpClient;
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

        public Task<UserDto> AddAsync(UserDto user)
        {
            return _userHttpClient.Post<UserDto>(string.Empty, user);
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
