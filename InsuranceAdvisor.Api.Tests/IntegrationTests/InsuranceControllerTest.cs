using InsuranceAdvisor.Api.Tests.Helpers;
using InsuranceAdvisor.Api.Tests.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
        public async Task Ok()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.Default());

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task BadRequest_RequestWithoutAgeParameter()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithoutAge());

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, postResponse.StatusCode);
        }

        [Fact]
        public async Task Ok_RequestWithValidAgeParameter()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithAge(30));

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task BadRequest_RequestWithAgeParameterBelowLimit()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithAge(default));

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, postResponse.StatusCode);
        }

        [Fact]
        public async Task BadRequest_RequestWithAgeParameterAboveLimit()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithAge(150));

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, postResponse.StatusCode);
        }

        [Fact]
        public async Task Ok_RequestWithoutDependentsParameter()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithoutDependents());

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task BadRequest_RequestWithDependentsParameterBelowLimit()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithDependents(-1));

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, postResponse.StatusCode);
        }

        [Fact]
        public async Task BadRequest_RequestWithDependentsParameterAboveLimit()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithDependents(100));

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, postResponse.StatusCode);
        }

        [Fact]
        public async Task Ok_RequestWithoutHouseParameter()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithoutHouse());

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Ok_RequestWithValidHouseOwnershipStatus()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithHouseOwnershipStatus("mortgaged"));

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task BadRequest_RequestWithInvalidHouseOwnershipStatus()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithHouseOwnershipStatus("invalid"));

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, postResponse.StatusCode);
        }

        [Fact]
        public async Task Ok_RequestWithoutIncomeParameter()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithoutIncome());

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task BadRequest_RequestWithIncomeParameterBelowLimit()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithIncome(-1m));

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, postResponse.StatusCode);
        }

        [Fact]
        public async Task BadRequest_RequestWithoutMaritalStatusParameter()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithoutMaritalStatus());

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, postResponse.StatusCode);
        }

        [Fact]
        public async Task Ok_RequestWithValidMaritalStatusParameter()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithMaritalStatus("married"));

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task BadRequest_RequestWithInvalidMaritalStatusParameter()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithMaritalStatus("invalid"));

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, postResponse.StatusCode);
        }

        [Fact]
        public async Task BadRequest_RequestWithoutRiskQuestionsParameter()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithoutRiskQuestions());

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, postResponse.StatusCode);
        }

        [Fact]
        public async Task BadRequest_RequestWithInvalidQuantityOfRiskQuestions()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithRiskQuestions(new List<int> { 1, 0 }));

            // Act
            var postResponse = await PostRequest(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, postResponse.StatusCode);
        }

        [Fact]
        public async Task Ok_RequestWithValidQuantityOfRiskQuestions()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithRiskQuestions(new List<int> { 1, 0, 1 }));

            // Act
            HttpResponseMessage postResponse = await PostRequest(request);

            // Assert
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Ok_RequestWithoutVehicleParameter()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithoutVehicle());

            // Act
            HttpResponseMessage postResponse = await PostRequest(request);

            // Assert
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Ok_RequestWithValidVehicleYear()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithVehicle(DateTime.Now.Year));

            // Act
            HttpResponseMessage postResponse = await PostRequest(request);

            // Assert
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task BadRequest_RequestWithInvalidVehicleYear()
        {
            // Arrange
            var request = CreatePostRequest(InsuranceBodyBuilder.WithVehicle(2));

            // Act
            HttpResponseMessage postResponse = await PostRequest(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, postResponse.StatusCode);
        }

        private dynamic CreatePostRequest(object body)
        {
            return new
            {
                Url = "/Insurance",
                Body = body
            };
        }

        private Task<HttpResponseMessage> PostRequest(dynamic request)
        {
            var client = _factory.CreateClient();
            return client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
        }
    }
}
