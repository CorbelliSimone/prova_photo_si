using ApiService.Service.Order;
using ApiService.Service.Order.Dto;
using ApiService.Service.Order.Exceptionz;
using ApiService.Service.User.Cache;

using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    /// <summary>
    /// Controller per gestire le operazioni relative agli ordini.
    /// </summary>
    [Route("api/v1/order")]
    [ApiController]
    public class OrderController : BaseApiController
    {
        private readonly IOrderService _orderService;

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="OrderController"/>.
        /// </summary>
        /// <param name="userLoggedHandler">Handler per l'utente loggato.</param>
        /// <param name="orderService">Servizio per la gestione degli ordini.</param>
        public OrderController(IUserLoggedHandler userLoggedHandler, IOrderService orderService)
            : base(userLoggedHandler)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Ottiene tutti gli ordini.
        /// </summary>
        /// <returns>Risposta HTTP con gli ordini.</returns>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _orderService.GetAsync());

        /// <summary>
        /// Ottiene un ordine per ID.
        /// </summary>
        /// <param name="id">ID dell'ordine.</param>
        /// <returns>Risposta HTTP con l'ordine corrispondente all'ID specificato.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _orderService.GetAsync(id));

        /// <summary>
        /// Elimina un ordine.
        /// </summary>
        /// <param name="id">ID dell'ordine da eliminare.</param>
        /// <returns>Risposta HTTP che indica l'esito dell'operazione di eliminazione.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _orderService.DeleteAsync(id));

        /// <summary>
        /// Effettua un nuovo ordine.
        /// </summary>
        /// <param name="orderDto">Dati del nuovo ordine.</param>
        /// <returns>Risposta HTTP con l'ordine creato.</returns>
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderDto)
        {
            // Controllo se l'utente è loggato
            if (_userLoggedHandler.GetUserLogged() == null)
            {
                return Unauthorized("Prima di piazzare un ordine bisogna fare il login api/v1/user");
            }

            // Controllo sulle informazioni dell'ordine
            if (orderDto.Products == null || orderDto.Products.Count == 0)
            {
                return BadRequest("Nessun prodotto associato all'ordine");
            }

            if (orderDto.AddressId < 1)
            {
                return BadRequest($"Id {orderDto.AddressId} indirizzo non valido");
            }

            try
            {
                // Assegna l'ID dell'utente all'ordine e effettua il piazzamento
                orderDto.UserId = _userLoggedHandler.GetUserLogged().Id;
                var placedOrder = await _orderService.PlaceOrder(orderDto);
                return Created("", placedOrder);
            }
            catch (OrderException e)
            {
                return BadRequest($"Errore piazzamento ordine {e.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Errore nel piazzare l'ordine {e.Message}");
            }
        }
    }
}
