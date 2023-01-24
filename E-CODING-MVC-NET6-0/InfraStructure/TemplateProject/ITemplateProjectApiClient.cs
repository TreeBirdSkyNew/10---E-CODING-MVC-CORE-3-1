using _4___E_CODING_DAL;
using E_CODING_MVC_NET6_0.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{
    public interface ITemplateProjectApiClient
    {
        Task<List<TemplateProjectVM>> GetAllTemplateProject(string api);
        Task<TemplateProjectVM> GetTemplateProject(string api);
        Task<List<TemplateTechniqueVM>> DetailsTechnique(string api);
        Task<List<TemplateFonctionnelEntityVM>> DetailsEntity(string api);
        Task<TemplateProjectVM> PostTemplateProject(string api, StringContent client);
        Task DeleteTemplateProject(string api);
    }
}
