using ApiService.Service.Httpz;
using ApiService.Service.User.Dto;

namespace ApiService.Service.User.Httpz
{
    public interface IUserHttpClient : IBaseHttpClient
    {
        Task<List<UserDto>> GetByAddressId<T>(int id);
        Task<object> UpdateAddressId(int id, int? addressId);
    }
}
