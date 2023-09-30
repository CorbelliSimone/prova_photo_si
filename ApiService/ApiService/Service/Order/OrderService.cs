using ApiService.Service.Order.Dto;
using ApiService.Service.Order.Exceptionz;
using ApiService.Service.Order.Httpz;
using ApiService.Service.Product.Httpz;

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

        public async Task<object> PlaceOrder(OrderDto orderDto)
        {
            foreach (var product in orderDto.Products)
            {
                var findedProduct = await _productHttpClient.Get<object>($"{product.Id}");
                if (findedProduct == null)
                {
                    throw new OrderException($"Prodotto {product.Id} non esistente");
                }
            }

            return await _orderHttpClient.Post<object>(string.Empty, orderDto);
        }
    }
}
