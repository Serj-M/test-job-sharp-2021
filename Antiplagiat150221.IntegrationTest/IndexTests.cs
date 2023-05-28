using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Antiplagiat150221;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace Antiplagiat150221.IntegrationTest
{
    public class IndexTests
    {
        private readonly HttpClient _client;

        public IndexTests()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("GET", "en")]
        [InlineData("GET", "ru")]
        public async Task IndexGetTest(string method, string lang)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"/Home/ChangeLanguage?name={lang}");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
