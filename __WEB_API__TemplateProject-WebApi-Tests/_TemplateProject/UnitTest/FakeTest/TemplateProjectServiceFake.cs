using _4___E_CODING_DAL;
using E_CODING_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __WEB_API__TemplateProject_WebApi_Tests
{
    public class TemplateProjectServiceFake : ITemplateProjectService
    {

        List<TemplateProject> projects = new List<TemplateProject>();
        List<TemplateTechnique> _templateTechniques = new List<TemplateTechnique>();
        List<TemplateFonctionnel> _templateFonctionnels = new List<TemplateFonctionnel>();
        List<TemplateResult> _templateResults = new List<TemplateResult>();

        public TemplateProjectServiceFake() 
        {
            DataFakeTemplateProject();
            DataFakeTemplateTechnique();
            DataFakeTemplateFonctionnel();
            DataFakeTemplateResult();
        }

        public async Task<List<TemplateProject>> GetAllTemplateProject()
        {
            List<TemplateProject> templateProjects = new List<TemplateProject>();
            foreach (TemplateProject templateProject in projects)
            {
                templateProject.TemplateFonctionnel = await DetailsFonctionnel(templateProject.TemplateProjectId);

                var techniques = await DetailsTechnique(templateProject.TemplateProjectId);
                templateProject.ProjectTechnique = new List<ProjectTechnique>();
                foreach (TemplateTechnique templateTechnique in techniques)
                {
                    ProjectTechnique oProjectTechnique = new ProjectTechnique();
                    oProjectTechnique.TemplateTechniqueId = templateTechnique.TemplateTechniqueId;
                    oProjectTechnique.TemplateTechnique = templateTechnique;
                    oProjectTechnique.TemplateProject = templateProject;
                    oProjectTechnique.TemplateProjectId = templateProject.TemplateProjectId;
                    templateProject.ProjectTechnique.Add(oProjectTechnique);
                }

                var results = await DetailsResult(templateProject.TemplateProjectId);
                templateProject.ProjectResult = new List<ProjectResult>();
                foreach (TemplateResult templateResult in results)
                {
                    ProjectResult oProjectResult = new ProjectResult();
                    oProjectResult.TemplateResultId = templateResult.TemplateResultId;
                    oProjectResult.TemplateResult = templateResult;
                    oProjectResult.TemplateProject = templateProject;
                    oProjectResult.TemplateProjectId = templateProject.TemplateProjectId;
                    templateProject.ProjectResult.Add(oProjectResult);
                }
                templateProjects.Add(templateProject);
            }
            return templateProjects;
        }

        public async Task<TemplateProject> DetailTemplateProject(int id)
        {
            TemplateProject templateProject = projects.Where(o => o.TemplateProjectId == id).Single();
            templateProject.TemplateFonctionnel = _templateFonctionnels.Where(o => o.TemplateProjectId == id).Single();
            var techniques = _templateTechniques.Where(o => o.TemplateProjectId == id).ToList();
            foreach (TemplateTechnique technique in techniques)
            {
                templateProject.ProjectTechnique = new List<ProjectTechnique>()
                {
                    new ProjectTechnique() {
                    TemplateProject= templateProject,
                    TemplateProjectId= templateProject.TemplateProjectId,
                    TemplateTechnique= technique,
                    TemplateTechniqueId= technique.TemplateTechniqueId}
                };
            }
            var results = _templateResults.Where(o => o.TemplateProjectId == id).ToList();
            foreach (TemplateResult result in results)
            {
                templateProject.ProjectResult = new List<ProjectResult>()
                {
                    new ProjectResult() {
                    TemplateProject= templateProject,
                    TemplateProjectId= templateProject.TemplateProjectId,
                    TemplateResult= result,
                    TemplateResultId= result.TemplateResultId}
                };
            }
            await Task.Delay(1);
            return templateProject;
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

            _templateFonctionnels.Add(templateProject.TemplateFonctionnel);

            var techniques = templateProject.ProjectTechnique;
            foreach(ProjectTechnique projectTechnique in techniques)
            { 
                _templateTechniques.Add(projectTechnique.TemplateTechnique);
            }

            var results = templateProject.ProjectResult;
            foreach (ProjectResult projectResult in results)
            {
                _templateResults.Add(projectResult.TemplateResult);
            }
            await Task.Delay(1);
            return templateProject;
        }        
        
        public async Task<TemplateProject> EditTemplateProject(int id)
        {
            TemplateProject templateProject = projects.Where(o => o.TemplateProjectId == id).Single();
            await Task.Delay(1);
            return templateProject;
        }

        public async Task<TemplateProject> EditTemplateProject(TemplateProject templateProject)
        {
            TemplateProject _templateProject = projects.Where(o => o.TemplateProjectId == templateProject.TemplateProjectId).Single();
            _templateProject.TemplateProjectId = templateProject.TemplateProjectId;
            _templateProject.TemplateProjectDescription = templateProject.TemplateProjectDescription;
            _templateProject.TemplateProjectName = templateProject.TemplateProjectName;
            _templateProject.TemplateProjectTitle = templateProject.TemplateProjectTitle;
            _templateProject.TemplateProjectVersion = templateProject.TemplateProjectVersion;
            _templateProject.TemplateProjectVersionNet = templateProject.TemplateProjectVersionNet;
            _templateProject.TemplateFonctionnel = templateProject.TemplateFonctionnel;
            _templateProject.ProjectTechnique = templateProject.ProjectTechnique;
            _templateProject.ProjectResult = templateProject.ProjectResult;
            await Task.Delay(1);
            return templateProject;
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
        }

        public void DataFakeTemplateTechnique()
        {
            TemplateTechniqueItem templateTechniqueItem = new TemplateTechniqueItem();
            templateTechniqueItem.TemplateTechniqueItemId = 1;
            templateTechniqueItem.TemplateTechniqueFinalContent = "TemplateTechniqueFinalContent1";
            templateTechniqueItem.TemplateTechniqueInitialFile = "TemplateTechniqueInitialFile1";
            templateTechniqueItem.TemplateTechniqueItemDescription = "TemplateTechniqueItemDescription1";
            templateTechniqueItem.TemplateTechniqueItemName = "TemplateTechniqueItemName1";
            templateTechniqueItem.TemplateTechniqueItemTitle = "TemplateTechniqueItemTitle1";
            templateTechniqueItem.TemplateTechniqueItemVersion = "TemplateTechniqueItemVersion1";
            templateTechniqueItem.TemplateTechniqueItemVersionNET = "TemplateTechniqueItemVersionNET1";

            List<TemplateTechniqueItem> templateTechniqueItems = new List<TemplateTechniqueItem>();
            templateTechniqueItems.Add(templateTechniqueItem);

            TemplateTechnique templateTechnique = new TemplateTechnique();
            templateTechnique.TemplateTechniqueId = 1;
            templateTechnique.TemplateProjectId = 1;
            templateTechnique.TemplateTechniqueDescription = "TemplateTechniqueDescription1";
            templateTechnique.TemplateTechniqueName = "TemplateTechniqueName1";
            templateTechnique.TemplateTechniqueTitle = "TemplateTechniqueTitle1";
            templateTechnique.TemplateTechniqueVersion = "TemplateTechniqueVersion1";
            templateTechnique.TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET1";
            templateTechnique.TemplateTechniqueItem = templateTechniqueItems;

            List<TemplateTechnique> templateTechniques = new List<TemplateTechnique>();
            templateTechniques.Add(templateTechnique);

            var projectId1 = projects.Where(o => o.TemplateProjectId == 1).Single();
            projectId1.ProjectTechnique = new List<ProjectTechnique>()
            {
                new ProjectTechnique() 
                {
                    TemplateProject = projectId1,
                    TemplateProjectId = 1,
                    TemplateTechnique = templateTechnique,
                    TemplateTechniqueId = 1 
                }
            };
            _templateTechniques = templateTechniques;
        }

        public void DataFakeTemplateFonctionnel()
        {
            
            TemplateFonctionnelProperty templateFonctionnelProperty = new TemplateFonctionnelProperty();
            templateFonctionnelProperty.TemplateFonctionnelPropertyId = 1;
            templateFonctionnelProperty.TemplateFonctionnelEntityId = 1;
            templateFonctionnelProperty.TemplateFonctionnelId = 1;
            templateFonctionnelProperty.TemplateFonctionnelPropertyDescription = "TemplateFonctionnelPropertyDescription1";
            templateFonctionnelProperty.TemplateFonctionnelPropertyName = "TemplateFonctionnelPropertyName1";
            templateFonctionnelProperty.TemplateFonctionnelPropertyTitle = "TemplateFonctionnelPropertyTitle1";
            templateFonctionnelProperty.TemplateFonctionnelPropertyVersionEF = "TemplateFonctionnelPropertyVersionEF1";
            templateFonctionnelProperty.TemplateFonctionnelPropertyVersionNET = "TemplateFonctionnelPropertyVersionNET1";
            
            List<TemplateFonctionnelProperty> templateFonctionnelProperties = new List<TemplateFonctionnelProperty>();
            templateFonctionnelProperties.Add(templateFonctionnelProperty);

            TemplateFonctionnelEntity templateFonctionnelEntity = new TemplateFonctionnelEntity();
            templateFonctionnelEntity.TemplateFonctionnelEntityId = 1;
            templateFonctionnelEntity.TemplateFonctionnelEntityContent = "TemplateFonctionnelEntityContent1";
            templateFonctionnelEntity.TemplateFonctionnelEntityDescription = "TemplateFonctionnelEntityDescription1";
            templateFonctionnelEntity.TemplateFonctionnelEntityName = "TemplateFonctionnelEntityName1";
            templateFonctionnelEntity.TemplateFonctionnelEntityTitle = "TemplateFonctionnelEntityTitle1";
            templateFonctionnelEntity.TemplateFonctionnelEntityTypeNet = "TemplateFonctionnelEntityTypeNet1";
            templateFonctionnelEntity.TemplateFonctionnelEntityTypeSQL = "TemplateFonctionnelEntityTypeSQL1";
            templateFonctionnelEntity.TemplateFonctionnelEntityVersionEF = "TemplateFonctionnelEntityVersionEF1";
            templateFonctionnelEntity.TemplateFonctionnelEntityVersionNET = "TemplateFonctionnelEntityVersionNET1";
            templateFonctionnelEntity.TemplateFonctionnelProperty = templateFonctionnelProperties;

            List<TemplateFonctionnelEntity> templateFonctionnelEntities = new List<TemplateFonctionnelEntity>();
            templateFonctionnelEntities.Add(templateFonctionnelEntity);

            TemplateFonctionnel templateFonctionnel = new TemplateFonctionnel();
            templateFonctionnel.TemplateFonctionnelId = 1;
            templateFonctionnel.TemplateProjectId = 1;
            templateFonctionnel.TemplateFonctionnelContent = "TemplateFonctionnelContent1";
            templateFonctionnel.TemplateFonctionnelDescription = "TemplateFonctionnelDescription1";
            templateFonctionnel.TemplateFonctionnelEFVersion = "TemplateFonctionnelEFVersion1";
            templateFonctionnel.TemplateFonctionnelTitle = "TemplateFonctionnelTitle1";
            templateFonctionnel.TemplateFonctionnelName = "TemplateFonctionnelName1";
            templateFonctionnel.TemplateFonctionnelEntity = templateFonctionnelEntities;

            var projectId1 = projects.Where(o => o.TemplateProjectId == 1).Single();
            projectId1.TemplateFonctionnel = templateFonctionnel;

            _templateFonctionnels.Add(templateFonctionnel);
        }

        public void DataFakeTemplateResult()
        {
            TemplateResultItem templateResultItem = new TemplateResultItem();
            templateResultItem.TemplateResultId = 1;
            templateResultItem.TemplateFonctionnelId = 1;
            templateResultItem.TemplateTechniqueId = 1;
            templateResultItem.TemplateResultFinalContent = "TemplateResultFinalContent1";
            templateResultItem.TemplateResultInitialContent = "TemplateResultInitialContent1";
            templateResultItem.TemplateResultItemDescription = "TemplateResultItemDescription1";
            templateResultItem.TemplateResultItemId = 1;
            templateResultItem.TemplateResultItemName = "TemplateResultItemName1";
            templateResultItem.TemplateResultItemTitle = "TemplateResultItemTitle1";
            templateResultItem.TemplateResultItemVersion = "TemplateResultItemVersion1";
            templateResultItem.TemplateResultItemVersionNET = "TemplateResultItemVersionNET1";

            List<TemplateResultItem> templateResultItems = new List<TemplateResultItem>();
            templateResultItems.Add(templateResultItem);

            TemplateResult templateResult = new TemplateResult();
            templateResult.TemplateResultId = 1;
            templateResult.TemplateResultDescription = "TemplateResultDescription1";
            templateResult.TemplateResultName = "TemplateResultName1";
            templateResult.TemplateResultTitle = "TemplateResultTitle1";
            templateResult.TemplateResultVersion = "TemplateResultVersion1";
            templateResult.TemplateResultVersionNET = "TemplateResultVersionNET1";
            templateResult.TemplateResultItem = templateResultItems;

            _templateResults.Add(templateResult);
        }

        public async Task<List<TemplateTechnique>> DetailsTechnique(int id)
        {
            await Task.Delay(1);
            var templateTechniques = _templateTechniques.Where(o => o.TemplateProjectId == id).ToList();
            return templateTechniques;
        }

        public async Task<TemplateFonctionnel> DetailsFonctionnel(int id)
        {
            await Task.Delay(1);
            var templateFonctionnel = _templateFonctionnels.Where(o => o.TemplateProjectId == id).Single();
            return templateFonctionnel;
        }

        public async Task<List<TemplateResult>> DetailsResult(int id)
        {
            await Task.Delay(1);
            var templateResults = _templateResults.Where(o => o.TemplateProjectId == id).ToList();
            return templateResults;
        }

        public void DeleteTemplateProject(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTemplateFonctionnel(int id)
        {
            throw new NotImplementedException();
        }

    }
}
