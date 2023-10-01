using ApiService.Service.User.Dto;
using ApiService.Service.User.Exceptionz;
using ApiService.Service.User.Httpz;

namespace ApiService.Service.User
{
    /// <summary>
    /// Servizio per la gestione degli utenti.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserHttpClient _userHttpClient;

        public UserService
        (
            IUserHttpClient userHttpClient
        )
        {
            _userHttpClient = userHttpClient;
        }

        /// <summary>
        /// Ottiene la lista degli utenti in modo asincrono.
        /// </summary>
        /// <returns>La lista degli utenti.</returns>
        public Task<List<UserDto>> GetAsync()
        {
            return _userHttpClient.Get<List<UserDto>>(string.Empty);
        }

        /// <summary>
        /// Effettua il login di un utente in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'utente.</param>
        /// <returns>I dettagli dell'utente loggato.</returns>
        public async Task<UserDto> LoginAsync(int id)
        {
            var userToLog = await _userHttpClient.Get<UserDto>($"{id}");
            if (userToLog == null)
            {
                throw new UserException($"Utente {id} non esistente");
            }
            return userToLog;
        }


        /// <summary>
        /// Ottiene i dettagli di un utente in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'utente da recuperare.</param>
        /// <returns>I dettagli dell'utente.</returns>
        public Task<UserDto> GetAsync(int id)
        {
            return _userHttpClient.Get<UserDto>($"{id}");
        }

        /// <summary>
        /// Aggiunge un nuovo utente in modo asincrono.
        /// </summary>
        /// <param name="user">I dettagli del nuovo utente.</param>
        /// <returns>I dettagli del nuovo utente aggiunto.</returns>
        public Task<UserDto> AddAsync(UserDto user)
        {
            return _userHttpClient.Post<UserDto>(string.Empty, user);
        }

        /// <summary>
        /// Elimina un utente in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'utente da eliminare.</param>
        /// <returns>True se l'eliminazione ha avuto successo, altrimenti false.</returns>
        public Task<bool> DeleteAsync(int id)
        {
            return _userHttpClient.Delete($"{id}");
        }

        /// <summary>
        /// Aggiorna i dettagli di un utente in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'utente da aggiornare.</param>
        /// <param name="userDto">I nuovi dettagli dell'utente.</param>
        /// <returns>Il risultato dell'operazione di aggiornamento.</returns>
        public Task<object> UpdateAsync(int id, object userDto)
        {
            return _userHttpClient.Put($"{id}", userDto);
        }
    }
}
