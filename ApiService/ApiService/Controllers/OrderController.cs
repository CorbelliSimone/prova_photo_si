using ApiService.Service.Order;
using ApiService.Service.Order.Dto;
using ApiService.Service.User.Cache;

using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/v1/order")]
    [ApiController]
    public class OrderController : BaseApiController
    {
        private readonly IOrderService _orderService;

        public OrderController
        (
            UserLoggedHandler userLoggedHandler,
            IOrderService orderService
        ) : base(userLoggedHandler)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderDto)
        {
            if (_userLoggedHandler.UserLogged == null)
            {
                return Unauthorized("Prima di piazzare un ordine bisogna fare il login");
            }

            if (!_userLoggedHandler.UserLogged.AddressId.HasValue)
            {
                return BadRequest("Prima di piazzare un'ordine bisogna associare un indirizzo ad un utente");
            }

            if (orderDto.ProductIds == null || orderDto.ProductIds.Count == 0)
            {
                return BadRequest("Nessun prodotto associato all'ordine");
            }

            try
            {
                var placedOrderId = await _orderService.PlaceOrder(orderDto, _userLoggedHandler.UserLogged);
                return Created("", placedOrderId);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Errore nel piazzare l'ordine {e.Message}");
            }
        }
    }
}
