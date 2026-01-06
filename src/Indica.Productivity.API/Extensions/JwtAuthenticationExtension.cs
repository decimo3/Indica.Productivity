using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Indica.System.API.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddJwtAuthentication
        (
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var secret = configuration["Jwt:Key"] ??
                throw new InvalidOperationException("Chave de autenticação não configurada!");
            var issuerName = configuration["Jwt:Issuer"] ??
                throw new InvalidOperationException("Chave de autenticação não configurada!");
            var cookieName = configuration["Cookies:Auth"] ??
                throw new InvalidOperationException("Cookie de autenticação não configurado!");
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuerName,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        if (context.Request.Cookies.ContainsKey(cookieName))
                        {
                            context.Token = context.Request.Cookies[cookieName];
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            return services;
        }
    }
}
