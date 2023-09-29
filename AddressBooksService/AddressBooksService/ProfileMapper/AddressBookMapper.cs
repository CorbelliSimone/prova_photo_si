using AddressBooksService.Model;
using AddressBooksService.Service.AddressBook.Dto;

using AutoMapper;

namespace AddressBooksService.ProfileMapper
{
    public class AddressBookMapper : Profile
    {
        public AddressBookMapper()
        {
            CreateMap<AddressBook, AddressBookResponseDto>()
                .ReverseMap()
                ; // Mappa Product a ProductDto
        }
    }
}
