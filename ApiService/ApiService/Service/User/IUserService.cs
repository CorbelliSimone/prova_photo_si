using ApiService.Controllers;

namespace ApiService.Service.User
{
    public interface IUserService
    {
        Task<int> AddAddressAsync(int addressId, int id);
        Task<UserLogged> Login(int id);
        Task<UserLogged> Register(UserLogged user);
    }
}
