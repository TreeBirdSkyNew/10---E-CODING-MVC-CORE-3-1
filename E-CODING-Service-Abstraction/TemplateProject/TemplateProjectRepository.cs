using _4___E_CODING_DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction
{
    public class TemplateProjectRepository : ITemplateProjectRepository
    {

        private readonly TemplateProjectDbContext _templateProjectDbContext;
        public TemplateProjectRepository() : base()
        {
            _templateProjectDbContext = new TemplateProjectDbContext();
        }

        public async Task<List<TemplateProject>> GetAllTemplateProject()
        {
            try 
            { 
                var templateProjects = await _templateProjectDbContext.TemplateProject.ToListAsync();
                return templateProjects;
            }
            catch(Exception ex)
            { return null; }
        }        
        
        public async Task<TemplateProject> DetailTemplateProject(int id)
        {            
            try
            {
                var templateProject = await _templateProjectDbContext.TemplateProject.Where(m => m.TemplateProjectId == id).SingleAsync();
                return templateProject;
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<List<TemplateTechnique>> DetailsTechnique(int id)
        {
            try
            {
                var templateProjects = await _templateProjectDbContext.TemplateTechnique.Where(m => m.TemplateProjectId == id).ToListAsync();
                return templateProjects;
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateFonctionnel> DetailsFonctionnel(int id)
        {
            try
            {
                var entities = await _templateProjectDbContext.TemplateFonctionnelEntity.Where(m => m.TemplateFonctionnelId == id).ToListAsync();
                var fonctionnel = await _templateProjectDbContext.TemplateFonctionnel.Where(m => m.TemplateFonctionnelId == id).SingleAsync();
                fonctionnel.TemplateFonctionnelEntity = entities;
                return fonctionnel;
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<List<TemplateResult>> DetailsResult(int id)
        {
            try
            {
                var results = await _templateProjectDbContext.TemplateResult.Where(m => m.TemplateProjectId == id).ToListAsync();
                foreach(TemplateResult result in results)
                {
                    var items = await _templateProjectDbContext.TemplateResultItem.Where(m => m.TemplateResultId == result.TemplateResultId).ToListAsync();
                    result.TemplateResultItem = items;
                }
                return results;
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateProject> CreateTemplateProject()
        {
            await Task.Delay(1);
            TemplateProject templateProject = new TemplateProject();
            return templateProject;
        }

        public async Task<TemplateProject> CreateTemplateProject(TemplateProject templateProject)
        {
            try
            {
                await _templateProjectDbContext.TemplateFonctionnel.AddAsync(templateProject.TemplateFonctionnel);
                var projectTechniques = templateProject.ProjectTechnique.ToList();
                foreach(ProjectTechnique projectTechnique in projectTechniques)
                {
                    await _templateProjectDbContext.TemplateTechniqueItem.AddRangeAsync(projectTechnique.TemplateTechnique.TemplateTechniqueItem);
                    await _templateProjectDbContext.TemplateTechnique.AddRangeAsync(projectTechnique.TemplateTechnique);
                }
                var projectResults = templateProject.ProjectResult.ToList();
                foreach (ProjectResult projectResult in projectResults)
                {
                    await _templateProjectDbContext.TemplateResultItem.AddRangeAsync(projectResult.TemplateResult.TemplateResultItem);
                    await _templateProjectDbContext.TemplateResult.AddRangeAsync(projectResult.TemplateResult);
                }
                await _templateProjectDbContext.TemplateProject.AddAsync(templateProject);
                await _templateProjectDbContext.SaveChangesAsync();
                return templateProject;
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateProject> EditTemplateProject(int id)
        {
            try
            {
                return await _templateProjectDbContext.TemplateProject.Where(m => m.TemplateProjectId == id).SingleAsync();
            }
            catch (Exception ex)
            { return null; }
        }

        public async Task<TemplateProject> EditTemplateProject(TemplateProject templateProjet)
        {
            try
            {
                _templateProjectDbContext.Update(templateProjet);
                await _templateProjectDbContext.SaveChangesAsync();
                return templateProjet;
            }
            catch (Exception ex)
            { return null; }
        }

        public void DeleteTemplateProject(int id)
        {
            TemplateProject templateProjet = DetailTemplateProject(id).Result;
            _templateProjectDbContext.TemplateProject.Remove(templateProjet);
            _templateProjectDbContext.SaveChanges();
        }
    }
}
