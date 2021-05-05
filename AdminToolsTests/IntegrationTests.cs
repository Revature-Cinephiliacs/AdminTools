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
    }
}
