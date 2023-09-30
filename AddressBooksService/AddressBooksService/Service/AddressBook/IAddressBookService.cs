using AddressBooksService.Service.AddressBook.Dto;

namespace AddressBooksService.Service.AddressBook
{
    public interface IAddressBookService
    {
        Task<AddressBookDto> AddAsync(AddressBookDto addressBookDto);
        Task DeleteAsync(int id);
        Task<List<AddressBookDto>> GetAsync();
        Task<AddressBookDto> GetAsync(int id);
        Task<int> UpdateAsync(int id, AddressBookDto addressBookDto);
    }
}
