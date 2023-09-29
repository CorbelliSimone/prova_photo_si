namespace OrdersService.Repository.Order
{
    public interface IOrderRepository : IGenericRepository<Model.Order>
    {
        Task<Model.Order> GetAndInclude(int id);
        Task<List<Model.Order>> GetAllAndInclude();
    }
}
