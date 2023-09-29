using ApiService.Service.AddressBook;

using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/v1/address-book")]
    [ApiController]
    public class AddressBookController : BaseApiController
    {
        private readonly IAddressBookService _addressBookService;

        public AddressBookController
        (
            IAddressBookService addressBookService,
            UserLoggedHandler userLoggedHandler
        ) : base(userLoggedHandler)
        {
            this._addressBookService = addressBookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _addressBookService.GetAllAsync());
    }
}
