using ProductsService.Model;

namespace ProductsService.Repository.Category
{
    public class CategoryRepository : GenericRepository<Model.Category>, ICategoryRepository
    {
        public CategoryRepository(Context context) : base(context)
        {
        }
    }
}
