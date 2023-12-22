namespace ApiService.Service.AddressBook
{
    /// <summary>
    /// Interfaccia per il servizio di gestione dell'address book.
    /// </summary>
    public interface IAddressBookService
    {
        //
        /// <summary>
        /// Elimina un indirizzo.
        /// </summary>
        /// <param name="id">ID dell'indirizzo da eliminare.</param>
        /// <returns>True se l'eliminazione è avvenuta con successo, altrimenti False.</returns>
        Task<bool> Delete(int id);

        /// <summary>
        /// Ottiene un indirizzo per ID.
        /// </summary>
        /// <param name="id">ID dell'indirizzo.</param>
        /// <returns>L'indirizzo corrispondente all'ID specificato.</returns>
        Task<object> Get(int id);

        /// <summary>
        /// Ottiene tutti gli indirizzi.
        /// </summary>
        /// <returns>Lista degli indirizzi.</returns>
        Task<List<object>> Get();

        /// <summary>
        /// Crea un nuovo indirizzo.
        /// </summary>
        /// <param name="addressBookDto">Dati del nuovo indirizzo.</param>
        /// <returns>L'indirizzo creato.</returns>
        Task<object> Post(object addressBookDto);

        /// <summary>
        /// Aggiorna un indirizzo.
        /// </summary>
        /// <param name="id">ID dell'indirizzo da aggiornare.</param>
        /// <param name="addressBookDto">Dati dell'indirizzo da aggiornare.</param>
        /// <returns>L'indirizzo aggiornato.</returns>
        Task<object> Put(int id, object addressBookDto);
    }
}
