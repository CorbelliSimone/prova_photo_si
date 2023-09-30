using AddressBooksService.Model;

namespace AddressBooksService.Repository.AddressBook
{
    /// <summary>
    /// Implementazione del repository per la gestione delle operazioni sulle entità di AddressBook.
    /// </summary>
    public class AddressBookRepository : GenericRepository<Model.AddressBook>, IAddressBookRepository
    {
        /// <summary>
        /// Crea un'istanza del repository di AddressBook.
        /// </summary>
        /// <param name="context">Il contesto del database.</param>
        public AddressBookRepository(Context context) : base(context)
        {
        }
    }
}
