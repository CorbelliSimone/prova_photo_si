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
using OrdersService.Model;

namespace OrdersServiceTest
{
    public class OrderControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public OrderControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        public static IEnumerable<object[]> GetRandomOrder()
        {
            return new List<object[]>
            {
                new object[] {
                    new OrderDto() {
                        OrderName = "Nome ordine 1",
                        UserId = 1,
                        Products = new List<ProductDto>()
                        {
                            new ProductDto()
                            {
                                Quantity = 5
                            },
                            new ProductDto()
                            {
                                Quantity = 10
                            }
                        }
                    },
                },
                new object[] {
                    new OrderDto() {
                        OrderName = "Nome ordine 2",
                        UserId = 1,
                        Products = new List<ProductDto>()
                        {
                            new ProductDto()
                            {
                                Quantity = 5
                            },
                            new ProductDto()
                            {
                                Quantity = 10
                            }
                        }
                    }
                }
            };
        }

        private static int GenerateRandomNumber(Random random, int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
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

        private Task<HttpResponseMessage> PostInternal(OrderDto order, HttpClient client)
        {
            return client.PostAsJsonAsync("/api/v1/order", order);
        }

        [Theory]
        [MemberData(nameof(GetRandomOrder))]
        public async Task Post(OrderDto orderDto)
        {
            using HttpClient client = _factory.CreateClient();
            HttpResponseMessage responsePost = await PostInternal(orderDto, client);
            Assert.True(responsePost.StatusCode is HttpStatusCode.Created);
        }

        [Theory]
        [MemberData(nameof(GetRandomOrder))]
        public async Task Delete(OrderDto Order)
        {
            using HttpClient client = _factory.CreateClient();
            HttpResponseMessage responsePost = await PostInternal(Order, client);
            Assert.True(responsePost.StatusCode == HttpStatusCode.Created);

            var inserted = await responsePost.Content.ReadFromJsonAsync<OrderDto>();
            Assert.NotNull(inserted);

            HttpResponseMessage responseDelete = await client.DeleteAsync($"/api/v1/order/{inserted.Id}");
            Assert.True(responseDelete.StatusCode is HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get()
        {
            using HttpClient client = _factory.CreateClient();
            using HttpResponseMessage response = await client.GetAsync("/api/v1/order");
            Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [MemberData(nameof(GetRandomId))]
        public async Task Gets(int id)
        {
            using HttpClient client = _factory.CreateClient();
            using HttpResponseMessage response = await client.GetAsync($"/api/v1/order/{id}");
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
