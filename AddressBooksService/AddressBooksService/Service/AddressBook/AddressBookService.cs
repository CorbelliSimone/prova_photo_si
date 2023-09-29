using AddressBooksService.Repository.AddressBook;
using AddressBooksService.Service.AddressBook.Dto;
using AddressBooksService.Service.AddressBook.Exceptionz;

using AutoMapper;

using System.Runtime.InteropServices;

namespace AddressBooksService.Service.AddressBook
{
    public class AddressBookService : IAddressBookService
    {
        private readonly IAddressBookRepository _addressBookRepository;
        private readonly IMapper _mapper;

        public AddressBookService
        (
            IAddressBookRepository addressBookRepository,
            IMapper mapper
        )
        {
            this._addressBookRepository = addressBookRepository;
            this._mapper = mapper;
        }

        public async Task<AddressBookResponseDto> AddAsync(AddressBookResponseDto addressBookDto)
        {
            var addressBook = _mapper.Map<Model.AddressBook>(addressBookDto);
            await _addressBookRepository.AddAsync(addressBook);
            addressBookDto.Id = addressBook.Id;
            return addressBookDto;
        }

        public async Task DeleteAsync(int id)
        {
            var addressBookToDelete = await _addressBookRepository.GetAsync(id);
            if (addressBookToDelete == null)
            {
                throw new AddressBookException($"AddressBook {id} non esistente");
            }

            await _addressBookRepository.DeleteAsync(id);
        }

        public async Task<List<AddressBookResponseDto>> GetAsync()
        {
            var addressBooks = await _addressBookRepository.GetAsync();
            return _mapper.Map<List<AddressBookResponseDto>>(addressBooks);
        }

        public async Task<AddressBookResponseDto> GetAsync(int id)
        {
            var addressBook = await _addressBookRepository.GetAsync(id);
            return _mapper.Map<AddressBookResponseDto>(addressBook);
        }

        public async Task<int> UpdateAsync(int id, AddressBookResponseDto addressBookDto)
        {
            var addressBookToDelete = await _addressBookRepository.GetAsync(id);
            if (addressBookToDelete == null)
            {
                throw new AddressBookException($"AddressBook {id} non esistente");
            }

            addressBookToDelete.StreetNumber = addressBookDto.StreetNumber;
            addressBookToDelete.StreetName = addressBookDto.StreetName;
            addressBookToDelete.Cap = addressBookDto.Cap;
            addressBookToDelete.CityId = addressBookDto.CityId;

            return await _addressBookRepository.SaveAsync();
        }
    }
}
