using _4___E_CODING_DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction
{
    public interface ITemplateProjectRepository
    {
        Task<List<TemplateProject>> GetAllTemplateProject();
        Task<TemplateProject> DetailTemplateProject(int id);
        Task<TemplateFonctionnel> DetailsFonctionnel(int id);
        Task<List<TemplateTechnique>> DetailsTechnique(int id);
        Task<List<TemplateResult>> DetailsResult(int id);
        Task<TemplateProject> CreateTemplateProject();
        Task<TemplateProject> CreateTemplateProject(TemplateProject templateProject);
        Task<TemplateProject> EditTemplateProject(TemplateProject templateProject);
        Task<TemplateProject> EditTemplateProject(int id);
        void DeleteTemplateProject(int id);

    }
}
