using _4___E_CODING_DAL;
using E_CODING_Service_Abstraction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_CODING_Services
{
    public class TemplateProjectService : ITemplateProjectService
    {
        private ITemplateProjectRepository _iTemplateProjectRepository;

        public TemplateProjectService(ITemplateProjectRepository iTemplateProjectRepository) : base()
        {
            _iTemplateProjectRepository = iTemplateProjectRepository;
        }

        public async Task<List<TemplateProject>> GetAllTemplateProject()
        {
            try
            {
                var result = await _iTemplateProjectRepository.GetAllTemplateProject();
                return result;
            }
            catch(Exception ex)
            { return null; }
        }        

        public async Task<TemplateProject> DetailTemplateProject(int id)
        {
            try
            {
                return await _iTemplateProjectRepository.DetailTemplateProject(id);
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<List<TemplateTechnique>> DetailsTechnique(int id)
        {
            try
            {
                return await _iTemplateProjectRepository.DetailsTechnique(id);
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateFonctionnel> DetailsFonctionnel(int id)
        {
            
            try
            {
                return await _iTemplateProjectRepository.DetailsFonctionnel(id);
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<List<TemplateResult>> DetailsResult(int id)
        {
            try
            {
                return await _iTemplateProjectRepository.DetailsResult(id);
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateProject> EditTemplateProject(int id)
        {
            return await _iTemplateProjectRepository.EditTemplateProject(id);
        }

        public async Task<TemplateProject> EditTemplateProject(TemplateProject templateProject)
        {
            return await _iTemplateProjectRepository.EditTemplateProject(templateProject);
        }

        public async Task<TemplateProject> CreateTemplateProject()
        {
            return await _iTemplateProjectRepository.CreateTemplateProject();
        }

        public async Task<TemplateProject> CreateTemplateProject(TemplateProject templateProject)
        {
            return await _iTemplateProjectRepository.CreateTemplateProject(templateProject);
        }

        public void DeleteTemplateProject(int id)
        {
            _iTemplateProjectRepository.DeleteTemplateProject(id);
        }        

       
     

       
    }
}
