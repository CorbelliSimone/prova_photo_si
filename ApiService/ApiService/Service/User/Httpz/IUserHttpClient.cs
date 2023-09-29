using ApiService.Controllers;

namespace ApiService.Service.User.Httpz
{
    public interface IUserHttpClient
    {
        Task<UserLogged> AddAsync(UserLogged userLogged);
        Task<UserLogged> GetAsync(int id);
        Task<int> PutAsync(int id, int addressId);
    }
}
