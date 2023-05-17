using E_CODING_MVC_NET6_0.InfraStructure.ApiClient;
using E_CODING_MVC_NET6_0.InfraStructure.Project;
using E_CODING_MVC_NET6_0.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingFrontMVCTemplateProject.Mock
{
    public class FakeTemplateProjectApiClient : FakeApiClientService,ITemplateProjectApiClient
    {
        private Mock<IHttpClientFactory> _httpClientFactory;
        private Mock<ILogger<TemplateProjectApiClient>> _logger;
        private Mock<IConfiguration> _configuration;

        public FakeTemplateProjectApiClient(
            Mock<ILogger<TemplateProjectApiClient>> logger,
            Mock<IConfiguration> configuration,
            Mock<IHttpClientFactory> httpClientFactory) : base(httpClientFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public Task DeleteTemplateProject(string clientName, string api)
        {
            throw new NotImplementedException();
        }

        public Task<List<TemplateProjectVM?>> GetAllTemplateProject(string clientName, string api)
        {
            throw new NotImplementedException();
        }

        public Task<TemplateProjectVM?> GetTemplateProject(string clientName, string api)
        {
            throw new NotImplementedException();
        }

        public Task PostTemplateProject(string clientName, string api, StringContent client)
        {
            throw new NotImplementedException();
        }
    }
}
