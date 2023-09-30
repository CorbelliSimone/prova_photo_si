using System.Collections.Generic;
using System.Threading.Tasks;

using UsersService.Service.User.Dto;

namespace UsersService.Service.User
{
    /// <summary>
    /// Interfaccia per il servizio degli utenti.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Aggiunge un nuovo utente.
        /// </summary>
        /// <param name="userDto">DTO dell'utente da aggiungere.</param>
        /// <returns>Il DTO dell'utente aggiunto.</returns>
        Task<UserDto> AddAsync(UserDto userDto);

        /// <summary>
        /// Elimina un utente.
        /// </summary>
        /// <param name="id">L'ID dell'utente da eliminare.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Aggiorna l'indirizzo di un utente.
        /// </summary>
        /// <param name="id">L'ID dell'utente da aggiornare.</param>
        /// <param name="addressId">L'ID dell'indirizzo da associare all'utente.</param>
        /// <returns>L'esito dell'aggiornamento.</returns>
        Task<int> UpdateAddressAsync(int id, int addressId);

        /// <summary>
        /// Ottiene un utente in base all'ID.
        /// </summary>
        /// <param name="id">L'ID dell'utente da ottenere.</param>
        /// <returns>Il DTO dell'utente.</returns>
        Task<UserDto> GetAsync(int id);

        /// <summary>
        /// Ottiene la lista degli utenti.
        /// </summary>
        /// <returns>La lista dei DTO degli utenti.</returns>
        Task<List<UserDto>> GetAsync();

        /// <summary>
        /// Aggiorna un utente esistente.
        /// </summary>
        /// <param name="id">L'ID dell'utente da aggiornare.</param>
        /// <param name="userDto">Il DTO dell'utente con le informazioni aggiornate.</param>
        /// <returns>L'esito dell'aggiornamento.</returns>
        Task<int> UpdateAsync(int id, UserDto userDto);
    }
}
