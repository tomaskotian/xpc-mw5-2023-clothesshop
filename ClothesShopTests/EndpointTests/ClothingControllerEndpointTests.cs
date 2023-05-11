using ClothesShopWebAPI.IntegrationTests;
using System.Net;

namespace ClothesShopTests.EndpointTests
{
    public class ClothingControllerEndpointTests : IClassFixture<AppInstance>
    {
        private readonly AppInstance _instance;
        public ClothingControllerEndpointTests(AppInstance instance)
        {
            _instance = instance;
        }

        [Fact]
        public async Task TestGetAllClothing()
        {
            var client = _instance.CreateClient();
            var result = await client.GetAsync("api/Clothing");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }

        [Fact]
        public async Task TestGetClothingFiltered()
        {
            var client = _instance.CreateClient();
            var result = await client.GetAsync("api/Clothing/details");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }
    }
}