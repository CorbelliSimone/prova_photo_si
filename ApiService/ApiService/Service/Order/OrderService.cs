using ApiService.Service.AddressBook.Dto;
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

        public async Task<OrderMapperCompleteDto> GetAsync(int id)
        {
            var order = await _orderHttpClient.Get<OrderDto>($"{id}");
            if (order == null)
            {
                return null;
            }

            var productsList = new List<ProductOrdersDto>();
            foreach (var product in order.Products)
            {
                var productComplete = await _productHttpClient.Get<ProductOrdersDto>($"{product.Id}");
                productComplete.Quantity = product.Quantity;
                productsList.Add(productComplete);
            }

            return new OrderMapperCompleteDto()
            {
                Address = await _addressBookHttpClient.Get<AddressCompleteDto>($"{order.AddressId}"),
                UserId = order.UserId,
                Id = order.Id,
                OrderName = order.OrderName,
                Products = productsList
            };
        }

        public async Task<List<OrderMapperCompleteDto>> GetAsync()
        {
            // Cache locale per risparmiare chiamate http
            var addressDictionary = new Dictionary<int, AddressCompleteDto>();
            var productDictionary = new Dictionary<int, ProductOrdersDto>();
            var orderMapperComplete = new List<OrderMapperCompleteDto>();
            var orders = await _orderHttpClient.Get<List<OrderDto>>(string.Empty);
            foreach (var order in orders)
            {
                var productsList = new List<ProductOrdersDto>();
                foreach (var product in order.Products)
                {
                    ProductOrdersDto productComplete = null;
                    if (productDictionary.ContainsKey(product.Id))
                    {
                        productComplete = productDictionary[product.Id];
                    }
                    else
                    {
                        productComplete = await _productHttpClient.Get<ProductOrdersDto>($"{product.Id}");
                        productDictionary.Add(product.Id, productComplete);
                    }

                    productComplete.Quantity = product.Quantity;
                    productsList.Add(productComplete);
                }

                AddressCompleteDto addressCompleteDto = null;
                if (addressDictionary.ContainsKey(order.AddressId))
                {
                    addressCompleteDto = addressDictionary[order.AddressId];
                }
                else
                {
                    addressCompleteDto = await _addressBookHttpClient.Get<AddressCompleteDto>($"{order.AddressId}");
                    addressDictionary.Add(order.AddressId, addressCompleteDto);
                }

                orderMapperComplete.Add(new OrderMapperCompleteDto()
                {
                    Address = addressCompleteDto,
                    UserId = order.UserId,
                    Id = order.Id,
                    OrderName = order.OrderName,
                    Products = productsList
                });
            }

            return orderMapperComplete;
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
