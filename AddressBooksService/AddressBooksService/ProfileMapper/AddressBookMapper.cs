using AddressBooksService.Model;
using AddressBooksService.Service.AddressBook.Dto;

using AutoMapper;

namespace AddressBooksService.ProfileMapper
{
    /// <summary>
    /// Classe per il mapping tra la classe AddressBook e AddressBookDto.
    /// </summary>
    public class AddressBookMapper : Profile
    {
        /// <summary>
        /// Crea un'istanza della classe AddressBookMapper.
        /// </summary>
        public AddressBookMapper()
        {
            CreateMap<AddressBook, AddressBookDto>()
                .ReverseMap();
        }
    }
}
