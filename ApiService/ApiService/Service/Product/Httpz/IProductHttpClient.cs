using ApiService.Service.Product.Dto;

namespace ApiService.Service.Product.Httpz
{
    public interface IProductHttpClient
    {
        Task<List<ProductDto>> GetAllAsync();
        Task AddAllAsync(ProductDto productDto);
    }
}
