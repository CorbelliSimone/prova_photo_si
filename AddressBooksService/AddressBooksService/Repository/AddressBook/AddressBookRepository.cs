using AddressBooksService.Model;

namespace AddressBooksService.Repository.AddressBook
{
    public class AddressBookRepository : GenericRepository<Model.AddressBook>, IAddressBookRepository
    {
        public AddressBookRepository(Context context) : base(context)
        {
        }
    }
}
