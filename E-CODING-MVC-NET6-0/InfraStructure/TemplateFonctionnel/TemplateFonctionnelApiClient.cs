using _4___E_CODING_DAL;
using E_CODING_MVC_NET6_0.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{
    public class TemplateFonctionnelApiClient : ITemplateFonctionnelApiClient
    {
        private HttpClient _clientFonctionnel;

        public TemplateFonctionnelApiClient(HttpClient clientFonctionnel) 
        {
            _clientFonctionnel = clientFonctionnel;
        }

        public async Task<List<TemplateFonctionnelVM>> GetAllTemplateFonctionnel(string api)
        {
            HttpResponseMessage response = await _clientFonctionnel.GetAsync(api);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<List<TemplateFonctionnelVM>>(content);
            return results;
        }

        public async Task<TemplateFonctionnelVM> GetTemplateFonctionnel(string api)
        {
            HttpResponseMessage response = await _clientFonctionnel.GetAsync(api);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<TemplateFonctionnelVM>(content);
            return results;
        }

        public async Task<TemplateFonctionnelEntityVM> GetTemplateFonctionnelEntity(string api)
        {
            HttpResponseMessage response = await _clientFonctionnel.GetAsync(api);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<TemplateFonctionnelEntityVM>(content);
            return results;
        }

        public async Task<List<TemplateFonctionnelEntityVM>> GetTemplateFonctionnelEntities(string api)
        {
            HttpResponseMessage response = await _clientFonctionnel.GetAsync(api);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<List<TemplateFonctionnelEntityVM>>(content);
            return results;
        }


        public async Task<List<TemplateFonctionnelPropertyVM>> GetTemplateFonctionnelProperties(string api)
        {
            HttpResponseMessage response = await _clientFonctionnel.GetAsync(api);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<List<TemplateFonctionnelPropertyVM>>(content);
            return results;
        }

        public async Task<TemplateFonctionnelVM> PostTemplateFonctionnel(string api, StringContent client)
        {
            HttpResponseMessage response = await _clientFonctionnel.PostAsync(api, client);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<TemplateFonctionnelVM>(content);
            return results;
        }

        public async Task DeleteTemplateFonctionnel(string api)
        {
            HttpResponseMessage response = await _clientFonctionnel.DeleteAsync(api);
            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task<TemplateFonctionnelEntityVM> PostTemplateFonctionnelEntity(string api, StringContent client)
        {
            HttpResponseMessage response = await _clientFonctionnel.PostAsync(api, client);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<TemplateFonctionnelEntityVM>(content);
            return results;
        }

        public async Task DeleteTemplateFonctionnelEntity(string api)
        {
            HttpResponseMessage response = await _clientFonctionnel.DeleteAsync(api);
            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task<TemplateFonctionnelPropertyVM> PostTemplateFonctionnelProperty(string api, StringContent client)
        {
            HttpResponseMessage response = await _clientFonctionnel.PostAsync(api, client);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<TemplateFonctionnelPropertyVM>(content);
            return results;
        }

        public async Task DeleteTemplateFonctionnelProperty(string api)
        {
            HttpResponseMessage response = await _clientFonctionnel.DeleteAsync(api);
            var content = await response.Content.ReadAsStringAsync();
        }

        
    }
}
