using AddressBooksService.Service.AddressBook.Dto;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBooksService.Service.AddressBook
{
    /// <summary>
    /// Interfaccia per il servizio di gestione degli AddressBook.
    /// </summary>
    public interface IAddressBookService
    {
        /// <summary>
        /// Aggiunge un nuovo AddressBook.
        /// </summary>
        /// <param name="addressBookDto">DTO dell'AddressBook da aggiungere.</param>
        /// <returns>Il DTO dell'AddressBook aggiunto.</returns>
        Task<AddressBookDto> AddAsync(AddressBookDto addressBookDto);

        /// <summary>
        /// Elimina un AddressBook dato l'ID.
        /// </summary>
        /// <param name="id">ID dell'AddressBook da eliminare.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Ottiene tutti gli AddressBook.
        /// </summary>
        /// <returns>La lista di tutti gli AddressBook.</returns>
        Task<List<AddressBookDto>> GetAsync();

        /// <summary>
        /// Ottiene un AddressBook dato l'ID.
        /// </summary>
        /// <param name="id">ID dell'AddressBook da ottenere.</param>
        /// <returns>Il DTO dell'AddressBook ottenuto.</returns>
        Task<AddressBookDto> GetAsync(int id);

        /// <summary>
        /// Aggiorna un AddressBook esistente.
        /// </summary>
        /// <param name="id">ID dell'AddressBook da aggiornare.</param>
        /// <param name="addressBookDto">DTO con i nuovi dati dell'AddressBook.</param>
        /// <returns>Il numero di record modificati nel database.</returns>
        Task<int> UpdateAsync(int id, AddressBookDto addressBookDto);
    }
}
