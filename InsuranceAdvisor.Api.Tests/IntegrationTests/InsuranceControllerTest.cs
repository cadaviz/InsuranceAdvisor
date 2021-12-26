using InsuranceAdvisor.Api.Tests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace InsuranceAdvisor.Api.Tests.IntegrationTests
{
    public class InsuranceControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public InsuranceControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task OK()
        {
            // Arrange
            var _client = _factory.CreateClient();


            //var _client = _factory.CreateClient();
            var postRequest = new
            {
                Url = "/Insurance",
                Body = new
                {
                    age = 35,
                    dependents = 2,
                    house = new { ownership_status = "mortgaged" },
                    income = 15000,
                    marital_status = "married",
                    //risk_questions = new int[0, 1, 0],
                    vehicle = new { year = 2018 },
                }
            };

            // Act
            var postResponse = await _client.PostAsync(postRequest.Url, ContentHelper.GetStringContent(postRequest.Body));
            var jsonFromPostResponse = await postResponse.Content.ReadAsStringAsync();

            // Assert
            postResponse.EnsureSuccessStatusCode();

        }
    }
}
