using OrdersService.Service.Order.Dto;

namespace OrdersService.Service.Order
{
    public interface IOrderService
    {
        Task DeleteAsync(int id);
        Task<List<Model.Order>> GetAsync();
        Task<Model.Order> GetAsync(int id);
        Task<Model.Order> AddAsync(OrderDto orderDto);
    }
}
