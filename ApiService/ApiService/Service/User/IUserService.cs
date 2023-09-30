using ApiService.Service.User.Dto;

namespace ApiService.Service.User
{
    public interface IUserService
    {
        Task<object> UpdateAsync(int id, object userDto);
        Task<bool> DeleteAsync(int id);
        Task<List<UserDto>> GetAsync();
        Task<UserDto> GetAsync(int id);
        Task<UserDto> AddAsync(UserDto user);
        Task<UserDto> LoginAsync(int id);
    }
}
