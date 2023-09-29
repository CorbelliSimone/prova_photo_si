using ProductsService.Service.Product.Dto;

namespace ProductsService.Service.Product
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAsync();
        Task<ProductDto> GetAsync(int id);
        Task<ProductDto> AddAsync(ProductDto productDto);
        Task DeleteAsync(int id);
        Task<int> UpdateAsync(int id, ProductDto productDto);
    }
}
