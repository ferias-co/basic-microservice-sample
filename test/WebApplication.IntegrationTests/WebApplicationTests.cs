using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApplication.IntegrationTests
{
    public class WebApplicationTests : IClassFixture< WebApplicationFactory<Startup> >
    {


        public HttpClient Client { get; }

        public WebApplicationTests(WebApplicationFactory<Startup> factory)
        {
            StartupSettings.Environment();
            Client = factory.CreateClient();
        }

        [Fact]
        public void CreateNewSupplier_PostRequest_Return_StatusCode_And_ApplicationJson() 
        {
            // Arrange
            var requestedUri = "/";
            var payload = "{ \"companyName\":\"Geraldo e Milena Entulhos Ltda\","+
                            "\"enterpriseRegistry\":\"01.104.238/0001-20\" }";

            // Act
            Task<HttpResponseMessage> response = PostRequest(requestedUri, payload);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
            Assert.Equal("application/json; charset=utf-8",
                response.Result.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public void QuerySupplier_GetRequest_Return_StatusCode_And_ApplicationJson()
        {
            // Arrange
            var payload = "{ \"companyName\":\"Milho Lactinios Ltda\"," +
                            "\"enterpriseRegistry\":\"01.103.238/0001-21\" }";

            Task<HttpResponseMessage> postResponse = PostRequest("/", payload);
            dynamic jObj = DeserializePostResponse(postResponse);

            // Act
            Task<HttpResponseMessage> response = GetRequest("/" + jObj["id"]);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
            Assert.Equal("application/json; charset=utf-8",
                response.Result.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public void CreateNewSupplierInvalid_PostRequest_Return_BadRequest()
        {
            // Arrange
            var payload = "{ }";
            Task<HttpResponseMessage> response = PostRequest("/", payload);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.Result.StatusCode);
        }



        private static dynamic DeserializePostResponse(Task<HttpResponseMessage> postResponse)
        {
            return (JObject)JsonConvert.DeserializeObject(postResponse.Result.Content.ReadAsStringAsync().Result);
        }


        private Task<HttpResponseMessage> GetRequest(string requestedUri)
        {
            
            var response = Task.Run(() => Client.GetAsync(requestedUri));
            response.Wait();
            return response;
        }


        private Task<HttpResponseMessage> PostRequest(string requestedUri, string payload)
        {
            HttpContent content = new StringContent(payload,
                                        Encoding.UTF8, "application/json");


            // Act
            var response = Task.Run(() => Client.PostAsync(requestedUri, content));
            response.Wait();
            return response;
        }
    }
}
