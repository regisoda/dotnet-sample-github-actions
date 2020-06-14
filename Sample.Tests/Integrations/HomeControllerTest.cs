using SampleAPI;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace Sample.Tests.Integrations
{
    public class HomeControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient client;
        private readonly WebApplicationFactory<Startup> factory;

        public HomeControllerTest(WebApplicationFactory<Startup> factory)
        {
            client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            this.factory = factory;
        }

        [Fact]
        public async Task GetReturnsOk_When_ValidateIsLiveEndpoint()
        {
            var isLiveEndpoint = "/healthy";
            var response = await client.GetAsync(isLiveEndpoint);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
