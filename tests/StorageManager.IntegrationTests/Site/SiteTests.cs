using Microsoft.AspNetCore.Mvc.Testing;

namespace StorageManager.IntegrationTests.Site
{

    public class SiteTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
    private readonly WebApplicationFactory<Program> _factory;

        public SiteTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/site")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            var client = _factory.CreateClient();
        }
    }
}
