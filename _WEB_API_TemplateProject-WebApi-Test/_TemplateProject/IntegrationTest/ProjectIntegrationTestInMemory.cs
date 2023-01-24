using __WEB_API__TemplateProject_WebApi;
using E_CODING_MVC_CORE_3_1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using _4___E_CODING_DAL;
using __WEB_API__TemplateProject_WebApi_Tests;

namespace __WEB_API__TemplateProject_WebApi_Test
{
    public class ProjectIntegrationTestInMemory : IClassFixture<ProjectTestFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProjectIntegrationTestInMemory(ProjectTestFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        [Fact]
        public async Task Index_TemplateProject_ReturnListTemplateProjectVM()
        {
            var response = await _client.GetAsync("/api/TemplateProject/index");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            List<TemplateProjectVM> results = JsonConvert.DeserializeObject<List<TemplateProjectVM>>(responseString);
            Assert.IsType<List<TemplateProjectVM>>(results);

        }

        [Fact]
        public async Task Create_TemplateProject_ReturnTemplateProjectVMEmpty()
        {
            var response = await _client.GetAsync("/api/TemplateProject/Create");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            TemplateProjectVM results = JsonConvert.DeserializeObject<TemplateProjectVM>(responseString);
            Assert.IsType<TemplateTechniqueVM>(results);
        }


        [Fact]
        public async Task CreateTemplateProject_ReturnTemplateProjectVM()
        {
            TemplateProject templateProject = CreateTemplateProjectTest();
            string objectContent = JsonConvert.SerializeObject(templateProject);
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/TemplateProject/Create", objectContent);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<TemplateProjectVM>(content);
            Assert.IsType<TemplateProjectVM>(results);
        }

        public TemplateProject CreateTemplateProjectTest()
        {
            List<TemplateTechniqueItem> templateTechniqueItems = new List<TemplateTechniqueItem>();
            TemplateTechniqueItem templateTechniqueItem = new TemplateTechniqueItem();
            templateTechniqueItem.TemplateTechniqueItemId = 3;
            templateTechniqueItem.TemplateTechniqueItemDescription = "TemplateTechniqueItemDescription3";
            templateTechniqueItem.TemplateTechniqueInitialFile = "TemplateTechniqueInitialFile3";
            templateTechniqueItem.TemplateTechniqueItemName = "TemplateTechniqueItemName3";
            templateTechniqueItem.TemplateTechniqueItemTitle = "TemplateTechniqueItemTitle3";
            templateTechniqueItem.TemplateTechniqueItemVersion = "TemplateTechniqueItemVersion3";
            templateTechniqueItem.TemplateTechniqueItemVersionNET = "TemplateTechniqueItemVersionNET3";
            templateTechniqueItems.Add(templateTechniqueItem);

            TemplateTechnique templateTechnique = new TemplateTechnique();
            templateTechnique.TemplateTechniqueId = 3;
            templateTechnique.TemplateProjectId = 3;
            templateTechnique.TemplateTechniqueDescription = "TemplateTechniqueDescription3";
            templateTechnique.TemplateTechniqueName = "TemplateTechniqueName3";
            templateTechnique.TemplateTechniqueTitle = "TemplateTechniqueTitle3";
            templateTechnique.TemplateTechniqueVersion = "TemplateTechniqueVersion3";
            templateTechnique.TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET3";
            templateTechnique.TemplateTechniqueItem = templateTechniqueItems;

            List<TemplateResultItem> templateResultItems = new List<TemplateResultItem>();
            TemplateResultItem templateResultItem = new TemplateResultItem();
            templateResultItem.TemplateResultItemId = 3;
            templateResultItem.TemplateResultId = 3;
            templateResultItem.TemplateFonctionnelId = 3;
            templateResultItem.TemplateResultFinalContent = "TemplateResultFinalContent3";
            templateResultItem.TemplateResultInitialContent = "TemplateResultInitialContent3";
            templateResultItem.TemplateResultItemDescription = "TemplateResultItemDescription3";
            templateResultItem.TemplateResultItemName = "TemplateResultItemName3";
            templateResultItem.TemplateResultItemTitle = "TemplateResultItemTitle3";
            templateResultItem.TemplateResultItemVersion = "TemplateResultItemVersion3";
            templateResultItem.TemplateResultItemVersionNET = "TemplateResultItemVersionNET3";
            templateResultItems.Add(templateResultItem);

            TemplateResult templateResult = new TemplateResult();
            templateResult.TemplateResultId = 3;
            templateResult.TemplateProjectId = 3;
            templateResult.TemplateResultDescription = "TemplateResultDescription3";
            templateResult.TemplateResultName = "TemplateResultName3";
            templateResult.TemplateResultTitle = "TemplateResultTitle3";
            templateResult.TemplateResultVersion = "TemplateResultVersion3";
            templateResult.TemplateResultVersionNET = "TemplateResultVersionNET3";
            templateResult.TemplateResultItem = templateResultItems;

            TemplateFonctionnel templateFonctionnel = new TemplateFonctionnel()
            {
                TemplateFonctionnelId = 3,
                TemplateFonctionnelTitle = "TemplateFonctionnelTitle3",
                TemplateFonctionnelName = "TemplateFonctionnelName3",
                TemplateFonctionnelContent = "TemplateFonctionnelContent3",
                TemplateFonctionnelDescription = "TemplateFonctionnelDescription3",
                TemplateFonctionnelEFVersion = "TemplateFonctionnelEFVersion3",
                TemplateProjectId = 3,
                TemplateFonctionnelEntity = new List<TemplateFonctionnelEntity>()
                {
                    new TemplateFonctionnelEntity()
                    {
                        TemplateFonctionnelEntityId = 3,
                        TemplateFonctionnelId=3,
                        TemplateFonctionnelEntityContent = "TemplateFonctionnelEntityContent3",
                        TemplateFonctionnelEntityDescription = "TemplateFonctionnelEntityDescription3",
                        TemplateFonctionnelEntityName = "TemplateFonctionnelEntityName3",
                        TemplateFonctionnelEntityTitle = "TemplateFonctionnelEntityTitle3",
                        TemplateFonctionnelEntityTypeNet = "TemplateFonctionnelEntityTypeNet3",
                        TemplateFonctionnelEntityTypeSQL = "TemplateFonctionnelEntityTypeSQL3",
                        TemplateFonctionnelEntityVersionEF = "TemplateFonctionnelEntityVersionEF3",
                        TemplateFonctionnelEntityVersionNET = "TemplateFonctionnelEntityVersionNET3",
                        TemplateFonctionnelProperty = new List<TemplateFonctionnelProperty>()
                        {
                            new TemplateFonctionnelProperty()
                            {
                                TemplateFonctionnelPropertyId = 3,
                                TemplateFonctionnelEntityId=3,
                                TemplateFonctionnelId=3,
                                TemplateFonctionnelPropertyDescription="TemplateFonctionnelPropertyDescription3",
                                TemplateFonctionnelPropertyName="TemplateFonctionnelPropertyName3",
                                TemplateFonctionnelPropertyTitle="TemplateFonctionnelPropertyTitle3",
                                TemplateFonctionnelPropertyVersionEF="TemplateFonctionnelPropertyVersionEF3",
                                TemplateFonctionnelPropertyVersionNET="TemplateFonctionnelPropertyVersionNET3"
                            }
                        }
                    }
                }

            };

            TemplateProject templateProject = new TemplateProject();
            templateProject.TemplateProjectId = 3;
            templateProject.TemplateProjectDescription = "TemplateProjectDescription3";
            templateProject.TemplateProjectName = "TemplateProjectName3";
            templateProject.TemplateProjectTitle = "TemplateProjectTitle3";
            templateProject.TemplateProjectVersion = "TemplateProjectVersion3";
            templateProject.TemplateProjectVersionNet = "TemplateProjectVersionNet3";
            templateProject.TemplateFonctionnel = templateFonctionnel;
            templateProject.ProjectTechnique = new List<ProjectTechnique>()
            {
               new ProjectTechnique()
               {
                   TemplateProjectId=3 ,
                   TemplateTechniqueId=3,
                   TemplateTechnique=templateTechnique,
                   TemplateProject=templateProject
               }
             };
            templateProject.ProjectResult = new List<ProjectResult>()
            {
               new ProjectResult()
               {
                   TemplateProjectId=3 ,
                   TemplateResultId=3,
                   TemplateResult=templateResult,
                   TemplateProject=templateProject
               }
             };

            return templateProject;
        }

    }
}
