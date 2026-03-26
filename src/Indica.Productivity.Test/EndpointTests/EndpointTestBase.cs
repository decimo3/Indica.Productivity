using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Indica.Productivity.Web;
using Indica.Productivity.Infra;

namespace Indica.Productivity.Test
{
    public class MockWebApi : WebApplicationFactory<Program> { }

    public abstract class EndpointTestBase : IClassFixture<MockWebApi>
    {
        protected readonly HttpClient _client;

        public EndpointTestBase(MockWebApi factory)
        {
            _client = factory.CreateClient();
            using var scope = factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ProductivityContext>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        protected async Task<HttpResponseMessage> PostAsync(string path, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync(path, content);
        }

        protected async Task<HttpResponseMessage> GetAsync(string path)
        {
            return await _client.GetAsync(path);
        }

        protected async Task<HttpResponseMessage> PutAsync(string path, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PutAsync(path, content);
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string path)
        {
            return await _client.DeleteAsync(path);
        }
    }
}
