using ApiService.Service.Httpz;
using ApiService.Service.User;
using ApiService.Service.User.Cache;
using ApiService.Service.User.Dto;
using ApiService.Service.User.Exceptionz;

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

        public UserController(IUserService userService, IUserLoggedHandler userLoggedHandler)
            : base(userLoggedHandler)
        {
            _userService = userService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _userService.DeleteAsync(id));

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _userService.GetAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _userService.GetAsync(id));

        // Simula la registrazione di un utente
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
                return Ok($"Utente creato {createdUser.Username} con id {createdUser.Id}, puoi usare l'id per eseguire il login");
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

        // Modifica l'indirizzo
        [HttpPut("address/{addressId}")]
        public async Task<IActionResult> AddAddressAsync(int addressId)
        {
            if (_userLoggedHandler.GetUserLogged() == null)
            {
                return Unauthorized("Prima di associare un indirizzo bisogna effettuare il login api/v1/user/");
            }

            try
            {
                var insertedAddressId = await _userService.UpdateAddressAsync(addressId, _userLoggedHandler.GetUserLogged().Id);
                return Created("", insertedAddressId);
            }
            catch (UserException e)
            {
                return BadRequest($"Errore aggiornamento AddressBook {e.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
