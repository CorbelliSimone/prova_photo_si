using ApiService.Service.Order.Dto;

namespace ApiService.Service.Order
{
    public interface IOrderService
    {
        Task<bool> DeleteAsync(int id);
        Task<OrderMapperCompleteDto> GetAsync(int id);
        Task<List<OrderMapperCompleteDto>> GetAsync();
        Task<object> PlaceOrder(OrderDto orderDto);
    }
}
