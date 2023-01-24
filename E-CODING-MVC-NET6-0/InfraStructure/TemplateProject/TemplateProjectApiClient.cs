using _4___E_CODING_DAL;
using E_CODING_MVC_NET6_0.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{
    public class TemplateProjectApiClient : ITemplateProjectApiClient
    {
        private HttpClient _clientProject = new HttpClient();
        public TemplateProjectApiClient(HttpClient clientProject) 
        {
            _clientProject = clientProject;
        }

        public async Task<List<TemplateProjectVM>> GetAllTemplateProject(string api)
        {
            HttpResponseMessage response = await _clientProject.GetAsync(api);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<List<TemplateProjectVM>>(content);
            return results;
        }

        public async Task<TemplateProjectVM> GetTemplateProject(string api)
        {
            HttpResponseMessage response = await _clientProject.GetAsync(api);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<TemplateProjectVM>(content);
            return results;
        }

        public async Task<List<TemplateTechniqueVM>> DetailsTechnique(string api)
        {
            HttpResponseMessage response = await _clientProject.GetAsync(api);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<List<TemplateTechniqueVM>>(content);
            return results;
        }

        public async Task<List<TemplateFonctionnelEntityVM>> DetailsEntity(string api)
        {
            HttpResponseMessage response = await _clientProject.GetAsync(api);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<List<TemplateFonctionnelEntityVM>>(content);
            return results;
        }

        

        public async Task<TemplateProjectVM> PostTemplateProject(string api, StringContent client)
        {
            HttpResponseMessage response = await _clientProject.PostAsync(api, client);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<TemplateProjectVM>(content);
            return results;
        }

        public async Task DeleteTemplateProject(string api)
        {
            HttpResponseMessage response = await _clientProject.DeleteAsync(api);
            var content = await response.Content.ReadAsStringAsync();
        }

        
    }
}
