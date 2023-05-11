using ClothesShopWebAPI.IntegrationTests;
using System.Net;

namespace ClothesShopTests.EndpointTests
{
    public class ReviewControllerEndpointTests : IClassFixture<AppInstance>
    {
        private readonly AppInstance _instance;
        public ReviewControllerEndpointTests(AppInstance instance)
        {
            _instance = instance;
        }

        [Fact]
        public async Task TestGetAllReview()
        {
            var client = _instance.CreateClient();
            var result = await client.GetAsync("api/Review");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }
    }
}