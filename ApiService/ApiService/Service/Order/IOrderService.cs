using ApiService.Service.Order.Dto;

namespace ApiService.Service.Order
{
    public interface IOrderService
    {
        Task<bool> DeleteAsync(int id);
        Task<OrderDto> GetAsync(int id);
        Task<List<OrderDto>> GetAsync();
        Task<object> PlaceOrder(OrderDto orderDto);
    }
}
