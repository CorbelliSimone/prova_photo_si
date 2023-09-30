using ProductsService.Model;

namespace ProductsService.Repository.Category
{
    /// <summary>
    /// Implementazione del repository per la gestione delle categorie.
    /// </summary>
    public class CategoryRepository : GenericRepository<Model.Category>, ICategoryRepository
    {
        /// <summary>
        /// Crea una nuova istanza del CategoryRepository.
        /// </summary>
        /// <param name="context">Il contesto del database.</param>
        public CategoryRepository(Context context) : base(context)
        {
        }
    }
}
