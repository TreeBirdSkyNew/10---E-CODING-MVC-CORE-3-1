using _4___E_CODING_DAL;
using E_CODING_MVC_CORE_3_1.Models;
using E_CODING_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __WEB_API__TemplateProject_WebApi_Test
{
    public class TemplateProjectServiceFake : ITemplateProjectService
    {

        List<TemplateProject> projects;
        
        public TemplateProjectServiceFake() 
        {
            DataFakeTemplateProject();
        }

        public async Task<List<TemplateProject>> GetAllTemplateProject()
        {   
            await Task.Delay(1);
            return projects;
        }

        public async Task<TemplateProject> DetailTemplateProject(int id)
        {
            foreach(TemplateProject project in projects)
            {
                if (project.TemplateProjectId == id)
                {
                    await Task.Delay(1);
                    return project;
                }
            }
            return null;
        }

        public async Task<TemplateProject> CreateTemplateProject()
        {
            TemplateProject technique = new TemplateProject();
            await Task.Delay(1);
            return technique;
        }

        public async Task<TemplateProject> CreateTemplateProject(TemplateProject templateProject)
        {
            projects.Add(templateProject);
            await Task.Delay(1);
            return templateProject;
        }        
        
        public async Task<TemplateProject> EditTemplateProject(int id)
        {
            foreach (TemplateProject templateProject in projects)
            {
                if (templateProject.TemplateProjectId == id)
                {
                    await Task.Delay(1);
                    return templateProject;
                }
            }
            return null;
        }

        public async Task<TemplateProject> EditTemplateProject(TemplateProject templateProject)
        {
            foreach (TemplateProject _templateProject in projects)
            {
                if (templateProject.TemplateProjectId == templateProject.TemplateProjectId)
                {
                    _templateProject.TemplateProjectName = templateProject.TemplateProjectName;
                    _templateProject.TemplateProjectTitle = templateProject.TemplateProjectTitle;
                    _templateProject.TemplateProjectDescription = templateProject.TemplateProjectDescription;
                    _templateProject.TemplateProjectVersion = templateProject.TemplateProjectVersion;
                    _templateProject.TemplateProjectVersionNet = templateProject.TemplateProjectVersionNet;
                    await Task.Delay(1);
                    return _templateProject;
                }
            }
            return null;
        }

       
        public void DeleteTemplateFonctionnel(int id)
        {
            throw new NotImplementedException();
        }

       
        public List<TemplateProject> DataTestTemplateProject()
        {
            return projects;
        }

        

        public void DataFakeTemplateProject()
        {
            projects = new List<TemplateProject>();

            projects.Add(new TemplateProject()           {
                TemplateProjectId=1,
                TemplateProjectDescription= "TemplateProjectDescription1",
                TemplateProjectName = "TemplateProjectName1",
                TemplateProjectTitle = "TemplateProjectTitle1",
                TemplateProjectVersion = "TemplateProjectVersion1",
                TemplateProjectVersionNet = "TemplateProjectVersionNet1"
            });

            projects.Add(new TemplateProject()
            {
                TemplateProjectId = 2,
                TemplateProjectDescription = "TemplateProjectDescription2",
                TemplateProjectName = "TemplateProjectName2",
                TemplateProjectTitle = "TemplateProjectTitle2",
                TemplateProjectVersion = "TemplateProjectVersion2",
                TemplateProjectVersionNet = "TemplateProjectVersionNet2"
            });
        }

        

        public Task<TemplateFonctionnel> DetailsByProject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TemplateTechnique>> DetailsTechnique(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TemplateFonctionnelEntity>> DetailsEntity(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTemplateProject(int id)
        {
            throw new NotImplementedException();
        }
    }
}
