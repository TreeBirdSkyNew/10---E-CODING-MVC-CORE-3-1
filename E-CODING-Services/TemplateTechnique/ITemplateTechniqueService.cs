using _4___E_CODING_DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Services
{
    public interface ITemplateTechniqueService
    {
        Task<List<TemplateTechnique>> GetAllTemplateTechnique();
        Task<List<TemplateTechnique>> TemplateTechniqueByProject(int id);
        Task<TemplateTechnique> DetailTemplateTechnique(int id);
        Task<TemplateTechnique> CreateTemplateTechnique(TemplateTechnique templateTechnique);
        Task<TemplateTechnique> CreateTemplateTechnique();
        Task<TemplateTechniqueItem> CreateTemplateTechniqueItem(TemplateTechniqueItem templateTechniqueItem);
        Task<TemplateTechniqueItem> CreateTemplateTechniqueItem();
        Task<List<TemplateTechniqueItem>> DetailTemplateTechniqueItems(int id);
        Task<TemplateTechniqueItem> DetailTemplateTechniqueItem(int id);
        void DeleteTemplateTechnique(int id);
        void DeleteTemplateTechniqueItem(int id);
        Task<TemplateTechnique> EditTemplateTechnique(int id);
        Task<TemplateTechnique> EditTemplateTechnique(TemplateTechnique templateTechnique);
        Task<TemplateTechniqueItem> EditTemplateTechniqueItem(int id);
        Task<TemplateTechniqueItem> EditTemplateTechniqueItem(TemplateTechniqueItem templateTechniqueItem);
        


    }
}

