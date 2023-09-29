using UsersService.Service.User.Dto;

namespace UsersService.Service.User
{
    public interface IUserService
    {
        Task<UserDto> AddAsync(UserDto userDto);
        Task DeleteAsync(int id);
        Task<int> UpdateAddressAsync(int id, int addressId);
        Task<UserDto> GetAsync(int id);
        Task<List<UserDto>> GetAsync();
        Task<int> UpdateAsync(int id, UserDto userDto);
    }
}
