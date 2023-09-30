
namespace ApiService.Service.Product
{
    public interface IProductService
    {
        Task<List<object>> GetAsync();
        Task<object> AddAsync(object productDto);
        Task<object> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<object> PutAsync(int id, object productDto);
    }
}
