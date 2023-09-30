namespace AddressBooksService.Repository.AddressBook
{
    /// <summary>
    /// Interfaccia per il repository delle operazioni sulle entità di AddressBook.
    /// Estende l'interfaccia generica IGenericRepository per la gestione delle operazioni CRUD.
    /// </summary>
    public interface IAddressBookRepository : IGenericRepository<Model.AddressBook>
    {
    }
}
