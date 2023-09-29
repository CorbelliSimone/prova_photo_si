using OrdersService.Service.Order.Dto;

namespace OrdersService.Service.Order
{
    public interface IOrderService
    {
        Task DeleteAsync(int id);
        Task<List<OrderDto>> GetAsync();
        Task<OrderDto> GetAsync(int id);
        Task<OrderDto> AddAsync(OrderDto orderDto);
    }
}
