using ApiService.Service.AddressBook.Dto;
using ApiService.Service.AddressBook.Httpz;
using ApiService.Service.Order.Dto;
using ApiService.Service.Order.Exceptionz;
using ApiService.Service.Order.Httpz;
using ApiService.Service.Product.Httpz;

using System.Collections.Concurrent;

namespace ApiService.Service.Order
{
    /// <summary>
    /// Servizio per la gestione degli ordini.
    /// </summary>
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

        /// <summary>
        /// Elimina un ordine in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'ordine da eliminare.</param>
        /// <returns>True se l'eliminazione ha avuto successo, altrimenti false.</returns>
        public Task<bool> DeleteAsync(int id)
        {
            return _orderHttpClient.Delete($"{id}");
        }


        /// <summary>
        /// Ottiene i dettagli di un ordine in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID dell'ordine da recuperare.</param>
        /// <returns>I dettagli dell'ordine.</returns>
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

        /// <summary>
        /// Ottiene la lista completa degli ordini in modo asincrono.
        /// </summary>
        /// <returns>La lista completa degli ordini con i dettagli.</returns>
        public async Task<List<OrderMapperCompleteDto>> GetAsync()
        {
            var addressDictionary = new ConcurrentDictionary<int, AddressCompleteDto>();
            var productDictionary = new ConcurrentDictionary<int, ProductOrdersDto>();
            var orders = await _orderHttpClient.Get<List<OrderDto>>(string.Empty);
            var orderMapperCompleteTasks = orders.Select(async order =>
            {
                var productsListTasks = order.Products.Select(async product =>
                {
                    if (!productDictionary.TryGetValue(product.Id, out var productComplete))
                    {
                        productComplete = await _productHttpClient.Get<ProductOrdersDto>($"{product.Id}");
                        productDictionary.TryAdd(product.Id, productComplete);
                    }

                    productComplete.Quantity = product.Quantity;
                    return productComplete;
                });

                var productsList = await Task.WhenAll(productsListTasks);

                if (!addressDictionary.TryGetValue(order.AddressId, out var addressCompleteDto))
                {
                    addressCompleteDto = await _addressBookHttpClient.Get<AddressCompleteDto>($"{order.AddressId}");
                    addressDictionary.TryAdd(order.AddressId, addressCompleteDto);
                }

                return new OrderMapperCompleteDto
                {
                    Address = addressCompleteDto,
                    UserId = order.UserId,
                    Id = order.Id,
                    OrderName = order.OrderName,
                    Products = productsList.ToList()
                };
            });

            var orderMapperComplete = await Task.WhenAll(orderMapperCompleteTasks);
            return orderMapperComplete.ToList();
        }

        /// <summary>
        /// Effettua un ordine in modo asincrono.
        /// </summary>
        /// <param name="orderDto">I dettagli dell'ordine.</param>
        /// <returns>Il risultato dell'operazione di ordinazione.</returns>
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
