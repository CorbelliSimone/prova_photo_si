using ApiService.Service.Httpz;

namespace ApiService.Service.Order.Httpz
{
    public class OrderHttpClient : BaseHttpClient, IOrderHttpClient
    {
        public OrderHttpClient(HttpClient httpClient) : base(httpClient, "v1/order/")
        {
        }
    }
}
