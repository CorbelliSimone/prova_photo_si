using ApiService.Service.User.Cache;

using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected UserLoggedHandler _userLoggedHandler;

        public BaseApiController(UserLoggedHandler userLoggedHandler)
        {
            _userLoggedHandler = userLoggedHandler;
        }
    }
}
