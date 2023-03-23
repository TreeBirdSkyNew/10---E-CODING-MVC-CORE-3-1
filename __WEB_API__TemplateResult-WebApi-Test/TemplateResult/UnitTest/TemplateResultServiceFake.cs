using _4___E_CODING_DAL.Models;
using E_CODING_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __WEB_API__TemplateTechnique_WebApi_Test._TemplateTechnique.UnitTest
{
    public class TemplateResultServiceFake : ITemplateResultService
    {

        List<TemplateProject> projects = new List<TemplateProject>();
        List<TemplateResult> templateResults = new List<TemplateResult>();
        List<TemplateResultItem> templateResultItems = new List<TemplateResultItem>();          

        public TemplateResultServiceFake() 
        {
            DataFakeTemplateProject();
            DataFakeTemplateResult();
        }

        public async Task<List<TemplateResult>> GetAllTemplateResult()
        {   
            await Task.Delay(1);
            return templateResults;
        }

        public async Task<TemplateResult> DetailTemplateResult(int id)
        {
            await Task.Delay(1);
            return templateResults.Where(o=>o.TemplateResultId==id).First();
        }

        public async Task<TemplateResultItem> DetailTemplateResultItem(int id)
        {
            await Task.Delay(1);
            return templateResultItems.Where(o => o.TemplateResultItemId == id).First();
        }

        public async Task<List<TemplateResultItem>> DetailTemplateResultItems(int id)
        {
            await Task.Delay(1);
            return templateResultItems.Where(o => o.TemplateResultId == id).ToList();
        }        

        public async Task<TemplateResult> CreateTemplateResult()
        {
            TemplateResult technique = new TemplateResult();
            await Task.Delay(1);
            return technique;
        }

        public async Task<TemplateResult> CreateTemplateResult(TemplateResult templateResult)
        {
            templateResults.Add(templateResult);
            await Task.Delay(1);
            return templateResult;
        }

        public async Task<TemplateResultItem> CreateTemplateResultItem()
        {
            TemplateResultItem TemplateResultItem = new TemplateResultItem();
            await Task.Delay(1);
            return TemplateResultItem;
        }

        public async Task<TemplateResultItem> CreateTemplateResultItem(TemplateResultItem templateResultItem)
        {
            templateResultItems.Add(templateResultItem);
            await Task.Delay(1);
            return templateResultItem;
        }

        public async Task<TemplateResult> EditTemplateResult(int id)
        {
            TemplateResult templateResult = templateResults.Where(o => o.TemplateResultId == id).First();
            await Task.Delay(1);
            return await EditTemplateResult(templateResult);
        }

        public async Task<TemplateResult> EditTemplateResult(TemplateResult templateResult)
        {
            TemplateResult result = templateResults.Where(o => o.TemplateResultId == templateResult.TemplateResultId).First();
            result.TemplateProjectId = templateResult.TemplateProjectId;
            result.TemplateResultDescription = templateResult.TemplateResultDescription;
            result.TemplateResultItem = templateResult.TemplateResultItem;
            result.TemplateResultName = templateResult.TemplateResultName;
            result.TemplateResultTitle = templateResult.TemplateResultTitle;
            result.TemplateResultVersion = templateResult.TemplateResultVersion;
            result.TemplateResultVersionNET = templateResult.TemplateResultVersionNET;
            await Task.Delay(1);
            return result;
        }

        public Task<TemplateResultItem> EditTemplateResultItem(int id)
        {
            TemplateResultItem templateResultItem = templateResultItems.Where(o => o.TemplateResultItemId == id).First();
            return EditTemplateResultItem(templateResultItem);
        }

        public async Task<TemplateResultItem> EditTemplateResultItem(TemplateResultItem templateResultItem)
        {
            TemplateResultItem _templateResultItem = templateResultItems.Where(o => o.TemplateResultItemId == templateResultItem.TemplateResultItemId).First();
            _templateResultItem.TemplateFonctionnelId = templateResultItem.TemplateFonctionnelId;
            _templateResultItem.TemplateResultFinalContent = templateResultItem.TemplateResultFinalContent;
            _templateResultItem.TemplateResultInitialContent = templateResultItem.TemplateResultInitialContent;
            _templateResultItem.TemplateResultItemDescription = templateResultItem.TemplateResultItemDescription;
            _templateResultItem.TemplateResultItemId = templateResultItem.TemplateResultItemId;
            _templateResultItem.TemplateResultItemName = templateResultItem.TemplateResultItemName;
            _templateResultItem.TemplateResultItemTitle = templateResultItem.TemplateResultItemTitle;
            _templateResultItem.TemplateResultItemVersion = templateResultItem.TemplateResultItemVersion;
            _templateResultItem.TemplateResultItemVersionNET = templateResultItem.TemplateResultItemVersionNET;
            _templateResultItem.TemplateTechniqueId = templateResultItem.TemplateTechniqueId;
            await Task.Delay(1);
            return _templateResultItem;
        }       
              
        public List<TemplateResult> DataTestTemplateResult()
        {
            return templateResults;
        }

        public List<TemplateResultItem> DataTestTemplateResultItem()
        {
            return templateResultItems;
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

        public void DataFakeTemplateResult()
        {
            templateResultItems.Add(new TemplateResultItem
            {
                TemplateResultItemId = 1,
                TemplateFonctionnelId=1,
                TemplateResultId=1,
                TemplateResultFinalContent= "TemplateResultFinalContent1",
                TemplateResultInitialContent = "TemplateResultInitialContent1",
                TemplateResultItemDescription = "TemplateResultItemDescription1",
                TemplateResultItemName= "TemplateResultItemName1",
                TemplateResultItemTitle = "TemplateResultItemTitle1",
                TemplateResultItemVersion= "TemplateResultItemVersion1",
                TemplateResultItemVersionNET= "TemplateResultItemVersionNET1"
            });

            templateResultItems.Add(new TemplateResultItem
            {
                TemplateResultItemId = 2,
                TemplateFonctionnelId = 1,
                TemplateResultId = 2,
                TemplateResultFinalContent = "TemplateResultFinalContent2",
                TemplateResultInitialContent = "TemplateResultInitialContent2",
                TemplateResultItemDescription = "TemplateResultItemDescription2",
                TemplateResultItemName = "TemplateResultItemName2",
                TemplateResultItemTitle = "TemplateResultItemTitle2",
                TemplateResultItemVersion = "TemplateResultItemVersion2",
                TemplateResultItemVersionNET = "TemplateResultItemVersionNET2"
            });

            List<TemplateResultItem> TemplateResultItem1 = new List<TemplateResultItem>();
            TemplateResultItem1.Add(templateResultItems[0]);
            templateResults.Add(new TemplateResult
            {
                TemplateResultId = 1,
                TemplateProjectId=1,
                TemplateResultDescription= "TemplateResultDescription1",
                TemplateResultName = "TemplateResultName1",
                TemplateResultTitle = "TemplateResultTitle1",
                TemplateResultVersion= "TemplateResultVersion1",
                TemplateResultVersionNET= "TemplateResultVersionNET1",
                TemplateResultItem= TemplateResultItem1
            });

            templateResults.Add(new TemplateResult
            {
                TemplateResultId = 2,
                TemplateProjectId = 1,
                TemplateResultDescription = "TemplateResultDescription2",
                TemplateResultName = "TemplateResultName2",
                TemplateResultTitle = "TemplateResultTitle2",
                TemplateResultVersion = "TemplateResultVersion2",
                TemplateResultVersionNET = "TemplateResultVersionNET2"
            });
        }

        public void DeleteTemplateResult(int id)
        {
            TemplateResult templateResult = templateResults.Where(o => o.TemplateResultId == id).First();
            templateResults.Remove(templateResult);
        }

        public void DeleteTemplateTechniqueItem(int id)
        {
            TemplateResultItem templateResultItem = templateResultItems.Where(o => o.TemplateResultItemId == id).First();
            templateResultItems.Remove(templateResultItem);
        }
    }
}
