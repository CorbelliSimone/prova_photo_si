using ApiService.Service.Product.Dto;
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

        public Task<List<ProductDto>> GetAllAsync()
        {
            return _productHttpClient.GetAllAsync();
        }

        public Task AddAsync(ProductDto productDto)
        {
            return _productHttpClient.AddAllAsync(productDto);
        }
    }
}
