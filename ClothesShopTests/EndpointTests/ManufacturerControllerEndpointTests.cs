using ClothesShopWebAPI.IntegrationTests;
using System.Net;

namespace ClothesShopTests.EndpointTests
{
    public class ManufacturerControllerEndpointTests : IClassFixture<AppInstance>
    {
        private readonly AppInstance _instance;
        public ManufacturerControllerEndpointTests(AppInstance instance)
        {
            _instance = instance;
        }

        [Fact]
        public async Task TestGetAllManufacturer()
        {
            var client = _instance.CreateClient();
            var result = await client.GetAsync("api/Manufacturer");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }
    }
}