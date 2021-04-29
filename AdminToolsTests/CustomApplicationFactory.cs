//source: https://auth0.com/blog/xunit-to-test-csharp-code/
using AdminToolAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AdminToolsTests
{
    /// <summary>
    /// A factory for configuring web hosts for testing
    /// configure the issuer, sigining key, and audience
    /// </summary>
    /// <typeparam name="TStartup"></typeparam>
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.PostConfigure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, OptionsBuilderConfigurationExtensions =>
                {
                    OptionsBuilderConfigurationExtensions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = FakeJwtManager.SecurityKey,
                        ValidIssuer = FakeJwtManager.Issuer,
                        ValidAudience = FakeJwtManager.Audience
                    };
                });
            });
        }
    }
}