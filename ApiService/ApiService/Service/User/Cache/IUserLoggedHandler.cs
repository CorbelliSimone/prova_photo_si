using ApiService.Service.User.Dto;

namespace ApiService.Service.User.Cache
{
    public interface IUserLoggedHandler
    {
        void SetUserLogged(UserDto userLogged);
        UserDto GetUserLogged();
    }
}
