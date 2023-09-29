using ApiService.Controllers;
using ApiService.Service.Httpz;

namespace ApiService.Service.User.Httpz
{
    public class UserHttpClient : BaseHttpClient, IUserHttpClient
    {
        public UserHttpClient(HttpClient httpClient)
            : base(httpClient, "v1/user/")
        {
        }

        public Task<UserLogged> AddAsync(UserLogged userLogged)
        {
            return base.Post<UserLogged>(string.Empty, userLogged);
        }

        public Task<UserLogged> GetAsync(int id)
        {
            return base.Get<UserLogged>($"{id}");
        }

        public Task<int> PutAsync(int id, int addressId)
        {
            return base.Put<int>($"{id}/{addressId}");
        }
    }
}
