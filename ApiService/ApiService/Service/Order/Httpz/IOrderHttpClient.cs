using ApiService.Service.Order.Dto;

namespace ApiService.Service.Order.Httpz
{
    public interface IOrderHttpClient
    {
        Task<int> PlaceOrder(OrderDto orderDto, int userId);
    }
}
