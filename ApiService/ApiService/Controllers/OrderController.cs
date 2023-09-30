﻿using ApiService.Service.Order;
using ApiService.Service.Order.Dto;
using ApiService.Service.Order.Exceptionz;
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
            IUserLoggedHandler userLoggedHandler,
            IOrderService orderService
        ) : base(userLoggedHandler)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _orderService.GetAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _orderService.GetAsync(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _orderService.DeleteAsync(id));

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderDto)
        {
            if (_userLoggedHandler.GetUserLogged() == null)
            {
                return Unauthorized("Prima di piazzare un ordine bisogna fare il login api/v1/user");
            }

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
