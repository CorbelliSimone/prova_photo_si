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

        public Task<UserDto> AddAsync(UserDto userLogged)
        {
            return base.Post<UserDto>(string.Empty, userLogged);
        }

        public Task<UserDto> GetAsync(int id)
        {
            return base.Get<UserDto>($"{id}");
        }

        public Task<int> PutAsync(int id, int addressId)
        {
            return base.Put<int>($"{id}/{addressId}");
        }
    }
}
