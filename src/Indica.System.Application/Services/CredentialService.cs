using Indica.System.Application.Interfaces;
using Indica.System.Domain.Interfaces;
using Indica.System.Domain.Entities;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace Indica.System.Application.Services
{
    public class CredentialService : ICredentialService
    {
        private readonly IConfiguration configuration;
        private readonly ICredentialRepository credentialRepository;
        public CredentialService
        (
            IConfiguration configuration,
            ICredentialRepository credentialRepository
        )
        {
            this.configuration = configuration;
            this.credentialRepository = credentialRepository;
        }

        public async Task<string> GetPassHash(string password)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(password);
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            var hash = BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
            return hash;
        }

        public async Task<Employer?> ValidateUser(int registry, string password)
        {
            var passhash = await GetPassHash(password);
            return (await credentialRepository.GetSingleOrDefaultByExpressionAsync(
                c => c.IdEmployer == registry && c.PassHash == passhash))?.Employer;
        }

        public async Task<string> GenerateToken(Employer employer)
        {
            var secret = configuration["Jwt:Key"] ??
                throw new InvalidOperationException("A configuração `Jwt:Key` não foi definida!");
            var issuer = configuration["Jwt:Issuer"] ??
                throw new InvalidOperationException("A configuração `Jwt:Issuer` não foi definida!");
            var audience = configuration["Jwt:Audience"] ??
                throw new InvalidOperationException("A configuração `Jwt:Audience` não foi definida!");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, employer.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, employer.FullName ?? string.Empty)
                // TODO - Add more claims as needed
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Employer?> ValidateToken(string token)
        {
            var secret = configuration["Jwt:Key"] ??
                throw new InvalidOperationException("A configuração `Jwt:Key` não foi definida!");
            var issuer = configuration["Jwt:Issuer"] ??
                throw new InvalidOperationException("A configuração `Jwt:Issuer` não foi definida!");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secret);
            var issuerSiginingKey = new SymmetricSecurityKey(key);
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = issuerSiginingKey,
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
            tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value);
            return (await credentialRepository.GetSingleOrDefaultByExpressionAsync(
                c => c.IdEmployer == userId))?.Employer;
        }
    }
}