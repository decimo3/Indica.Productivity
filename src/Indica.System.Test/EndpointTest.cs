using System.Net;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Indica.System.API;
using Indica.System.Infra;

namespace Indica.System.Test
{
    public class MockWebapi : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove o DbContext real
                var descriptor = services.SingleOrDefault(d =>
                    d.ServiceType == typeof(ProductivityContext));
                if (descriptor != null)
                    services.Remove(descriptor);
                // Adiciona um DbContext em memória
                services.AddDbContext<ProductivityContext>(options =>
                    options.UseSqlite("Data Source=TestsResults.db"));
                // Obtém o serviço DbContext para aplicar o dataseed
                var serviceProvider = services.BuildServiceProvider();
                using var scope = serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetService<ProductivityContext>() ??
                    throw new InvalidOperationException("Não foi possível obter o serviço `DbContext`.");
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            });
        }
    }
    public class EndpointTest : IClassFixture<MockWebapi>
    {
        private readonly HttpClient _client;
        public EndpointTest(MockWebapi factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task PostRequest_ProcessSingle_ReturnSucess()
        {
            // Arrange
            var url = "/api/process";
            var json = "{\"processName\":\"CORE\",\"id\":1}";
            var payload = new StringContent(json,
                Encoding.UTF8, "application/json");
            // Act test
            var response = await _client.PostAsync(url, payload);
            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        [Fact]
        public async Task PutRequest_ProcessSingle_ReturnFailure()
        {
            // Arrange
            var url = "/api/process";
            var json = "{\"processName\":\"COREASDASDASDASDASDAS\"}";
            var payload = new StringContent(json,
                Encoding.UTF8, "application/json");
            // Act test
            var response = await _client.PostAsync(url, payload);
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task PostResquest_FieldTeamSingle_ReturnSucess()
        {
            // Arrange
            var url = "/api/fieldteam";
            var json = "{\"Date\": \"2025-07-15\",\"Order\": 16590,\"Plate\": \"SIN-2B41\",\"Resource\": \"AXOI - Indica - Equipe 001\",\"ActivityName\": \"ANEXO IV\",\"EmployerRegistry1\": 2272046,\"EmployerName1\": \"Claudio Ferreira CASSIANO\",\"EmployerRegistry2\": 2266958,\"EmployerName2\": \"VINICIUS da Silva Franca de ASSIS\",\"Cellphone\": 999881467,\"SupervisorRegistry\": 2255625,\"SupervisorName\": \"ALEX OTAVIO Figueiredo\",\"WorkArea\": \"CAMPO GRANDE\"}";
            var payload = new StringContent(json, Encoding.UTF8, "application/json");
            // Act test
            var response = await _client.PostAsync(url, payload);
            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
