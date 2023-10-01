using ApiService.Service.User.Dto;

namespace ApiService.Service.User.Cache
{
    /// <summary>
    /// Interfaccia per gestire l'utente loggato.
    /// </summary>
    public interface IUserLoggedHandler
    {
        /// <summary>
        /// Imposta l'utente loggato.
        /// </summary>
        /// <param name="userLogged">Utente loggato da impostare.</param>
        void SetUserLogged(UserDto userLogged);

        /// <summary>
        /// Ottiene l'utente loggato.
        /// </summary>
        /// <returns>Utente loggato.</returns>
        UserDto GetUserLogged();
    }
}
