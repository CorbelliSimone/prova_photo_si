using ApiService.Service.AddressBook.Httpz;
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
        private readonly IAddressBookHttpClient _addressBookHttpClient;

        public OrderService
        (
            IOrderHttpClient orderHttpClient,
            IProductHttpClient productHttpClient,
            IAddressBookHttpClient addressBookHttpClient
        )
        {
            _orderHttpClient = orderHttpClient;
            _productHttpClient = productHttpClient;
            _addressBookHttpClient = addressBookHttpClient;
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _orderHttpClient.Delete($"{id}");
        }

        public Task<OrderDto> GetAsync(int id)
        {
            return _orderHttpClient.Get<OrderDto>($"{id}");
        }

        public Task<List<OrderDto>> GetAsync()
        {
            return _orderHttpClient.Get<List<OrderDto>>(string.Empty);
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

            // Controllare che AddressId esista veramente
            var findedAddress = await _addressBookHttpClient.Get<object>($"{orderDto.AddressId}");
            if (findedAddress == null)
            {
                throw new OrderException($"Indirizzo {orderDto.AddressId} non esistente");
            }

            return await _orderHttpClient.Post<object>(string.Empty, orderDto);
        }
    }
}
