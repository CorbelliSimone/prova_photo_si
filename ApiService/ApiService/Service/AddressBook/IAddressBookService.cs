namespace ApiService.Service.AddressBook
{
    public interface IAddressBookService
    {
        Task<List<object>> GetAllAsync();
    }
}
