using E_CODING_MVC_NET6_0.InfraStructure.ApiClient;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingFrontMVCTemplateProject.Mock
{
    public class FakeApiClientService 
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactory;
        public static HttpMessageHandler? Handler { get; set; }
        public static HttpClient Client = new HttpClient();
        public FakeApiClientService(Mock<IHttpClientFactory> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> GetList<TReturn>(string clientName, string urlApi)
        {
            return new HttpResponseMessage();
        }

        public async Task<HttpResponseMessage> GetObject<TReturn>(string clientName, string urlApi)
        {
            return new HttpResponseMessage();
        }

        public async Task<HttpResponseMessage> PostObject<TReturn>(string clientName, string urlApi, StringContent client)
        {
            return new HttpResponseMessage();
        }

        public async Task<HttpResponseMessage> DeleteObject<TReturn>(string clientName, string urlApi)
        {
            return new HttpResponseMessage();
        }
    }
}
