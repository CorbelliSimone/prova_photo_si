using AddressBooksService.Service.AddressBook;
using AddressBooksService.Service.AddressBook.Dto;
using AddressBooksService.Service.AddressBook.Exceptionz;

using Microsoft.AspNetCore.Mvc;

namespace AddressBooksService.Controllers
{
    [Route("api/v1/address-book")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookService _addressBookService;

        public AddressBookController(IAddressBookService addressBookService)
        {
            this._addressBookService = addressBookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _addressBookService.GetAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Id non valido {id}");
            }

            var productDto = await _addressBookService.GetAsync(id);
            return productDto == null ? NoContent() : Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddressBookResponseDto addressBookDto)
        {
            if (addressBookDto == null)
            {
                return BadRequest("AddressBook per inserimento arrivato nullo");
            }

            try
            {
                var createdResource = await _addressBookService.AddAsync(addressBookDto);
                return Created("", createdResource);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddressBookResponseDto addressBookDto)
        {
            if (id < 1)
            {
                return BadRequest($"Id non valido{id}");
            }

            if (addressBookDto == null)
            {
                return BadRequest("AddressBook arrivato nullo");
            }

            try
            {
                int saveStatus = await _addressBookService.UpdateAsync(id, addressBookDto);
                return Ok($"AddressBook {id} aggiornato con successo {saveStatus}");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Errore aggiornato AddressBook: {id} {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Id non valido{id}");
            }

            try
            {
                await _addressBookService.DeleteAsync(id);
                return Ok($"AddressBook {id} eliminato con successo");
            }
            catch(AddressBookException e)
            {
                return BadRequest($"Errore eliminazione userbook {id} {e.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Errore richiesta id: {id} {e.Message}");
            }
        }
    }
}