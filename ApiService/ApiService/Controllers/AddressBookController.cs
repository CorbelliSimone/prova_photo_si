using ApiService.Service.AddressBook;
using ApiService.Service.AddressBook.Exceptionz;
using ApiService.Service.User.Cache;

using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
// sium
    /// <summary>
    /// Controller per gestire le operazioni relative all'indirizzario.
    /// </summary>
    [Route("api/v1/address-book")]
    [ApiController]
    public class AddressBookController : BaseApiController
    {
        private readonly IAddressBookService _addressBookService;

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="AddressBookController"/>.
        /// </summary>
        /// <param name="addressBookService">Servizio per la gestione dell'indirizzario.</param>
        /// <param name="userLoggedHandler">Handler per l'utente loggato.</param>
        public AddressBookController
        (
            IAddressBookService addressBookService,
            IUserLoggedHandler userLoggedHandler
        ) : base(userLoggedHandler)
        {
            _addressBookService = addressBookService;
        }

        /// <summary>
        /// Ottiene tutti gli indirizzi.
        /// </summary>
        /// <returns>Risposta HTTP con gli indirizzi.</returns>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _addressBookService.Get());

        /// <summary>
        /// Ottiene un indirizzo per ID.
        /// </summary>
        /// <param name="id">ID dell'indirizzo.</param>
        /// <returns>Risposta HTTP con l'indirizzo corrispondente all'ID specificato.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _addressBookService.Get(id));

        /// <summary>
        /// Elimina un indirizzo.
        /// </summary>
        /// <param name="id">ID dell'indirizzo da eliminare.</param>
        /// <returns>Risposta HTTP che indica l'esito dell'operazione di eliminazione.</returns>
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

        /// <summary>
        /// Aggiorna un indirizzo.
        /// </summary>
        /// <param name="id">ID dell'indirizzo da aggiornare.</param>
        /// <param name="addressBookDto">Dati dell'indirizzo da aggiornare.</param>
        /// <returns>Risposta HTTP con l'indirizzo aggiornato.</returns>
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

        /// <summary>
        /// Crea un nuovo indirizzo.
        /// </summary>
        /// <param name="addressBookDto">Dati del nuovo indirizzo.</param>
        /// <returns>Risposta HTTP con l'indirizzo creato.</returns>
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
