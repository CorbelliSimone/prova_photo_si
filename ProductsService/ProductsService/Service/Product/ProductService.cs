using AutoMapper;

using ProductsService.Repository.Category;
using ProductsService.Repository.Product;
using ProductsService.Service.Product.Dto;
using ProductsService.Service.Product.Exceptionz;

namespace ProductsService.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductService
        (
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper
        )
        {
            this._productRepository = productRepository;
            _categoryRepository = categoryRepository;
            this._mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAsync()
        {
            var allProducts = await _productRepository.GetAsync();
            return _mapper.Map<List<ProductDto>>(allProducts);
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

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

        public async Task DeleteAsync(int id)
        {
            var productToDelete = await _productRepository.GetAsync(id);
            if (productToDelete == null)
            {
                throw new ProductException($"Prodotto {id} non esistente");
            }

            await _productRepository.DeleteAsync(id);
        }

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
