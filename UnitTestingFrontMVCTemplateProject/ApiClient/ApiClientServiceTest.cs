using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using E_CODING_MVC_NET6_0.InfraStructure.ApiClient;
using Moq.Protected;
using E_CODING_MVC_NET6_0.InfraStructure.Project;
using _4___E_CODING_DAL.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace UnitTestingFrontMVCTemplateProject.ApiClient
{
    public class ApiClientServiceTest
    {
        private Mock<IHttpClientFactory> _httpClientFactory;
        public ApiClientServiceTest()
        {
            _httpClientFactory = new Mock<IHttpClientFactory>();
        }

        [Fact]
        public async Task GetListTest()
        {
            // Arrange
            ApiClientService _apiClientService = new ApiClientService(_httpClientFactory.Object);

            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            HttpResponseMessage result = new HttpResponseMessage();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(result)
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://dev-api.mfa.net:444/sms/")
            };

            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            Mock<ILogger<TemplateProjectApiClient>> _logger = new Mock<ILogger<TemplateProjectApiClient>>();
            IConfiguration _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            TemplateProjectApiClient _instanceMock = new TemplateProjectApiClient(
                    _logger.Object,
                    _configuration,
                    mockHttpClientFactory.Object);

            HttpResponseMessage response = await _instanceMock.GetList<TemplateProject>(
                "clientName",
                "urlApi");

            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1), // we expected a single external request
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>());
        }
    }
}
