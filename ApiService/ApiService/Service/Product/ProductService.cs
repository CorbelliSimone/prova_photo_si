using ApiService.Service.Order.Httpz;
using ApiService.Service.Product.Exceptionz;
using ApiService.Service.Product.Httpz;

namespace ApiService.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductHttpClient _productHttpClient;
        private readonly IOrderHttpClient _orderHttpClient;

        public ProductService
        (
            IProductHttpClient productHttpClient,
            IOrderHttpClient orderHttpClient
        )
        {
            _productHttpClient = productHttpClient;
            _orderHttpClient = orderHttpClient;
        }

        public Task<List<object>> GetAsync()
        {
            return _productHttpClient.Get<List<object>>(string.Empty);
        }

        public Task<object> GetAsync(int id)
        {
            return _productHttpClient.Get<object>($"{id}");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // se trovo qualcosa di associato non posso eliminare il prodotto
            var ordersWithProducts = await _orderHttpClient.GetByProductIdAsync(id);
            if (ordersWithProducts.Any())
            {
                throw new ProductException($"Ordini con id {string.Join(", ", ordersWithProducts.Select(x => x.Id))} associati al prodotto, non posso eliminarlo");
            }

            return await _productHttpClient.Delete($"{id}");
        }

        public Task<object> AddAsync(object productDto)
        {
            return _productHttpClient.Post<object>(string.Empty, productDto);
        }

        public Task<object> PutAsync(int id, object productDto)
        {
            return _productHttpClient.Put($"{id}", productDto);
        }
    }
}
