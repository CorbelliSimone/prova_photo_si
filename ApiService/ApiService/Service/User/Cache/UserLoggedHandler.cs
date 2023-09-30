using ApiService.Service.User.Dto;

namespace ApiService.Service.User.Cache
{
    public class UserLoggedHandler
    {
        public UserDto UserLogged { get; private set; }

        public void SetUserLogged(UserDto userLogged)
        {
            UserLogged = userLogged;
        }
    }
}
