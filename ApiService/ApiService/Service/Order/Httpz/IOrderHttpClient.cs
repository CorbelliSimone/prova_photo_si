using ApiService.Service.Httpz;
using ApiService.Service.Order.Dto;

namespace ApiService.Service.Order.Httpz
{
    public interface IOrderHttpClient : IBaseHttpClient
    {
        Task<List<OrderDto>> GetByProductIdAsync(int id);
        Task<List<OrderDto>> GetByAddressIdAsync(int id);
    }
}
