using ApiService.Service.Httpz;

namespace ApiService.Service.User.Httpz
{
    public class UserHttpClient : BaseHttpClient, IUserHttpClient
    {
        public UserHttpClient(HttpClient httpClient)
            : base(httpClient, "v1/user/")
        {
        }
    }
}
