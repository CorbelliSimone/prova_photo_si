using AutoMapper;

using Moq;

using ProductsService.Model;
using ProductsService.PropfileMapper;
using ProductsService.Repository.Product;
using ProductsService.Service.Product;
using ProductsService.Service.Product.Dto;

namespace ProductsServiceTest.Service
{
    public class ProductServiceTest
    {
        private static readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Product 1", CategoryId = 1, Description = "Descrizione 1" },
            new Product { Id = 2, Name = "Product 2", CategoryId = 2, Description = "Descrizione 2" },
            new Product { Id = 3, Name = "Product 3", CategoryId = 1, Description = "Descrizione 3" },
            new Product { Id = 4, Name = "Product 4", CategoryId = 2, Description = "Descrizione 4" }
        };

        private static readonly List<ProductDto> productsDto = new()
        {
            new ProductDto() { CategoryId = 1, Description = "Prodotto 1", Name = "Nome 1", Id = 1 },
            new ProductDto() { CategoryId = 2, Description = "Prodotto 2", Name = "Nome 2", Id = 2 },
            new ProductDto() { CategoryId = 1, Description = "Prodotto 3", Name = "Nome 3", Id = 3 },
            new ProductDto() { CategoryId = 2, Description = "Prodotto 4", Name = "Nome 4", Id = 4 }
        };

        public static IEnumerable<object[]> GetRandomProductDto()
        {
            return productsDto.Select(product => new object[] { product }).ToArray();
        }

        private readonly IMapper _mapper;

        public ProductServiceTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductMapper()); // Aggiungi il tuo profilo qui
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task GetProducts()
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetAsync()).ReturnsAsync(_products);

            var productService = new ProductService(productRepositoryMock.Object, _mapper);
            var productDto = await productService.GetAsync();
            Assert.NotNull(productDto);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task GetProduct(int id)
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetAsync(id)).ReturnsAsync(_products.First(x => x.Id == id));

            var productService = new ProductService(productRepositoryMock.Object, _mapper);
            var productDto = await productService.GetAsync(id);
            Assert.NotNull(productDto);
        }

        [Theory]
        [MemberData(nameof(GetRandomProductDto))]
        public async Task AddProduct(ProductDto productDto)
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            var productService = new ProductService(productRepositoryMock.Object, _mapper);

            try
            {
                await productService.AddAsync(productDto);
                productRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);
            }
            catch (Exception e)
            {
                Assert.True(false);
            }
        }

        // per ora non funzionanti perche' mi danno sempre true
        //[Theory]
        //[MemberData(nameof(GetRandomProductDto))]
        //public async Task UpdateProduct(ProductDto productDto)
        //{
        //    var productRepositoryMock = new Mock<IProductRepository>();
        //    var productService = new ProductService(productRepositoryMock.Object, _mapper);

        //    try
        //    {
        //        var addedProduct = await productService.AddAsync(productDto);
        //        productRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);

        //        productDto.Description = $"{productDto.Description}_NEW";
        //        productDto.Name = $"{productDto.Name}_NEW";
        //        var updatedResult = await productService.UpdateAsync(addedProduct.Id, productDto);
        //        Assert.Equal(0, updatedResult);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.True(false);
        //    }
        //}

        //[Theory]
        //[MemberData(nameof(GetRandomProductDto))]
        //public async Task DeleteProduct(ProductDto productDto)
        //{
        //    var productRepositoryMock = new Mock<IProductRepository>();
        //    var productService = new ProductService(productRepositoryMock.Object, _mapper);

        //    try
        //    {
        //        var addedProduct = await productService.AddAsync(productDto);
        //        productRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);

        //        await productService.DeleteAsync(addedProduct.Id);
        //        productRepositoryMock.Verify(repo => repo.DeleteAsync(addedProduct.Id), Times.Never);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.True(false);
        //    }
        //}
    }
}
