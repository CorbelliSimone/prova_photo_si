using ApiService.Service.AddressBook;
using ApiService.Service.AddressBook.Exceptionz;
using ApiService.Service.User.Cache;

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
            IUserLoggedHandler userLoggedHandler
        ) : base(userLoggedHandler)
        {
            _addressBookService = addressBookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _addressBookService.Get());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _addressBookService.Get(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest($"Id indirizzo non puo' essere minore di 1 {id}");
            }

            try
            {
                return Ok(await _addressBookService.Delete(id));
            }
            catch (AddressBookException e)
            {
                return BadRequest($"Errore eliminazione indirizzo {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] object addressBookDto)
        {
            if (id < 1)
            {
                return BadRequest($"Id {id} minore di 1 non ammissible");
            }

            if (addressBookDto == null)
            {
                return BadRequest("Dati indirizzo arrivati nulli");
            }

            try
            {
                var modified = await _addressBookService.Put(id, addressBookDto);
                return Ok(modified);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Errore nel salvataggio dell'indirizzo {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object addressBookDto)
        {
            if (addressBookDto == null)
            {
                return BadRequest("Dati indirizzo arrivati nulli");
            }

            try
            {
                var savedAddress = await _addressBookService.Post(addressBookDto);
                return Created("", savedAddress);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Errore nel salvataggio dell'indirizzo {e.Message}");
            }
        }
    }
}
