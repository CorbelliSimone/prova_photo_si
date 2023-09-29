using ApiService.Service.Httpz;
using ApiService.Service.Order.Dto;

namespace ApiService.Service.Order.Httpz
{
    public class OrderHttpClient : BaseHttpClient, IOrderHttpClient
    {
        public OrderHttpClient(HttpClient httpClient) : base(httpClient, "v1/order/")
        {
        }

        public Task<int> PlaceOrder(OrderDto orderDto, int userId)
        {
            return base.Post<int>($"{userId}", orderDto);
        }
    }
}
