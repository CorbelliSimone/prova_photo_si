using ApiService.Service.Order.Dto;
using ApiService.Service.Order.Httpz;
using ApiService.Service.User.Dto;

namespace ApiService.Service.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderHttpClient _orderHttpClient;

        public OrderService(IOrderHttpClient orderHttpClient)
        {
            _orderHttpClient = orderHttpClient;
        }

        public Task<int> PlaceOrder(OrderDto orderDto, UserDto userLogged)
        {
            return _orderHttpClient.PlaceOrder(orderDto, userLogged.Id);
        }
    }
}
