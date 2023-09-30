using ApiService.Service.Order.Dto;
using ApiService.Service.Order.Exceptionz;
using ApiService.Service.Order.Httpz;
using ApiService.Service.Product.Httpz;
using ApiService.Service.User.Dto;

namespace ApiService.Service.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderHttpClient _orderHttpClient;
        private readonly IProductHttpClient _productHttpClient;

        public OrderService
        (
            IOrderHttpClient orderHttpClient,
            IProductHttpClient productHttpClient
        )
        {
            _orderHttpClient = orderHttpClient;
            _productHttpClient = productHttpClient;
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _orderHttpClient.Delete($"{id}");
        }

        public Task<object> GetAsync(int id)
        {
            return _orderHttpClient.Get<object>($"{id}");
        }

        public Task<List<object>> GetAsync()
        {
            return _orderHttpClient.Get<List<object>>(string.Empty);
        }

        public Task<object> PlaceOrder(OrderDto orderDto, UserDto userLogged)
        {
            orderDto.ProductIds.ForEach(async productId =>
            {
                var product = await _productHttpClient.Get<object>($"{productId}");
                if (product == null)
                {
                    throw new OrderException($"Prodotto {productId} non esistente");
                }
            });

            return _orderHttpClient.Post<object>($"{userLogged.Id}", orderDto);
        }
    }
}
