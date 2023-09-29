using ApiService.Controllers;
using ApiService.Service.Order.Dto;
using ApiService.Service.Order.Httpz;

namespace ApiService.Service.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderHttpClient _orderHttpClient;

        public OrderService(IOrderHttpClient orderHttpClient)
        {
            _orderHttpClient = orderHttpClient;
        }

        public Task<int> PlaceOrder(OrderDto orderDto, UserLogged userLogged)
        {
            return _orderHttpClient.PlaceOrder(orderDto, userLogged.Id);
        }
    }
}
