namespace AddressBooksService.Repository
{
    public interface IGenericRepository<TEntity>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> DeleteAsync(int id);
        ValueTask<TEntity> GetAsync(int id);
        Task<List<TEntity>> GetAsync();
        Task<int> SaveAsync();
    }
}
