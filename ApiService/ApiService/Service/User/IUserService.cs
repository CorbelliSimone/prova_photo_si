using ApiService.Service.User.Dto;

namespace ApiService.Service.User
{
    public interface IUserService
    {
        Task<object> UpdateAddressAsync(int addressId, int id);
        Task<bool> DeleteAsync(int id);
        Task<List<UserDto>> GetAsync();
        Task<UserDto> GetAsync(int id);
        Task<UserDto> AddAsync(object user);
    }
}
