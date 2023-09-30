using ApiService.Service.User.Cache;

using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected IUserLoggedHandler _userLoggedHandler;

        public BaseApiController(IUserLoggedHandler userLoggedHandler)
        {
            _userLoggedHandler = userLoggedHandler;
        }
    }
}
