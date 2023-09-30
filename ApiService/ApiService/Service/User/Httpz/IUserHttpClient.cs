using ApiService.Service.User.Dto;

namespace ApiService.Service.User.Httpz
{
    public interface IUserHttpClient
    {
        Task<UserDto> AddAsync(UserDto userLogged);
        Task<UserDto> GetAsync(int id);
        Task<int> PutAsync(int id, int addressId);
    }
}
