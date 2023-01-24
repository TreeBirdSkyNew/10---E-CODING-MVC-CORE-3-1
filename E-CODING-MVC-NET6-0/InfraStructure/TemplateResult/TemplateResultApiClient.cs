using _4___E_CODING_DAL;
using E_CODING_MVC_NET6_0.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{
    public class TemplateResultApiClient : ITemplateResultApiClient
    {
        private HttpClient _clientResult;

        public TemplateResultApiClient(HttpClient clientResult) 
        {
            _clientResult = clientResult;
        }

        public async Task<List<TemplateResultVM>> GetAllTemplateResult(string api)
        {
            HttpResponseMessage response = await _clientResult.GetAsync(api);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<List<TemplateResultVM>>(content);
            return results;
        }

        public async Task<TemplateResultVM> GetTemplateResult(string api)
        {
            HttpResponseMessage response = await _clientResult.GetAsync(api);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<TemplateResultVM>(content);
            return results;
        }

        public async Task<TemplateResulItemVM> GetTemplateResultItem(string api)
        {
            HttpResponseMessage response = await _clientResult.GetAsync(api);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<TemplateResulItemVM>(content);
            return results;
        }

        public async Task<List<TemplateResulItemVM>> GetTemplateResultItems(string api)
        {
            HttpResponseMessage response = await _clientResult.GetAsync(api);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<List<TemplateResulItemVM>>(content);
            return results;
        }

        
        public async Task<TemplateResultVM> PostTemplateResult(string api, StringContent client)
        {
            HttpResponseMessage response = await _clientResult.PostAsync(api, client);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<TemplateResultVM>(content);
            return results;
        }

        public async Task<TemplateResulItemVM> PosTemplateResultItem(string api, StringContent client)
        {
            HttpResponseMessage response = await _clientResult.PostAsync(api, client);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<TemplateResulItemVM>(content);
            return results;
        }

        public async Task DeleteTemplateResult(string api)
        {
            HttpResponseMessage response = await _clientResult.DeleteAsync(api);
            var content = await response.Content.ReadAsStringAsync();
        }

        public async Task DeleteTemplateResultItem(string api)
        {
            HttpResponseMessage response = await _clientResult.DeleteAsync(api);
            var content = await response.Content.ReadAsStringAsync();
        }

        public Task<TemplateResulItemVM> PostTemplateResultItem(string api, StringContent client)
        {
            return PosTemplateResultItem(api, client);
        }

        public async Task<TemplateResulItemVM> NewTemplateResultItemId(string api)
        {
            HttpResponseMessage response = await _clientResult.GetAsync(api);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<TemplateResulItemVM>(content);
            return results;
        }
    }
       
    
}
