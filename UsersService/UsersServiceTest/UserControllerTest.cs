using Microsoft.AspNetCore.Mvc.Testing;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using UsersService;
using UsersService.Model;

using Xunit;

namespace UsersServiceTest
{
    public class UserControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UserControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
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

        private Task<HttpResponseMessage> PostInternal(User user, HttpClient client)
        {
            return client.PostAsJsonAsync("/api/v1/user", user);
        }

        public static IEnumerable<object[]> GetRandomUser()
        {
            return new List<object[]>
            {
                new object[] {
                    new User() {
                        FirstName = "nome1",
                        LastName = "cognome1",
                        Username = "nome1.cognome1"
                    }
                },
                new object[] {
                    new User() {
                        FirstName = "nome2",
                        LastName = "cognome2",
                        Username = "nome2.cognome2"
                    }
                },
                new object[] {
                    new User() {
                        FirstName = "nome3",
                        LastName = "cognome3",
                        Username = "nome3.cognome3"
                    }
                },
                new object[] {
                    new User() {
                        FirstName = "nome4",
                        LastName = "cognome4",
                        Username = "nome4.cognome4"
                    }
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetRandomUser))]
        public async Task Put(User user)
        {
            using HttpClient client = _factory.CreateClient();
            HttpResponseMessage responsePost = await PostInternal(user, client);
            Assert.True(responsePost.StatusCode == HttpStatusCode.Created);

            var inserted = await responsePost.Content.ReadFromJsonAsync<User>();
            Assert.NotNull(inserted);

            user.FirstName = $"{user.FirstName}_new";
            user.LastName = $"{user.LastName}_new";
            user.Username = $"{user.Username}_new";
            HttpResponseMessage responseDelete = await client.PutAsJsonAsync($"/api/v1/user/{inserted.Id}", user);
            Assert.True(responseDelete.StatusCode is HttpStatusCode.OK);
        }

        [Theory]
        [MemberData(nameof(GetRandomUser))]
        public async Task Post(User user)
        {
            using HttpClient client = _factory.CreateClient();
            HttpResponseMessage responsePost = await PostInternal(user, client);
            Assert.True(responsePost.StatusCode is HttpStatusCode.Created);
        }

        [Theory]
        [MemberData(nameof(GetRandomUser))]
        public async Task Delete(User user)
        {
            using HttpClient client = _factory.CreateClient();
            HttpResponseMessage responsePost = await PostInternal(user, client);
            Assert.True(responsePost.StatusCode == HttpStatusCode.Created);

            var inserted = await responsePost.Content.ReadFromJsonAsync<User>();
            Assert.NotNull(inserted);

            HttpResponseMessage responseDelete = await client.DeleteAsync($"/api/v1/user/{inserted.Id}");
            Assert.True(responseDelete.StatusCode is HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get()
        {
            using HttpClient client = _factory.CreateClient();
            using HttpResponseMessage response = await client.GetAsync("/api/v1/user");
            Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [MemberData(nameof(GetRandomId))]
        public async Task Gets(int id)
        {
            using HttpClient client = _factory.CreateClient();
            using HttpResponseMessage response = await client.GetAsync($"/api/v1/user/{id}");
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
