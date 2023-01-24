using _4___E_CODING_DAL;
using E_CODING_MVC_NET6_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{
    public interface ITemplateResultApiClient
    {
        public Task<List<TemplateResultVM>> GetAllTemplateResult(string api);
        public Task<TemplateResultVM> GetTemplateResult(string api);
        public Task<TemplateResulItemVM> GetTemplateResultItem(string api);
        public Task<List<TemplateResulItemVM>> GetTemplateResultItems(string api);
        public Task<TemplateResultVM> PostTemplateResult(string api, StringContent client);
        public Task<TemplateResulItemVM> PostTemplateResultItem(string api, StringContent client);
        public Task DeleteTemplateResult(string api);
        public Task DeleteTemplateResultItem(string api);
        public Task<TemplateResulItemVM> NewTemplateResultItemId(string api);

    }
}
