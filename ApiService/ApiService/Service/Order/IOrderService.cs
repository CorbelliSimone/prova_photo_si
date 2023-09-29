using ApiService.Controllers;
using ApiService.Service.Order.Dto;

namespace ApiService.Service.Order
{
    public interface IOrderService
    {
        Task<int> PlaceOrder(OrderDto orderDto, UserLogged userLogged);
    }
}
