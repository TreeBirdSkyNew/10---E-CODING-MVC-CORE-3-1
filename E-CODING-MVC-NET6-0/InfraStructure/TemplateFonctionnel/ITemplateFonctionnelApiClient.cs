using _4___E_CODING_DAL;
using E_CODING_MVC_NET6_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{
    public interface ITemplateFonctionnelApiClient
    {
        Task<List<TemplateFonctionnelVM>> GetAllTemplateFonctionnel(string api);
        Task<TemplateFonctionnelVM> GetTemplateFonctionnel(string api);
        Task<List<TemplateFonctionnelEntityVM>> GetTemplateFonctionnelEntities(string api);
        Task<TemplateFonctionnelEntityVM> GetTemplateFonctionnelEntity(string api);
        Task<List<TemplateFonctionnelPropertyVM>> GetTemplateFonctionnelProperties(string api);
        Task<TemplateFonctionnelVM> PostTemplateFonctionnel(string api, StringContent client);
        Task DeleteTemplateFonctionnel(string api);
        Task<TemplateFonctionnelEntityVM> PostTemplateFonctionnelEntity(string api, StringContent client);
        Task DeleteTemplateFonctionnelEntity(string api);
        Task<TemplateFonctionnelPropertyVM> PostTemplateFonctionnelProperty(string api, StringContent client);
        Task DeleteTemplateFonctionnelProperty(string api);
    }
}
