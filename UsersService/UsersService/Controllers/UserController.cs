using Microsoft.AspNetCore.Mvc;

using UsersService.Service.User;
using UsersService.Service.User.Dto;
using UsersService.Service.User.Exceptionz;

namespace UsersService.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _userService.GetAsync());

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Utente per inserimento arrivato nullo");
            }

            try
            {
                UserDto createdResource = await _userService.AddAsync(userDto);
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
