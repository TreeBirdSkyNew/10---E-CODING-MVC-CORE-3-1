using _4___E_CODING_DAL;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using E_CODING_MVC_NET6_0.Models;

namespace E_CODING_MVC_NET6_0
{
      
    public class TemplateTechniqueApiClient : ITemplateTechniqueApiClient
    {
        protected HttpClient _clientTechnique = new HttpClient();

        public TemplateTechniqueApiClient(HttpClient clientTechnique)
        {
            _clientTechnique = clientTechnique;
        }

        public async Task<List<TemplateTechniqueVM>> GetAllTemplateTechnique(string api)
        {
            var response = await _clientTechnique.GetAsync(api);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<TemplateTechniqueVM>>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }

        async public Task<TemplateTechniqueVM> GetTemplateTechnique(string api)
        {
            var response = await _clientTechnique.GetAsync(api);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TemplateTechniqueVM>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }

        async public Task<List<TemplateTechniqueItemVM>> DetailsTemplateTechniqueItems(string api)
        {
            var response = await _clientTechnique.GetAsync(api);
            var responseString = await response.Content.ReadAsStringAsync();
            var results = JsonSerializer.Deserialize<List<TemplateTechniqueItemVM>>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return results;
        }

        public async Task PostTemplateTechnique(string api, StringContent content)
        {
            var response = await _clientTechnique.PostAsync(api, content);
            response.EnsureSuccessStatusCode();
        }

        
        public async void DeleteTemplateTechnique(string api)
        {
            HttpResponseMessage response = await _clientTechnique.DeleteAsync(api);
            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task<TemplateTechniqueItemVM> DetailsTemplateTechniqueItem(string api)
        {
            var response = await _clientTechnique.GetAsync(api);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TemplateTechniqueItemVM>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }

            
        public async Task EditTemplateTechniqueItem(string api, StringContent content)
        {
            var response = await _clientTechnique.PostAsync(api, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task PostTemplateTechniqueItem(string api, StringContent content)
        {
            var response = await _clientTechnique.PostAsync(api, content);
            response.EnsureSuccessStatusCode();
        }

            
    }
    
}
