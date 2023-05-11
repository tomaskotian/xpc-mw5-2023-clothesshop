using ClothesShopWebAPI.IntegrationTests;
using System.Net;

namespace ClothesShopTests
{
    public class ControllerEndpointTests : IClassFixture<AppInstance>
    {
        private readonly AppInstance _instance;
        public ControllerEndpointTests(AppInstance instance)
        {
            _instance = instance;
        }

        [Fact]
        public async Task Test1()
        {
            var client = _instance.CreateClient();
            var result = await client.GetAsync("api/Accessories");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }
    }
}