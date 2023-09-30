using ApiService.Service.Httpz;
using ApiService.Service.User;
using ApiService.Service.User.Cache;
using ApiService.Service.User.Dto;

using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    /// <summary>
    /// Simula 
    /// </summary>
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, UserLoggedHandler userLoggedHandler)
            : base(userLoggedHandler)
        {
            _userService = userService;
        }

        // Simula la registrazione di un utente
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(UserDto userLogged)
        {
            if (userLogged == null)
            {
                return BadRequest("Oggetto per la registrazione utente arrivato nullo");
            }

            try
            {
                var createdUser = await _userService.Register(userLogged);
                return Ok($"Utente creato {createdUser.Username} con id {createdUser.Id}, puoi usare l'id per eseguire il login");
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
        [HttpPost("{id}")]
        public async Task<IActionResult> LoginAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Impossibile loggarsi con id minore di 1 {id}");
            }

            try
            {
                var userForLogged = await _userService.Login(id);
                _userLoggedHandler.SetUserLogged(userForLogged);
                return Ok($"Utente {id} loggato con successo");
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

        [HttpPost("address/{addressId}")]
        public async Task<IActionResult> AddAddressAsync(int addressId)
        {
            if (_userLoggedHandler.UserLogged == null)
            {
                return Unauthorized("Prima di associare un indirizzo bisogna effettuare il login");
            }

            try
            {
                var insertedAddressId = await _userService.AddAddressAsync(addressId, _userLoggedHandler.UserLogged.Id);
                return Created("", insertedAddressId);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
