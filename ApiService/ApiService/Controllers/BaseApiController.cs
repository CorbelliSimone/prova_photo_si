using ApiService.Service.User.Cache;

using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    /// <summary>
    /// Classe base per i controller API.
    /// </summary>
    public class BaseApiController : ControllerBase
    {
        protected IUserLoggedHandler _userLoggedHandler;

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="BaseApiController"/>.
        /// </summary>
        /// <param name="userLoggedHandler">Handler per l'utente loggato.</param>
        public BaseApiController(IUserLoggedHandler userLoggedHandler)
        {
            _userLoggedHandler = userLoggedHandler;
        }
    }
}
