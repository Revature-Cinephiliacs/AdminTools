//source: https://auth0.com/blog/xunit-to-test-csharp-code/
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace AdminToolsTests
{
    
    public static class FakeJwtManager
    {
        /// <summary>
        /// Generates a Mock Jwt Token
        /// </summary>
        /// <returns></returns>
        public static string Issuer { get; } = Guid.NewGuid().ToString();
        public static string Audience { get; } = Guid.NewGuid().ToString();
        public static SecurityKey SecurityKey { get; }
        public static SigningCredentials SigningCredentials { get; }
        public static Claim[] Claims { get; }


        public static readonly JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        public static readonly RandomNumberGenerator generator = RandomNumberGenerator.Create();
        public static readonly byte[] key = new byte[32];

        static FakeJwtManager()
        {
            generator.GetBytes(key);
            Claims = new Claim[] {
                new Claim(JwtRegisteredClaimNames.Sub, "testuser"),
                new Claim(JwtRegisteredClaimNames.Email, "testemail@email.com"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            SecurityKey = new SymmetricSecurityKey(key) { KeyId = Guid.NewGuid().ToString() };
            SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
        }

        /// <summary>
        /// Generates a Mock Jwt Token
        /// </summary>
        /// <returns></returns>
        public static string GenerateJwtToken()
        {
            return jwtSecurityTokenHandler.WriteToken(new JwtSecurityToken(Issuer, Audience, null, null, DateTime.UtcNow.AddMinutes(10), SigningCredentials));
        }
    }
}
