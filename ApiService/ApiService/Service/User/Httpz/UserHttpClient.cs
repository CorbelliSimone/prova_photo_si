using ApiService.Service.Httpz;
using ApiService.Service.User.Dto;

namespace ApiService.Service.User.Httpz
{
    public class UserHttpClient : BaseHttpClient, IUserHttpClient
    {
        public UserHttpClient(HttpClient httpClient)
            : base(httpClient, "v1/user/")
        {
        }

        public Task<List<UserDto>> GetByAddressId<T>(int id)
        {
            return Get<List<UserDto>>($"address/{id}");
        }

        public Task<object> UpdateAddressId(int id, int? addressId)
        {
            return Put($"address/{id}/{addressId}", null);
        }
    }
}
