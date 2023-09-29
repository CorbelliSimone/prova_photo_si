﻿using Microsoft.AspNetCore.Mvc.Testing;

using ProductsService;
using ProductsService.Service.Product.Dto;

using System.Net;
using System.Net.Http.Json;

namespace ProductsServiceTest.Controller
{
    public class ProductControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ProductControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        public static IEnumerable<object[]> GetRandomProduct()
        {
            return new List<object[]>
            {
                new object[] {
                    new ProductDto() {
                        CategoryId = 1,
                        Description = "Prodotto 1",
                        Name = "Nome 1"
                    }
                },
                new object[] {
                    new ProductDto() {
                        CategoryId = 2,
                        Description = "Prodotto 2",
                        Name = "Nome 2"
                    }
                },
                new object[] {
                    new ProductDto() {
                        CategoryId = 3,
                        Description = "Prodotto 3",
                        Name = "Nome 3"
                    }
                }
            };
        }

        public static IEnumerable<object[]> GetRandomId()
        {
            Random random = new();
            return new List<object[]>
            {
                new object[] { GenerateRandomNumber(random, 1, 100) },
                new object[] { GenerateRandomNumber(random, 1, 100) },
                new object[] { GenerateRandomNumber(random, 1, 100) },
                new object[] { GenerateRandomNumber(random, 1, 100) },
                new object[] { GenerateRandomNumber(random, 1, 100) },
                new object[] { GenerateRandomNumber(random, 1, 100) },
                new object[] { GenerateRandomNumber(random, 1, 100) },
                new object[] { GenerateRandomNumber(random, 1, 100) },
                new object[] { GenerateRandomNumber(random, 1, 100) },
                new object[] { GenerateRandomNumber(random, 1, 100) }
            };
        }

        private static int GenerateRandomNumber(Random random, int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        private Task<HttpResponseMessage> Post(ProductDto productDto, HttpClient client)
        {
            return client.PostAsJsonAsync("/api/v1/product", productDto);
        }

        [Theory]
        [MemberData(nameof(GetRandomProduct))]
        public async Task UpdateProduct(ProductDto productDto)
        {
            using HttpClient client = _factory.CreateClient();
            var responsePost = await Post(productDto, client);
            Assert.True(responsePost.StatusCode == HttpStatusCode.Created);

            var responseDto = await responsePost.Content.ReadFromJsonAsync<ProductDto>();
            Assert.NotNull(responseDto);

            productDto.Name = $"{productDto.Name}_new";
            productDto.Description = $"{productDto.Description}_new";
            var responseDelete = await client.PutAsJsonAsync($"/api/v1/product/{responseDto.Id}", productDto);
            Assert.True(responseDelete.StatusCode is HttpStatusCode.OK);
        }

        [Theory]
        [MemberData(nameof(GetRandomProduct))]
        public async Task AddProduct(ProductDto productDto)
        {
            using HttpClient client = _factory.CreateClient();
            var responsePost = await Post(productDto, client);
            Assert.True(responsePost.StatusCode is HttpStatusCode.Created);
        }

        [Theory]
        [MemberData(nameof(GetRandomProduct))]
        public async Task DeleteProduct(ProductDto productDto)
        {
            using HttpClient client = _factory.CreateClient();
            var responsePost = await Post(productDto, client);
            Assert.True(responsePost.StatusCode == HttpStatusCode.Created);

            var responseDto = await responsePost.Content.ReadFromJsonAsync<ProductDto>();
            Assert.NotNull(responseDto);

            var responseDelete = await client.DeleteAsync($"/api/v1/product/{responseDto.Id}");
            Assert.True(responseDelete.StatusCode is HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetProduct()
        {
            using HttpClient client = _factory.CreateClient();
            using HttpResponseMessage response = await client.GetAsync("/api/v1/product");
            Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [MemberData(nameof(GetRandomId))]
        public async Task GetProducts(int id)
        {
            using HttpClient client = _factory.CreateClient();
            using HttpResponseMessage response = await client.GetAsync($"/api/v1/product/{id}");
            Assert.True(response.StatusCode is HttpStatusCode.OK or HttpStatusCode.NotFound);
        }
    }
}
