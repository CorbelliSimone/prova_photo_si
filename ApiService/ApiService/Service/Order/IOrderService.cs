using ApiService.Service.Order.Dto;
using ApiService.Service.User.Dto;

namespace ApiService.Service.Order
{
    public interface IOrderService
    {
        Task<int> PlaceOrder(OrderDto orderDto, UserDto userLogged);
    }
}
