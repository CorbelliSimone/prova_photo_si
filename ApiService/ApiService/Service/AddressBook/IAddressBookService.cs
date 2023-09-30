namespace ApiService.Service.AddressBook
{
    public interface IAddressBookService
    {
        Task<bool> Delete(int id);
        Task<object> Get(int id);
        Task<List<object>> Get();
        Task<object> Post(object addressBookDto);
        Task<object> Put(int id, object addressBookDto);
    }
}
