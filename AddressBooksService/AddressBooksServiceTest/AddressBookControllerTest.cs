using AddressBooksService;
using AddressBooksService.Model;

using Microsoft.AspNetCore.Mvc.Testing;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace AddressBooksServiceTest
{
    public class AddressBookControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public AddressBookControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        public static IEnumerable<object[]> GetRandomAddressBook()
        {
            return new List<object[]>
            {
                new object[] {
                    new AddressBook() {
                        Cap = "123",
                        CityId = 1,
                        StreetName = "Nome strada",
                        StreetNumber = "Numero strada"
                    },
                },
                new object[] {
                    new AddressBook() {
                        Cap = "456",
                        CityId = 1,
                        StreetName = "Nome strada 2",
                        StreetNumber = "Numero strada 2"
                    } 
                },
                new object[] {
                    new AddressBook() {
                        Cap = "abc",
                        CityId = 2,
                        StreetName = "Nome strada 3",
                        StreetNumber = "Numero strada 3"
                    } 
                },
                new object[] {
                    new AddressBook() {
                        Cap = "def",
                        CityId = 2,
                        StreetName = "Nome strada 4",
                        StreetNumber = "Numero strada 5"
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

        private Task<HttpResponseMessage> PostInternal(AddressBook addressBook, HttpClient client)
        {
            return client.PostAsJsonAsync("/api/v1/address-book", addressBook);
        }

        [Theory]
        [MemberData(nameof(GetRandomAddressBook))]
        public async Task Put(AddressBook addressBook)
        {
            using HttpClient client = _factory.CreateClient();
            HttpResponseMessage responsePost = await PostInternal(addressBook, client);
            Assert.True(responsePost.StatusCode == HttpStatusCode.Created);

            var inserted = await responsePost.Content.ReadFromJsonAsync<AddressBook>();
            Assert.NotNull(inserted);

            addressBook.Cap = $"{addressBook.Cap}_new";
            addressBook.StreetName = $"{addressBook.StreetName}_new";
            addressBook.StreetNumber = $"{addressBook.StreetNumber}_new";
            HttpResponseMessage responseDelete = await client.PutAsJsonAsync($"/api/v1/address-book/{inserted.Id}", addressBook);
            Assert.True(responseDelete.StatusCode is HttpStatusCode.OK);
        }

        [Theory]
        [MemberData(nameof(GetRandomAddressBook))]
        public async Task Add(AddressBook addressBook)
        {
            using HttpClient client = _factory.CreateClient();
            HttpResponseMessage responsePost = await PostInternal(addressBook, client);
            Assert.True(responsePost.StatusCode is HttpStatusCode.Created);
        }

        [Theory]
        [MemberData(nameof(GetRandomAddressBook))]
        public async Task Delete(AddressBook addressBook)
        {
            using HttpClient client = _factory.CreateClient();
            HttpResponseMessage responsePost = await PostInternal(addressBook, client);
            Assert.True(responsePost.StatusCode == HttpStatusCode.Created);
            
            var inserted = await responsePost.Content.ReadFromJsonAsync<AddressBook>();
            Assert.NotNull(inserted);

            HttpResponseMessage responseDelete = await client.DeleteAsync($"/api/v1/address-book/{inserted.Id}");
            Assert.True(responseDelete.StatusCode is HttpStatusCode.OK);
        }

        private Task<HttpResponseMessage> Post(AddressBook addressBook, HttpClient client)
        {
            return client.PostAsJsonAsync("/api/v1/address-book", addressBook);
        }

        [Fact]
        public async Task Get()
        {
            using HttpClient client = _factory.CreateClient();
            using HttpResponseMessage response = await client.GetAsync("/api/v1/address-book");
            Assert.True(response.IsSuccessStatusCode);
        }

        [Theory]
        [MemberData(nameof(GetRandomId))]
        public async Task Gets(int id)
        {
            using HttpClient client = _factory.CreateClient();
            using HttpResponseMessage response = await client.GetAsync($"/api/v1/address-book/{id}");
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
