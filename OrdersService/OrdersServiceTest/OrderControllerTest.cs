using Microsoft.AspNetCore.Mvc.Testing;
using OrdersService;
using OrdersService.Service.Order.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace OrdersServiceTest
{
    public class OrderControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public OrderControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }


        [Theory]
        [MemberData(nameof(GetRandomProduct))]
        public async Task UpdateProduct(ProductDto productDto)
        {
            Assert.True(responsePost.StatusCode == HttpStatusCode.Created);

            Assert.NotNull(responseDto);

            Assert.True(responseDelete.StatusCode is HttpStatusCode.OK);
        }

        [Theory]
        [MemberData(nameof(GetRandomProduct))]
        public async Task AddProduct(ProductDto productDto)
        {
            Assert.True(responsePost.StatusCode is HttpStatusCode.Created);
        }

        [Theory]
        [MemberData(nameof(GetRandomProduct))]
        public async Task DeleteProduct(ProductDto productDto)
        {
            Assert.True(responsePost.StatusCode == HttpStatusCode.Created);

            Assert.NotNull(responseDto);

            Assert.True(responseDelete.StatusCode is HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetProduct()
        {
            Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [MemberData(nameof(GetRandomId))]
        public async Task GetProducts(int id)
        {
            Assert.True();
        }
    }
}
