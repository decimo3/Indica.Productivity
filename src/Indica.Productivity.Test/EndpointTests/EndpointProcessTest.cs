namespace Indica.Productivity.Test.Endpoints
{
    public class EndpointProcessTest : EndpointTestBase
    {
        private static readonly string BASE_PATH = "/api/process/";

        public EndpointProcessTest(MockWebApi factory) : base(factory) { }

        [Theory]
        [InlineData("{ \"ProcessName\": \"TEST\" }")]
        [InlineData("{ \"ProcessName\": \"NAME\" }")]
        public async Task PostRequestSingleReturnSuccess(string body)
        {
            var response = await PostAsync(BASE_PATH, body);
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        }

        [Theory]
        [InlineData("{ \"ProcessName\": \"test\" }")]
        [InlineData("{ \"ProcessName\": \"TEST STR\" }")]
        [InlineData("{ \"ProcessName\": \"TEST_STR\" }")]
        [InlineData("{ \"ProcessName\": \"TEST 123\" }")]
        [InlineData("{ \"ProcessName\": \"TEST $%#\" }")]
        [InlineData("{ \"ProcessName\": \"TOO_LONG_STR\" }")]
        public async Task PostRequestSingleReturnReject(string body)
        {
            var response = await PostAsync(BASE_PATH, body);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetRequestSingleSuccess()
        {
            var response = await GetAsync(BASE_PATH + 1);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetRequestMultiplesSuccess()
        {
            var response = await GetAsync(BASE_PATH + "/batch/");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(1, "{ \"ProcessName\": \"TEST2\" }")]
        [InlineData(2, "{ \"ProcessName\": \"NAME2\" }")]
        public async Task PutRequestSingleSuccess(int id, string body)
        {
            var response = await PutAsync(BASE_PATH + id, body);
            Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task DeleteRequestSingleSuccess()
        {
            // Arrange
            var payload = "{ \"ProcessName\": \"DELETE\" }";
            await PostAsync(BASE_PATH, payload);
            // Act
            var response = await DeleteAsync(BASE_PATH + 1);
            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}