using AngleSharp.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApplication.IntegrationTests
{
    public class WebApplicationTests : IClassFixture< WebApplicationFactory<WebApplication.Startup> >
    {
        private readonly WebApplicationFactory<WebApplication.Startup> _factory;


        public WebApplicationTests(WebApplicationFactory<WebApplication.Startup> factory)
        {

            System.Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Sandbox");
            _factory = factory;
        }

        [Fact]
        public void Post_NewSupplier_And_Return_Successful()
        {
            // Arrange
            var requestUri = "/";
            var payload = "{\"companyName\":\"Geraldo e Milena Entulhos Ltda\",\"enterpriseRegistry\":\"01.104.238/0001-20\"}";

            // Arrange
            var client  = _factory.CreateClient();
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = Task.Run(() => client.PostAsync(requestUri, content));
            response.Wait();
            
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
            Assert.Equal("application/json; charset=utf-8",
                response.Result.Content.Headers.ContentType.ToString());
        }

    }
}
