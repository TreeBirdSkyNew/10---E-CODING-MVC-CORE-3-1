using _4___E_CODING_DAL.Models;
using E_CODING_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __WEB_API__TemplateTechnique_WebApi_Test._TemplateTechnique.UnitTest.FakeTest
{
    public class TemplateTechniqueServiceFake : ITemplateTechniqueService
    {

        List<TemplateProject> projects = new List<TemplateProject>();
        List<TemplateTechnique> templateTechnics = new List<TemplateTechnique>();
        List<TemplateTechniqueItem> templateTechnicItems = new List<TemplateTechniqueItem>();          

        public TemplateTechniqueServiceFake() 
        {
            DataFakeTemplateProject();
            DataFakeTemplateTechnic();
        }

        public async Task<List<TemplateTechnique>> GetAllTemplateTechnique()
        {   
            await Task.Delay(1);
            return templateTechnics;
        }

        public Task<List<TemplateTechnique>> TemplateTechniqueByProject(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TemplateTechnique> DetailTemplateTechnique(int id)
        {
            foreach(TemplateTechnique templateTechnic in templateTechnics)
            {
                if (templateTechnic.TemplateTechniqueId == id)
                {
                    await Task.Delay(1);
                    return templateTechnic;
                }
            }
            return null;
        }

        public async Task<TemplateTechniqueItem> DetailTemplateTechniqueItem(int id)
        {
            foreach (TemplateTechniqueItem templateTechnicItem in templateTechnicItems)
            {
                if (templateTechnicItem.TemplateTechniqueItemId == id)
                {
                    await Task.Delay(1);
                    return templateTechnicItem;
                }
            }
            return null;
        }

        public async Task<List<TemplateTechniqueItem>> DetailTemplateTechniqueItems(int id)
        {
            List<TemplateTechniqueItem> _templateTechnicItems = new List<TemplateTechniqueItem>();
            foreach (TemplateTechniqueItem templateTechnicItem in templateTechnicItems)
            {
                if (templateTechnicItem.TemplateTechniqueId == id)
                {
                    await Task.Delay(1);
                    _templateTechnicItems.Add(templateTechnicItem);
                }
            }
            return _templateTechnicItems;
        }        

        public async Task<TemplateTechnique> CreateTemplateTechnique()
        {
            TemplateTechnique technique = new TemplateTechnique();
            await Task.Delay(1);
            return technique;
        }

        public async Task<TemplateTechnique> CreateTemplateTechnique(TemplateTechnique templateTechnique)
        {
            templateTechnics.Add(templateTechnique);
            await Task.Delay(1);
            return templateTechnique;
        }

        public async Task<TemplateTechniqueItem> CreateTemplateTechniqueItem()
        {
            TemplateTechniqueItem technique = new TemplateTechniqueItem();
            await Task.Delay(1);
            return technique;
        }

        public async Task<TemplateTechniqueItem> CreateTemplateTechniqueItem(TemplateTechniqueItem templateTechniqueItem)
        {
            templateTechnicItems.Add(templateTechniqueItem);
            await Task.Delay(1);
            return templateTechniqueItem;
        }

        public Task<TemplateTechnique> EditTemplateTechnique(int id)
        {
            TemplateTechnique templateTechnique = templateTechnics.Where(o => o.TemplateTechniqueId == id).First();
            return EditTemplateTechnique(templateTechnique);
        }



        public async Task<TemplateTechnique> EditTemplateTechnique(TemplateTechnique templateTechnique)
        {
            TemplateTechnique technique = templateTechnics.Where(o => o.TemplateTechniqueId == templateTechnique.TemplateTechniqueId).First();
            technique.TemplateTechniqueDescription = templateTechnique.TemplateTechniqueDescription;
            technique.TemplateProjectId = templateTechnique.TemplateProjectId;
            technique.TemplateTechniqueItem = templateTechnique.TemplateTechniqueItem;
            technique.TemplateTechniqueName = templateTechnique.TemplateTechniqueName;
            technique.TemplateTechniqueTitle = templateTechnique.TemplateTechniqueTitle;
            technique.TemplateTechniqueVersion = templateTechnique.TemplateTechniqueVersion;
            technique.TemplateTechniqueVersionNET = templateTechnique.TemplateTechniqueVersionNET;
            await Task.Delay(1);
            return technique;
        }

        public Task<TemplateTechniqueItem> EditTemplateTechniqueItem(int id)
        {
            TemplateTechniqueItem templateTechniqueItem = templateTechnicItems.Where(o => o.TemplateTechniqueItemId == id).First();
            return EditTemplateTechniqueItem(templateTechniqueItem);
        }

        public async Task<TemplateTechniqueItem> EditTemplateTechniqueItem(TemplateTechniqueItem templateTechniqueItem)
        {
            TemplateTechniqueItem technicItem = templateTechnicItems.Where(o => o.TemplateTechniqueItemId == templateTechniqueItem.TemplateTechniqueItemId).First();
            technicItem.TemplateTechniqueFinalContent = templateTechniqueItem.TemplateTechniqueFinalContent;
            technicItem.TemplateParameter = templateTechniqueItem.TemplateParameter;
            technicItem.TemplateTechnique = templateTechniqueItem.TemplateTechnique;
            technicItem.TemplateTechniqueId = templateTechniqueItem.TemplateTechniqueId;
            technicItem.TemplateTechniqueInitialFile = templateTechniqueItem.TemplateTechniqueInitialFile;
            technicItem.TemplateTechniqueItemDescription = templateTechniqueItem.TemplateTechniqueItemDescription;
            technicItem.TemplateTechniqueItemName = templateTechniqueItem.TemplateTechniqueItemName;
            technicItem.TemplateTechniqueItemTitle = templateTechniqueItem.TemplateTechniqueItemTitle;
            technicItem.TemplateTechniqueItemVersion = templateTechniqueItem.TemplateTechniqueItemVersion;
            technicItem.TemplateTechniqueItemVersionNET = templateTechniqueItem.TemplateTechniqueItemVersionNET;
            await Task.Delay(1);
            return technicItem;
        }       
              
        public List<TemplateTechnique> DataTestTemplateTechnic()
        {
            return templateTechnics;
        }

        public List<TemplateTechniqueItem> DataTestTemplateTechnicItem()
        {
            return templateTechnicItems;
        }        

        public void DataFakeTemplateProject()
        {
            projects.Add(new TemplateProject()           {
                TemplateProjectId=1,
                TemplateProjectDescription= "TemplateProjectDescription1",
                TemplateProjectName = "TemplateProjectName1",
                TemplateProjectTitle = "TemplateProjectTitle",
                TemplateProjectVersion = "TemplateProjectVersion1",
                TemplateProjectVersionNet = "TemplateProjectVersionNet1"
            });            
        }

        public void DataFakeTemplateTechnic()
        {
            templateTechnicItems.Add(new TemplateTechniqueItem
            {
                TemplateTechniqueItemId=1,
                TemplateTechniqueId = 1,
                TemplateTechniqueFinalContent = "TemplateTechniqueFinalContent1",
                TemplateTechniqueInitialFile = "TemplateTechniqueInitialFile1",
                TemplateTechniqueItemDescription = "TemplateTechniqueItemDescription1",
                TemplateTechniqueItemName = "TemplateTechniqueItemName1",
                TemplateTechniqueItemTitle = "TemplateTechniqueItemTitle1",
                TemplateTechniqueItemVersion= "TemplateTechniqueItemVersion1",
                TemplateTechniqueItemVersionNET = "TemplateTechniqueItemVersionNET1",
            });

            templateTechnics.Add(new TemplateTechnique
            {
                TemplateProjectId = 1,
                TemplateTechniqueId = 1,
                TemplateTechniqueDescription = "TemplateTechniqueDescription1",
                TemplateTechniqueName = "TemplateTechniqueName1",
                TemplateTechniqueTitle = "TemplateTechniqueTitle1",
                TemplateTechniqueVersion = "TemplateTechniqueVersion1",
                TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET1",
                TemplateTechniqueItem = templateTechnicItems.Where(o => o.TemplateTechniqueItemId == 1).ToList()
            }); ;

            templateTechnicItems.Add(new TemplateTechniqueItem
            {
                TemplateTechniqueItemId = 2,
                TemplateTechniqueId = 2,
                TemplateTechniqueFinalContent = "TemplateTechniqueFinalContent2",
                TemplateTechniqueInitialFile = "TemplateTechniqueInitialFile2",
                TemplateTechniqueItemDescription = "TemplateTechniqueItemDescription2",
                TemplateTechniqueItemName = "TemplateTechniqueItemName2",
                TemplateTechniqueItemTitle = "TemplateTechniqueItemTitle2",
                TemplateTechniqueItemVersion = "TemplateTechniqueItemVersion2",
                TemplateTechniqueItemVersionNET = "TemplateTechniqueItemVersionNET2",
            });

            templateTechnics.Add(new TemplateTechnique
            {
                TemplateProjectId = 1,
                TemplateTechniqueId = 2,
                TemplateTechniqueDescription = "TemplateTechniqueDescription2",
                TemplateTechniqueName = "TemplateTechniqueName2",
                TemplateTechniqueTitle = "TemplateTechniqueTitle2",
                TemplateTechniqueVersion = "TemplateTechniqueVersion2",
                TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET2",
                TemplateTechniqueItem = templateTechnicItems.Where(o => o.TemplateTechniqueItemId == 2).ToList()
            });
        }

        public void DeleteTemplateTechnique(int id)
        {
            TemplateTechnique templateTechnique = templateTechnics.Where(o => o.TemplateTechniqueId == id).First();
            templateTechnics.Remove(templateTechnique);
        }

        public void DeleteTemplateTechniqueItem(int id)
        {
            TemplateTechniqueItem templateTechnique = templateTechnicItems.Where(o => o.TemplateTechniqueItemId == id).First();
            templateTechnicItems.Remove(templateTechnique);
        }

        
    }
}
