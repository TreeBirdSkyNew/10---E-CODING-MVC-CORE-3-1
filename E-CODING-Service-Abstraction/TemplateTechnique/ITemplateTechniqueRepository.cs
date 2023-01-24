using _4___E_CODING_DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction
{
    public interface ITemplateTechniqueRepository 
    {
        Task<List<TemplateTechnique>> GetAllTemplateTechnique();
        Task<List<TemplateTechnique>> TemplateTechniqueByProject(int id);
        Task<TemplateTechnique> DetailTemplateTechnique(int id);        
        Task<List<TemplateTechniqueItem>> DetailTemplateTechniqueItems(int id);
        Task<TemplateTechniqueItem> DetailTemplateTechniqueItem(int id);


        Task<TemplateTechnique> CreateTemplateTechnique(TemplateTechnique templateTechnique);
        Task<TemplateTechnique> CreateTemplateTechnique();
        Task<TemplateTechniqueItem> CreateTemplateTechniqueItem(TemplateTechniqueItem templateTechniqueItem);
        Task<TemplateTechniqueItem> CreateTemplateTechniqueItem();

        Task<TemplateTechnique> EditTemplateTechnique(int id);
        Task<TemplateTechnique> EditTemplateTechnique(TemplateTechnique templateTechnique);
        Task<TemplateTechniqueItem> EditTemplateTechniqueItem(int id);
        Task<TemplateTechniqueItem> EditTemplateTechniqueItem(TemplateTechniqueItem templateTechniqueItem);

        void DeleteTemplateTechnique(int id);
        void DeleteTemplateTechniqueItem(int id);
    }
}


