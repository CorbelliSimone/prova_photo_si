using ApiService.Service.Product.Httpz;

namespace ApiService.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductHttpClient _productHttpClient;

        public ProductService(IProductHttpClient productHttpClient)
        {
            _productHttpClient = productHttpClient;
        }

        public Task<List<object>> GetAsync()
        {
            return _productHttpClient.Get<List<object>>(string.Empty);
        }

        public Task<object> GetAsync(int id)
        {
            return _productHttpClient.Get<object>($"{id}");
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _productHttpClient.Delete($"{id}");
        }

        public Task<object> AddAsync(object productDto)
        {
            return _productHttpClient.Post<object>($"{productDto}", productDto);
        }

        public Task<object> PutAsync(int id, object productDto)
        {
            return _productHttpClient.Put($"{productDto}", productDto);
        }
    }
}
