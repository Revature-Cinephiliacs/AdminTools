//source: https://auth0.com/blog/xunit-to-test-csharp-code/
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using AdminToolsModels.LogicModels;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AdminToolsTests
{
    public class IntegrationTests : IClassFixture<CustomWebApplicationFactory<AdminToolAPI.Startup>>
    {
        private readonly HttpClient _httpClient;
        public IntegrationTests(CustomWebApplicationFactory<AdminToolAPI.Startup> factory)
        {
            _httpClient = factory.CreateClient();
        }
        ///<summary>
        /// Tests the endpoints for creating a ticket
        ///</summary>
        [Fact]
        public async Task TestCreateTicketEndpoint()
        {
            string userID = "USERID123";
            string description = "report description";
            DateTime time = DateTime.Now;
            ReportModel model = new ReportModel()
            {
                ReportId = Guid.NewGuid().ToString(),
                ReportEntityType = "Review",
                ReportEnitityId = userID,
                ReportDescription = description,
                ReportTime = time
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "reports");
            request.Content = new StringContent(JsonSerializer.Serialize(model));
            var accessToken = FakeJwtManager.GenerateJwtToken();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await _httpClient.SendAsync(request);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
