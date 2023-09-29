namespace ApiService.Service.AddressBook.Httpz
{
    public interface IAddressBookHttpClient
    {
        Task<List<object>> GetAllAsync();
    }
}
