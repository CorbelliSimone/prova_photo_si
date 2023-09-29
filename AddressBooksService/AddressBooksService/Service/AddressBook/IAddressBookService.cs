using AddressBooksService.Service.AddressBook.Dto;

namespace AddressBooksService.Service.AddressBook
{
    public interface IAddressBookService
    {
        Task<AddressBookResponseDto> AddAsync(AddressBookResponseDto addressBookDto);
        Task DeleteAsync(int id);
        Task<List<AddressBookResponseDto>> GetAsync();
        Task<AddressBookResponseDto> GetAsync(int id);
        Task<int> UpdateAsync(int id, AddressBookResponseDto addressBookDto);
    }
}
