using AddressBooksService.Repository.AddressBook;
using AddressBooksService.Service.AddressBook.Dto;
using AddressBooksService.Service.AddressBook.Exceptionz;

using AutoMapper;

using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AddressBooksService.Service.AddressBook
{
    /// <summary>
    /// Servizio per la gestione degli AddressBook.
    /// </summary>
    public class AddressBookService : IAddressBookService
    {
        private readonly IAddressBookRepository _addressBookRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="AddressBookService"/>.
        /// </summary>
        /// <param name="addressBookRepository">Repository degli AddressBook.</param>
        /// <param name="mapper">Oggetto per il mapping tra classi.</param>
        public AddressBookService(IAddressBookRepository addressBookRepository, IMapper mapper)
        {
            _addressBookRepository = addressBookRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Aggiunge un nuovo AddressBook.
        /// </summary>
        /// <param name="addressBookDto">DTO dell'AddressBook da aggiungere.</param>
        /// <returns>Il DTO dell'AddressBook aggiunto.</returns>
        public async Task<AddressBookDto> AddAsync(AddressBookDto addressBookDto)
        {
            var addressBook = _mapper.Map<Model.AddressBook>(addressBookDto);
            await _addressBookRepository.AddAsync(addressBook);
            addressBookDto.Id = addressBook.Id;
            return addressBookDto;
        }

        /// <summary>
        /// Elimina un AddressBook dato l'ID.
        /// </summary>
        /// <param name="id">ID dell'AddressBook da eliminare.</param>
        public async Task DeleteAsync(int id)
        {
            var addressBookToDelete = await _addressBookRepository.GetAsync(id);
            if (addressBookToDelete == null)
            {
                throw new AddressBookException($"AddressBook {id} non esistente");
            }

            await _addressBookRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Ottiene tutti gli AddressBook.
        /// </summary>
        /// <returns>La lista di tutti gli AddressBook.</returns>
        public async Task<List<AddressBookDto>> GetAsync()
        {
            var addressBooks = await _addressBookRepository.GetAsync();
            return _mapper.Map<List<AddressBookDto>>(addressBooks);
        }

        /// <summary>
        /// Ottiene un AddressBook dato l'ID.
        /// </summary>
        /// <param name="id">ID dell'AddressBook da ottenere.</param>
        /// <returns>Il DTO dell'AddressBook ottenuto.</returns>
        public async Task<AddressBookDto> GetAsync(int id)
        {
            var addressBook = await _addressBookRepository.GetAsync(id);
            return _mapper.Map<AddressBookDto>(addressBook);
        }

        /// <summary>
        /// Aggiorna un AddressBook esistente.
        /// </summary>
        /// <param name="id">ID dell'AddressBook da aggiornare.</param>
        /// <param name="addressBookDto">DTO con i nuovi dati dell'AddressBook.</param>
        /// <returns>Il numero di record modificati nel database.</returns>
        public async Task<int> UpdateAsync(int id, AddressBookDto addressBookDto)
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
