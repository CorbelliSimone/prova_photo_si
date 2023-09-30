using ApiService.Service.Httpz;
using ApiService.Service.Order.Dto;

namespace ApiService.Service.Order.Httpz
{
    public class OrderHttpClient : BaseHttpClient, IOrderHttpClient
    {
        public OrderHttpClient(HttpClient httpClient) : base(httpClient, "v1/order/")
        {
        }

        public Task<List<OrderDto>> GetByAddressIdAsync(int id)
        {
            return Get<List<OrderDto>>($"address/{id}");
        }

        public Task<List<OrderDto>> GetByProductIdAsync(int id)
        {
            return Get<List<OrderDto>>($"product/{id}");
        }
    }
}
