using Microsoft.AspNetCore.Mvc;

using UsersService.Service.User;
using UsersService.Service.User.Dto;
using UsersService.Service.User.Exceptionz;

namespace UsersService.Controllers
{
    /// <summary>
    /// Controller per la gestione degli utenti.
    /// </summary>
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="UserController"/>.
        /// </summary>
        /// <param name="userService">Servizio degli utenti.</param>
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        /// <summary>
        /// Ottiene tutti gli utenti.
        /// </summary>
        /// <returns>Un'azione HTTP che rappresenta l'operazione di ottenere tutti gli utenti.</returns>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _userService.GetAsync());

        /// <summary>
        /// Ottiene un utente per ID.
        /// </summary>
        /// <param name="id">L'ID dell'utente.</param>
        /// <returns>Un'azione HTTP che rappresenta l'operazione di ottenere un utente.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Id non valido {id}");
            }

            UserDto userDto = await _userService.GetAsync(id);
            return userDto == null ? NoContent() : Ok(userDto);
        }

        /// <summary>
        /// Aggiunge un nuovo utente.
        /// </summary>
        /// <param name="userDto">I dettagli dell'utente da aggiungere.</param>
        /// <returns>Un'azione HTTP che rappresenta l'operazione di aggiungere un utente.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Utente per inserimento arrivato nullo");
            }

            try
            {
                var createdResource = await _userService.AddAsync(userDto);
                return Created("", createdResource);
            }
            catch (UserException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Modifica l'indirizzo associato a un utente specificato.
        /// </summary>
        /// <param name="id">ID dell'utente.</param>
        /// <param name="addressId">ID dell'indirizzo da associare all'utente.</param>
        /// <returns>
        /// Risposta HTTP che indica l'esito dell'operazione.
        /// </returns>
        [HttpPut("{id}/{addressId}")]
        public async Task<IActionResult> UpdateAddressAsync(int id, int addressId)
        {
            if (id < 1)
            {
                return BadRequest($"Utente {id} non esistente");
            }

            if (addressId < 1)
            {
                return BadRequest($"AddressId {addressId} non valido");
            }

            try
            {
                var createdResource = await _userService.UpdateAddressAsync(id, addressId);
                return Created("", createdResource);
            }
            catch (UserException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Aggiorna un utente.
        /// </summary>
        /// <param name="id">L'ID dell'utente.</param>
        /// <param name="userDto">I nuovi dettagli dell'utente.</param>
        /// <returns>Un'azione HTTP che rappresenta l'operazione di aggiornare un utente.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDto userDto)
        {
            if (id < 1)
            {
                return BadRequest($"Id non valido{id}");
            }

            if (userDto == null)
            {
                return BadRequest("Utente arrivato nullo");
            }

            try
            {
                int saveStatus = await _userService.UpdateAsync(id, userDto);
                return Ok($"Utente {id} aggiornato con successo {saveStatus}");
            }
            catch (UserException e)
            {
                return BadRequest($"Errore eliminazione utente {e.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Errore aggiornato Utente: {id} {e.Message}");
            }
        }

        /// <summary>
        /// Elimina un utente.
        /// </summary>
        /// <param name="id">L'ID dell'utente da eliminare.</param>
        /// <returns>Un'azione HTTP che rappresenta l'operazione di eliminare un utente.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Id non valido{id}");
            }

            try
            {
                await _userService.DeleteAsync(id);
                return Ok($"Utente {id} eliminato con successo");
            }
            catch (UserException e)
            {
                return BadRequest($"Errore eliminazione utente {e.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Errore richiesta id: {id} {e.Message}");
            }
        }
    }
}
