using ApiService.Service.Httpz;
using ApiService.Service.Product.Dto;

namespace ApiService.Service.Product.Httpz
{
    public class ProductHttpClient : BaseHttpClient, IProductHttpClient
    {
        public ProductHttpClient(HttpClient httpClient)
            : base(httpClient, "v1/product/")
        {
        }

        public Task<List<ProductDto>> GetAllAsync()
        {
            return base.Get<List<ProductDto>>("");
        }

        public Task AddAllAsync(ProductDto productDto)
        {
            return base.Post<object>("", productDto);
        }
    }
}
