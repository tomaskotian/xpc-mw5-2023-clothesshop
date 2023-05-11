using ClothesShopWebAPI.IntegrationTests;
using System.Net;

namespace ClothesShopTests.EndpointTests
{
    public class ShoesControllerEndpointTests : IClassFixture<AppInstance>
    {
        private readonly AppInstance _instance;
        public ShoesControllerEndpointTests(AppInstance instance)
        {
            _instance = instance;
        }

        [Fact]
        public async Task TestGetAllShoes()
        {
            var client = _instance.CreateClient();
            var result = await client.GetAsync("api/Shoes");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }

        [Fact]
        public async Task TestGetShoesFiltered()
        {
            var client = _instance.CreateClient();
            var result = await client.GetAsync("api/Shoes/details");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }
    }
}