using ClothesShopWebAPI.IntegrationTests;
using System.Net;

namespace ClothesShopTests.EndpointTests
{
    public class AccessoriesControllerEndpointTests : IClassFixture<AppInstance>
    {
        private readonly AppInstance _instance;
        public AccessoriesControllerEndpointTests(AppInstance instance)
        {
            _instance = instance;
        }

        [Fact]
        public async Task TestGetAllAccessories()
        {
            var client = _instance.CreateClient();
            var result = await client.GetAsync("api/Accessories");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }

        [Fact]
        public async Task TestGetAccessoriesFiltered()
        {
            var client = _instance.CreateClient();
            var result = await client.GetAsync("api/Accessories/details");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }
    }
}