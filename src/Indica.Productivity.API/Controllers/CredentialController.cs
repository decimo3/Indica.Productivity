using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Indica.Productivity.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CredentialController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly ICredentialService service;
        private readonly CookieOptions options;
        private readonly string cookieName;
        public CredentialController
        (
            ICredentialService service,
            IConfiguration configuration,
            ILogger<CredentialController> logger
        )
        {
            this.service = service;
            this.logger = logger;
            this.cookieName = configuration["Cookies:Auth"] ??
                throw new InvalidOperationException("Cookie de autenticação não configurado!");
            this.options = new CookieOptions()
            {
                Path = "/",
                Secure = false, // define a cookie como somente será enviado via HTTPS.
                HttpOnly = true, // define a cookie como não acessível por JavaScript.
                SameSite = SameSiteMode.Strict, // helps against CSRF
                Expires = DateTime.Now.AddDays(7) // define prazo de expiração para daqui a 7 dias
            };
        }

        [HttpPost]
        public async Task<IActionResult> PostLogin([FromBody] AuthRequestDTO login)
        {
            var user = await service.ValidateUser(login.Registry, login.Password);
            if (user is null)
                return Unauthorized("Usuário ou senha incorretos!");
            var token = await service.GenerateToken(user);
            Response.Cookies.Append(cookieName, token, options);
            var response = new AuthResponseDTO()
            {
                UserId = user.Id,
                Registry = user.ClientRegistry,
                FullName = user.FullName
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetInfo()
        {
            if (!Request.Cookies.TryGetValue(cookieName, out string? token))
                return Unauthorized("Usuário deveria estar logado!");
            var user = await service.ValidateToken(token);
            if (user is null)
                return Unauthorized("Token inválido ou expirado.");
            var response = new AuthResponseDTO()
            {
                UserId = user.Id,
                Registry = user.ClientRegistry,
                FullName = user.FullName
            };
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete(cookieName, options);
            return Ok("Usuário deslogado com sucesso!");
        }
    }
}