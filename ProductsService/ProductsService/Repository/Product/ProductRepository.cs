using ProductsService.Model;

namespace ProductsService.Repository.Product
{
    public class ProductRepository : GenericRepository<Model.Product>, IProductRepository
    {
        public ProductRepository(Context context)
            : base(context)
        {
        }
    }
}
