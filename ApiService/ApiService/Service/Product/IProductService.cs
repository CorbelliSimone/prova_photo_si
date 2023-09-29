using ApiService.Service.Product.Dto;

namespace ApiService.Service.Product
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task AddAsync(ProductDto productDto);
    }
}
