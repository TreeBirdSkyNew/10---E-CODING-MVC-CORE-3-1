using _4___E_CODING_DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction
{
    public interface ITemplateFonctionnelRepository
    {
        Task<List<TemplateFonctionnel>> GetAllTemplateFonctionnel();
        Task<TemplateFonctionnel> DetailTemplateFonctionnel(int id);

        Task<TemplateFonctionnelEntity> DetailTemplateFonctionnelEntity(int id);
        Task<List<TemplateFonctionnelEntity>> DetailTemplateFonctionnelEntities(int id);

        Task<TemplateFonctionnelProperty> DetailTemplateFonctionnelProperty(int id);
        Task<List<TemplateFonctionnelProperty>> DetailTemplateFonctionnelProperties(int id);

        Task<TemplateFonctionnel> TemplateFonctionnelByProject(int id);

        Task<TemplateFonctionnel> CreateTemplateFonctionnel();
        Task<TemplateFonctionnel> CreateTemplateFonctionnel(TemplateFonctionnel templateFonctionnel);

        Task<TemplateFonctionnelEntity> CreateTemplateFonctionnelEntity();
        Task<TemplateFonctionnelEntity> CreateTemplateFonctionnelEntity(TemplateFonctionnelEntity templateFonctionnelEntity);

        Task<TemplateFonctionnelProperty> CreateTemplateFonctionnelProperty();
        Task<TemplateFonctionnelProperty> CreateTemplateFonctionnelProperty(TemplateFonctionnelProperty templateFonctionnelProperty);

        Task<TemplateFonctionnel> EditTemplateFonctionnel(int id);
        Task<TemplateFonctionnelEntity> EditTemplateFonctionnelEntity(int id);
        Task<TemplateFonctionnelProperty> EditTemplateFonctionnelProperty(int id);

        Task<TemplateFonctionnel> EditTemplateFonctionnel(TemplateFonctionnel templateFonctionnel);
        Task<TemplateFonctionnelEntity> EditTemplateFonctionnelEntity(TemplateFonctionnelEntity templateFonctionnelEntity);
        Task<TemplateFonctionnelProperty> EditTemplateFonctionnelProperty(TemplateFonctionnelProperty templateFonctionnelProperty);

        /*  DELETE */
        void DeleteTemplateFonctionnel(int id);
        
    }
}
