using ProductsService.Model;

namespace ProductsService.Repository.Product
{
    /// <summary>
    /// Implementazione del repository per la gestione dei prodotti.
    /// </summary>
    public class ProductRepository : GenericRepository<Model.Product>, IProductRepository
    {
        /// <summary>
        /// Crea una nuova istanza del ProductRepository.
        /// </summary>
        /// <param name="context">Il contesto del database.</param>
        public ProductRepository(Context context) : base(context)
        {
        }
    }
}
