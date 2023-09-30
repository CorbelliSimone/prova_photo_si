using AutoMapper;

using ProductsService.Repository.Category;
using ProductsService.Repository.Product;
using ProductsService.Service.Product.Dto;
using ProductsService.Service.Product.Exceptionz;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsService.Service.Product
{
    /// <summary>
    /// Implementazione del servizio per la gestione dei prodotti.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Crea una nuova istanza del servizio ProductService.
        /// </summary>
        /// <param name="productRepository">Repository dei prodotti.</param>
        /// <param name="categoryRepository">Repository delle categorie.</param>
        /// <param name="mapper">Oggetto Mapper per il mapping degli oggetti.</param>
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Ottiene tutti i prodotti in modo asincrono.
        /// </summary>
        /// <returns>Una lista di tutti i prodotti.</returns>
        public async Task<List<ProductDto>> GetAsync()
        {
            var allProducts = await _productRepository.GetAsync();
            return _mapper.Map<List<ProductDto>>(allProducts);
        }

        /// <summary>
        /// Ottiene un prodotto per ID in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID del prodotto da ottenere.</param>
        /// <returns>Il prodotto con l'ID specificato.</returns>
        public async Task<ProductDto> GetAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        /// <summary>
        /// Aggiunge un nuovo prodotto in modo asincrono.
        /// </summary>
        /// <param name="productDto">DTO del prodotto da aggiungere.</param>
        /// <returns>Il DTO del prodotto aggiunto.</returns>
        public async Task<ProductDto> AddAsync(ProductDto productDto)
        {
            var existsCategory = await _categoryRepository.GetAsync(productDto.CategoryId) != null;
            if (!existsCategory)
            {
                throw new ProductException($"Categoria {productDto.CategoryId} non esistente");
            }

            var product = _mapper.Map<Model.Product>(productDto);
            _ = await _productRepository.AddAsync(product);
            productDto.Id = product.Id;
            return productDto;
        }

        /// <summary>
        /// Elimina un prodotto in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID del prodotto da eliminare.</param>
        /// <returns>Task completato.</returns>
        public async Task DeleteAsync(int id)
        {
            var productToDelete = await _productRepository.GetAsync(id);
            if (productToDelete == null)
            {
                throw new ProductException($"Prodotto {id} non esistente");
            }

            await _productRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Aggiorna un prodotto in modo asincrono.
        /// </summary>
        /// <param name="id">L'ID del prodotto da aggiornare.</param>
        /// <param name="productDto">DTO del prodotto aggiornato.</param>
        /// <returns>Il numero di prodotti aggiornati.</returns>
        public async Task<int> UpdateAsync(int id, ProductDto productDto)
        {
            var existsCategory = await _categoryRepository.GetAsync(productDto.CategoryId) != null;
            if (!existsCategory)
            {
                throw new ProductException($"Categoria {productDto.CategoryId} non esistente");
            }

            var product = await _productRepository.GetAsync(id);
            if (product == null)
            {
                throw new ProductException($"Prodotto con id {id} non esistente");
            }

            product.Description = productDto.Description;
            product.Name = productDto.Name;
            product.CategoryId = productDto.CategoryId;

            return await _productRepository.SaveAsync();
        }
    }
}
