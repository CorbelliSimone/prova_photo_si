using Microsoft.AspNetCore.Mvc;

using OrdersService.Service.Order;
using OrdersService.Service.Order.Dto;
using OrdersService.Service.Order.Exceptionz;

namespace OrdersService.Controllers
{
    /// <summary>
    /// Controller per la gestione degli ordini.
    /// </summary>
    [Route("api/v1/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        /// <summary>
        /// Crea una nuova istanza della classe OrderController.
        /// </summary>
        /// <param name="orderService">Un'istanza del servizio IOrderService utilizzato per la gestione degli ordini.</param>
        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            if (productId < 1)
            {
                return BadRequest($"ProductId {productId} non valido");
            }

            return Ok(await _orderService.GetByProductIdAsync(productId));
        }

        [HttpGet("address/{addressId}")]
        public async Task<IActionResult> GetByAddressId(int addressId)
        {
            if (addressId < 1)
            {
                return BadRequest($"AddressId {addressId} non valido");
            }

            return Ok(await _orderService.GetByAddressIdAsync(addressId));
        }

        /// <summary>
        /// Restituisce tutti gli ordini.
        /// </summary>
        /// <returns>Un'azione che restituisce un oggetto IActionResult che rappresenta il risultato della richiesta HTTP.</returns>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _orderService.GetAsync());

        /// <summary>
        /// Restituisce un ordine specificato per ID.
        /// </summary>
        /// <param name="id">L'ID dell'ordine da recuperare.</param>
        /// <returns>Un'azione che restituisce un oggetto IActionResult che rappresenta il risultato della richiesta HTTP.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _orderService.GetAsync(id));

        /// <summary>
        /// Piazza un nuovo ordine.
        /// </summary>
        /// <param name="orderDto">L'oggetto OrderDto che rappresenta i dati dell'ordine da piazzare.</param>
        /// <returns>Un'azione che restituisce un oggetto IActionResult che rappresenta il risultato della richiesta HTTP.</returns>
        [HttpPost]
        public async Task<IActionResult> PlaceOrderAsync([FromBody] OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest($"Ordine da piazzare arrivato nullo");
            }

            if (orderDto.AddressId < 1)
            {
                return BadRequest($"Non posso piazzare un ordine con id address minore di 1 {orderDto.AddressId}");
            }

            if (orderDto.UserId < 1)
            {
                return BadRequest($"Non posso piazzare un ordine con un utente minore di 1 {orderDto.UserId}");
            }

            if (orderDto.Products == null || orderDto.Products.Count == 0)
            {
                return BadRequest($"Nessun prodotto associabile all'ordine da piazzare");
            }

            try
            {
                var placedOrder = await _orderService.AddAsync(orderDto);
                return Created("", placedOrder);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Elimina un ordine specificato per ID.
        /// </summary>
        /// <param name="id">L'ID dell'ordine da eliminare.</param>
        /// <returns>Un'azione che restituisce un oggetto IActionResult che rappresenta il risultato della richiesta HTTP.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Impossibile eliminare ordine con id minore di 1 {id}");
            }

            try
            {
                await _orderService.DeleteAsync(id);
                return Ok($"Ordine {id} eliminato con successo");
            }
            catch (OrderException e)
            {
                return BadRequest($"Errore eliminazione ordine {e.Message}");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}