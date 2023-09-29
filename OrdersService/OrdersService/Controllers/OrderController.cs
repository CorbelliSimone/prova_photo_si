using Microsoft.AspNetCore.Mvc;

using OrdersService.Service.Order;
using OrdersService.Service.Order.Dto;
using OrdersService.Service.Order.Exceptionz;

namespace OrdersService.Controllers
{
    [Route("api/v1/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _orderService.GetAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _orderService.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> PlaceOrderAsync([FromBody] OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest($"Ordine da piazzare arrivato nullo");
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
                return Created("", placedOrder.Id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

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
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
