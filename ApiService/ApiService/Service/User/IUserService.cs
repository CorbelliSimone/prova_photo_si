using ApiService.Service.User.Dto;

namespace ApiService.Service.User
{
    public interface IUserService
    {
        Task<int> AddAddressAsync(int addressId, int id);
        Task<UserDto> Login(int id);
        Task<UserDto> Register(UserDto user);
    }
}
