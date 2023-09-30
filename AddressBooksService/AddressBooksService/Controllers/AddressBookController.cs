using AddressBooksService.Service.AddressBook;
using AddressBooksService.Service.AddressBook.Dto;
using AddressBooksService.Service.AddressBook.Exceptionz;

using Microsoft.AspNetCore.Mvc;

namespace AddressBooksService.Controllers
{
    /// <summary>
    /// Controller per gestire le operazioni relative agli indirizzi.
    /// </summary>
    [Route("api/v1/address-book")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookService _addressBookService;

        public AddressBookController(IAddressBookService addressBookService)
        {
            this._addressBookService = addressBookService;
        }

        /// <summary>
        /// Ottiene tutti gli elementi dell'elenco degli indirizzi.
        /// </summary>
        /// <returns>Un'azione HTTP che restituisce un elenco di elementi di AddressBookDto.</returns>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _addressBookService.GetAsync());

        /// <summary>
        /// Ottiene un elemento dell'elenco degli indirizzi in base all'ID.
        /// </summary>
        /// <param name="id">L'ID dell'elemento da ottenere.</param>
        /// <returns>Un'azione HTTP che restituisce l'elemento AddressBookDto corrispondente all'ID specificato.</returns>
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

        /// <summary>
        /// Aggiunge un nuovo elemento all'elenco degli indirizzi.
        /// </summary>
        /// <param name="addressBookDto">L'oggetto AddressBookDto da aggiungere.</param>
        /// <returns>Un'azione HTTP che restituisce un nuovo elemento AddressBookDto creato.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddressBookDto addressBookDto)
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

        /// <summary>
        /// Aggiorna un elemento dell'elenco degli indirizzi in base all'ID.
        /// </summary>
        /// <param name="id">L'ID dell'elemento da aggiornare.</param>
        /// <param name="addressBookDto">L'oggetto AddressBookDto con i nuovi dati.</param>
        /// <returns>Un'azione HTTP che indica l'esito dell'operazione di aggiornamento.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddressBookDto addressBookDto)
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

        /// <summary>
        /// Elimina un elemento dell'elenco degli indirizzi in base all'ID.
        /// </summary>
        /// <param name="id">L'ID dell'elemento da eliminare.</param>
        /// <returns>Un'azione HTTP che indica l'esito dell'operazione di eliminazione.</returns>
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
            catch (AddressBookException e)
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
