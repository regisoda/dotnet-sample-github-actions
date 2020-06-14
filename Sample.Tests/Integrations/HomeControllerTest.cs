using SampleAPI;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System;
using Xunit.Abstractions;

namespace Sample.Tests.Integrations
{
    public class HomeControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly ITestOutputHelper _output;

        public HomeControllerTest(WebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _factory = factory;
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            _output = output;
        }

        [Fact]
        public async Task GetReturnsOk_When_ValidateHealhtyEndpoint()
        {
            var isHealthyEndpoint = "/healthy";
            var response = await _client.GetAsync(isHealthyEndpoint);
            var content = await response.Content.ReadAsStringAsync();
            _output.WriteLine("Content: [{0}]", content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
