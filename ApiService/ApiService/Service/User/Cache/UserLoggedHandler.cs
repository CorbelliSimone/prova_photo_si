using ApiService.Service.User.Dto;

namespace ApiService.Service.User.Cache
{
    /// <summary>
    /// Gestore per l'utente loggato.
    /// </summary>
    public class UserLoggedHandler : IUserLoggedHandler
    {
        /// <summary>
        /// Ottiene o imposta l'utente loggato.
        /// </summary>
        public UserDto UserLogged { get; private set; }

        /// <summary>
        /// Imposta l'utente loggato.
        /// </summary>
        /// <param name="userLogged">Utente loggato da impostare.</param>
        public void SetUserLogged(UserDto userLogged)
        {
            UserLogged = userLogged;
        }

        /// <summary>
        /// Ottiene l'utente loggato.
        /// </summary>
        /// <returns>Utente loggato.</returns>
        public UserDto GetUserLogged()
        {
            return UserLogged;
        }
    }
}
