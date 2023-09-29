using Moq;

using ProductsService.Model;
using ProductsService.Repository.Product;
using ProductsService.Service.Product.Dto;
using ProductsService.Service.Product;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductsServiceTest.Repository
{
    public class ProductRepositoryTest
    {
        private static readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Product 1", CategoryId = 1, Description = "Descrizione 1" },
            new Product { Id = 2, Name = "Product 2", CategoryId = 2, Description = "Descrizione 2" },
            new Product { Id = 3, Name = "Product 3", CategoryId = 1, Description = "Descrizione 3" },
            new Product { Id = 4, Name = "Product 4", CategoryId = 2, Description = "Descrizione 4" }
        };

        private static Context SetupDbContext()
        {
            var mockDbContext = new Mock<Context>();
            var mockDbSet = new Mock<DbSet<Product>>();

            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(_products.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(_products.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(_products.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(_products.AsQueryable().GetEnumerator());

            mockDbContext.Setup(d => d.Products).Returns(mockDbSet.Object);

            return mockDbContext.Object;
        }

        [Fact]
        public async Task GetProducts()
        {
            // Setup DbContext
            var dbContext = SetupDbContext();
            IProductRepository productRepository = new ProductRepository(dbContext);
            var product = await productRepository.GetAsync();
            Assert.NotNull(product);
        }

        //[Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        //[InlineData(3)]
        //[InlineData(4)]
        //public async Task GetProduct(int id)
        //{
        //    var productRepositoryMock = new Mock<IProductRepository>();
        //    productRepositoryMock.Setup(repo => repo.GetAsync(id)).ReturnsAsync(_products.First(x => x.Id == id));

        //    var productService = new ProductService(productRepositoryMock.Object, _mapper);
        //    var productDto = await productService.GetAsync(id);
        //    Assert.NotNull(productDto);
        //}

        //[Theory]
        //[MemberData(nameof(GetRandomProductDto))]
        //public async Task AddProduct(ProductDto productDto)
        //{
        //    var productRepositoryMock = new Mock<IProductRepository>();
        //    var productService = new ProductService(productRepositoryMock.Object, _mapper);

        //    try
        //    {
        //        await productService.AddAsync(productDto);
        //        productRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.True(false);
        //    }
        //}

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
