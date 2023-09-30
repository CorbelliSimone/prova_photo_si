using Microsoft.AspNetCore.Mvc.Testing;

using System.Net;
using System.Net.Http.Json;
using System.Text;

using UsersService;
using UsersService.Service.User.Dto;

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

        private Task<HttpResponseMessage> PostInternal(UserDto user, HttpClient client)
        {
            return client.PostAsJsonAsync("/api/v1/user", user);
        }

        private const string _characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static string GenerateRandomString(int length, Random random)
        {
            if (length <= 0)
                throw new ArgumentException("La lunghezza deve essere maggiore di zero.");

            StringBuilder result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(_characters.Length);
                result.Append(_characters[index]);
            }

            return result.ToString();
        }

        public static IEnumerable<object[]> GetRandomUser()
        {
            Random random = new();
            return new List<object[]>
            {
                new object[] {
                    new UserDto() {
                        FirstName = GenerateRandomString(30, random),
                        LastName = GenerateRandomString(30, random),
                        Username = GenerateRandomString(30, random)
                    }
                },
                new object[] {
                    new UserDto() {
                        FirstName = GenerateRandomString(30, random),
                        LastName = GenerateRandomString(30, random),
                        Username = GenerateRandomString(30, random)
                    }
                },
                new object[] {
                    new UserDto() {
                        FirstName = GenerateRandomString(30, random),
                        LastName = GenerateRandomString(30, random),
                        Username = GenerateRandomString(30, random)
                    }
                },
                new object[] {
                    new UserDto() {
                        FirstName = GenerateRandomString(30, random),
                        LastName = GenerateRandomString(30, random),
                        Username = GenerateRandomString(30, random)
                    }
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetRandomUser))]
        public async Task Put(UserDto user)
        {
            using HttpClient client = _factory.CreateClient();
            HttpResponseMessage responsePost = await PostInternal(user, client);
            Assert.True(responsePost.StatusCode == HttpStatusCode.Created);

            var inserted = await responsePost.Content.ReadFromJsonAsync<UserDto>();
            Assert.NotNull(inserted);

            user.FirstName = $"{user.FirstName}_new";
            user.LastName = $"{user.LastName}_new";
            user.Username = $"{user.Username}_new";
            HttpResponseMessage responseDelete = await client.PutAsJsonAsync($"/api/v1/user/{inserted.Id}", user);
            Assert.True(responseDelete.StatusCode is HttpStatusCode.OK);
        }

        [Theory]
        [MemberData(nameof(GetRandomUser))]
        public async Task Post(UserDto user)
        {
            using HttpClient client = _factory.CreateClient();
            HttpResponseMessage responsePost = await PostInternal(user, client);
            Assert.True(responsePost.StatusCode is HttpStatusCode.Created);
        }

        [Theory]
        [MemberData(nameof(GetRandomUser))]
        public async Task Delete(UserDto user)
        {
            using HttpClient client = _factory.CreateClient();
            HttpResponseMessage responsePost = await PostInternal(user, client);
            Assert.True(responsePost.StatusCode == HttpStatusCode.Created);

            var inserted = await responsePost.Content.ReadFromJsonAsync<UserDto>();
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
