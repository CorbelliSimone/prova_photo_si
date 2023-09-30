using ApiService.Service.Order.Dto;

namespace ApiService.Service.Order
{
    public interface IOrderService
    {
        Task<bool> DeleteAsync(int id);
        Task<object> GetAsync(int id);
        Task<List<object>> GetAsync();
        Task<object> PlaceOrder(OrderDto orderDto);
    }
}
