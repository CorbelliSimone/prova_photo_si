using ApiService.Service.AddressBook.Exceptionz;
using ApiService.Service.AddressBook.Httpz;
using ApiService.Service.User.Dto;
using ApiService.Service.User.Httpz;

namespace ApiService.Service.AddressBook
{
    public class AddressBookService : IAddressBookService
    {
        private readonly IAddressBookHttpClient _addressBookHttpClient;
        private readonly IUserHttpClient _userHttpClient;

        public AddressBookService
        (
            IAddressBookHttpClient addressBookHttpClient,
            IUserHttpClient userHttpClient
        )
        {
            _userHttpClient = userHttpClient;
            _addressBookHttpClient = addressBookHttpClient;
        }

        public async Task<bool> Delete(int id)
        {
            // Se elimino un indirizzo devo eliminare quelli associati agli utenti
            try
            {
                var users = await _userHttpClient.GetByAddressId<List<UserDto>>(id);
                foreach (var user in users)
                {
                    var disassociateAddres = (bool)(await _userHttpClient.UpdateAddressId(user.Id, -1));
                    if (!disassociateAddres)
                    {
                        throw new AddressBookException($"Non sono riuscito a disassociare l'address id all'utente {disassociateAddres}");
                    }
                }
            }
            catch (Exception e)
            {
                throw new AddressBookException($"Errore disassociazione address all'user {e.Message}");
            }

            return await _addressBookHttpClient.Delete($"{id}");
        }

        public Task<List<object>> Get()
        {
            return _addressBookHttpClient.Get<List<object>>(string.Empty);
        }

        public Task<object> Get(int id)
        {
            return _addressBookHttpClient.Get<object>($"{id}");
        }

        public Task<object> Post(object addressBookDto)
        {
            return _addressBookHttpClient.Post<object>(string.Empty, addressBookDto);
        }

        public Task<object> Put(int id, object addressBookDto)
        {
            return _addressBookHttpClient.Put($"{id}", addressBookDto);
        }
    }
}
