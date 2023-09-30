using ApiService.Service.Order.Dto;
using ApiService.Service.User.Dto;

namespace ApiService.Service.Order
{
    public interface IOrderService
    {
        Task<bool> DeleteAsync(int id);
        Task<object> GetAsync(int id);
        Task<List<object>> GetAsync();
        Task<object> PlaceOrder(OrderDto orderDto, UserDto userLogged);
    }
}
