using ApiService.Service.Httpz;
using ApiService.Service.User;
using ApiService.Service.User.Cache;
using ApiService.Service.User.Dto;
using ApiService.Service.User.Exceptionz;

using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    /// <summary>
    /// Controller per gestire le operazioni relative agli utenti.
    /// </summary>
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="UserController"/>.
        /// </summary>
        /// <param name="userService">Servizio per la gestione degli utenti.</param>
        /// <param name="userLoggedHandler">Handler per l'utente loggato.</param>
        public UserController(IUserService userService, IUserLoggedHandler userLoggedHandler)
            : base(userLoggedHandler)
        {
            _userService = userService;
        }

        /// <summary>
        /// Elimina un utente per ID.
        /// </summary>
        /// <param name="id">ID dell'utente da eliminare.</param>
        /// <returns>Risposta HTTP che indica l'esito dell'operazione di eliminazione.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _userService.DeleteAsync(id));

        /// <summary>
        /// Ottiene tutti gli utenti.
        /// </summary>
        /// <returns>Risposta HTTP con gli utenti.</returns>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _userService.GetAsync());

        /// <summary>
        /// Ottiene un utente per ID.
        /// </summary>
        /// <param name="id">ID dell'utente.</param>
        /// <returns>Risposta HTTP con l'utente corrispondente all'ID specificato.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _userService.GetAsync(id));

        // Simula la registrazione di un utente
        /// <summary>
        /// Registra un nuovo utente.
        /// </summary>
        /// <param name="userDto">Dati del nuovo utente.</param>
        /// <returns>Risposta HTTP con l'utente creato.</returns>
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Oggetto per la registrazione utente arrivato nullo");
            }

            try
            {
                var createdUser = await _userService.AddAsync(userDto);
                return Ok($"Utente creato {createdUser.Username} con id {createdUser.Id}, puoi usare l'id per eseguire il login /api/v1/user");
            }
            catch (UserException e)
            {
                return BadRequest($"Errore registrazione utente {e.Message}");
            }
            catch (BaseHttpClientException e)
            {
                return BadRequest($"Errore registrazione utente {e.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Errore generico registrazione utente {e.Message}");
            }
        }

        // Simula il login
        /// <summary>
        /// Esegue il login di un utente.
        /// </summary>
        /// <param name="id">ID dell'utente.</param>
        /// <returns>Risposta HTTP che indica l'esito del login.</returns>
        [HttpPost("{id}")]
        public async Task<IActionResult> LoginAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Impossibile loggarsi con id minore di 1 {id}");
            }

            try
            {
                var userForLogged = await _userService.LoginAsync(id);
                _userLoggedHandler.SetUserLogged(userForLogged);
                return Ok($"Utente {id} loggato con successo");
            }
            catch (UserException e)
            {
                return BadRequest($"Errore login utente {e.Message}");
            }
            catch (BaseHttpClientException e)
            {
                return BadRequest($"Errore login utente {e.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Errore generico login utente {e.Message}");
            }
        }

        // Modifa l'utente
        /// <summary>
        /// Modifica un utente.
        /// </summary>
        /// <param name="id">ID dell'utente da modificare.</param>
        /// <param name="userDto">Dati dell'utente da modificare.</param>
        /// <returns>Risposta HTTP con l'utente modificato.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, object userDto)
        {
            if (id < 1)
            {
                return BadRequest($"Impossibile loggarsi con id minore di 1 {id}");
            }

            if (userDto == null)
            {
                return BadRequest($"");
            }

            return Ok(await _userService.UpdateAsync(id, userDto));
        }
    }
}
