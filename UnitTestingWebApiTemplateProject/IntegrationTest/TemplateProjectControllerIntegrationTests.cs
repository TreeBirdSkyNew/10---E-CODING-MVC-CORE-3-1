using _4___E_CODING_DAL.Models;
using E_CODING_MVC_NET6_0.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestingWebApiTemplateProject.IntegrationTest
{
    
    public class TemplateProjectControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;
        public TemplateProjectControllerIntegrationTests(TestingWebAppFactory<Program> factory)
            => _client = factory.CreateClient();

        [Fact]
        public async Task Index_WhenCalled_ReturnsApplicationForm2()
        {
            var response = await _client.GetAsync("/api/TemplateProject/Index");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
        }

        [Fact]
        public async Task Index_WhenCalled_ReturnsApplicationForm()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/TemplateProject/Create");

            TemplateProjectVMForCreation project = new TemplateProjectVMForCreation()
            {
                TemplateProjectName = "TemplateProjectName3",
                TemplateProjectTitle = "TemplateProjectTitle3",
                TemplateProjectDescription = "TemplateProjectDescription3",
                TemplateProjectVersion = "TemplateProjectVersion3",
                TemplateProjectVersionNet = "TemplateProjectVersionNet3",
            };
            string serialized = JsonConvert.SerializeObject(project); 
            HttpContent stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            postRequest.Content = stringContent;

            var response = await _client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("TemplateProjectName3", responseString);
            Assert.Contains("TemplateProjectTitle3", responseString);

            var responseIndex = await _client.GetAsync("/api/TemplateProject/Index");
            responseIndex.EnsureSuccessStatusCode();
            var responseStringIndex = await responseIndex.Content.ReadAsStringAsync();
            Assert.NotNull(responseStringIndex);
            Assert.Contains("TemplateProjectName3", responseString);
            Assert.Contains("TemplateProjectTitle3", responseString);
        }
    }

    

}
