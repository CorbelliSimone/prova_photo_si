namespace OrdersService.Repository.Order
{
    public interface IOrderRepository : IGenericRepository<Model.Order>
    {
        Task<Model.Order> LastOrDefaultAsync();
    }
}
