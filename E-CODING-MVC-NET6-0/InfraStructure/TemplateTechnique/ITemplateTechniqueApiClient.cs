using _4___E_CODING_DAL;
using E_CODING_MVC_NET6_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{
    public interface ITemplateTechniqueApiClient
    {
        Task<List<TemplateTechniqueVM>> GetAllTemplateTechnique(string api);
        Task<TemplateTechniqueVM> GetTemplateTechnique(string api);
        Task<TemplateTechniqueItemVM> DetailsTemplateTechniqueItem(string api);
        Task<List<TemplateTechniqueItemVM>> DetailsTemplateTechniqueItems(string api);
        Task EditTemplateTechniqueItem(string api, StringContent client);
        Task PostTemplateTechnique(string api, StringContent client);
        Task PostTemplateTechniqueItem(string api, StringContent client);
        void DeleteTemplateTechnique(string api);
    }



    
}
