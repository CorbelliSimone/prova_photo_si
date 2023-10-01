using ApiService.Service.User.Dto;

namespace ApiService.Service.User
{
    /// <summary>
    /// Interfaccia per il servizio utente che definisce operazioni comuni sugli utenti.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Aggiorna un utente esistente.
        /// </summary>
        /// <param name="id">L'ID dell'utente da aggiornare.</param>
        /// <param name="userDto">I dati dell'utente aggiornati.</param>
        /// <returns>Task che rappresenta l'operazione di aggiornamento.</returns>
        Task<object> UpdateAsync(int id, object userDto);

        /// <summary>
        /// Elimina un utente.
        /// </summary>
        /// <param name="id">L'ID dell'utente da eliminare.</param>
        /// <returns>Task che rappresenta l'operazione di eliminazione.</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Ottiene tutti gli utenti.
        /// </summary>
        /// <returns>Task che restituisce la lista degli utenti.</returns>
        Task<List<UserDto>> GetAsync();

        /// <summary>
        /// Ottiene un utente per ID.
        /// </summary>
        /// <param name="id">L'ID dell'utente da recuperare.</param>
        /// <returns>Task che restituisce l'utente corrispondente all'ID.</returns>
        Task<UserDto> GetAsync(int id);

        /// <summary>
        /// Aggiunge un nuovo utente.
        /// </summary>
        /// <param name="user">I dati dell'utente da aggiungere.</param>
        /// <returns>Task che restituisce l'utente aggiunto.</returns>
        Task<UserDto> AddAsync(UserDto user);

        /// <summary>
        /// Esegue il login per un utente.
        /// </summary>
        /// <param name="id">L'ID dell'utente per il login.</param>
        /// <returns>Task che rappresenta l'operazione di login.</returns>
        Task<UserDto> LoginAsync(int id);
    }
}
