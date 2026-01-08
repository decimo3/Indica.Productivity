using System.Net;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Indica.Productivity.API;
using Indica.Productivity.Infra;

namespace Indica.Productivity.Test
{
    public class MockWebApi : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Obtain the DbContext service to apply the data seed.
                var serviceProvider = services.BuildServiceProvider();
                using var scope = serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetService<ProductivityContext>() ??
                    throw new InvalidOperationException("The `DbContext` service could not be obtained!");
                var mockData = File.ReadAllText("Samples/test_queries.sql");
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Database.ExecuteSqlRaw(mockData);
            });
        }
    }
    public abstract class EndpointTestBase : IClassFixture<MockWebApi>
    {
        protected readonly HttpClient _client;
        public EndpointTestBase(MockWebApi factory)
        {
            _client = factory.CreateClient();
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
