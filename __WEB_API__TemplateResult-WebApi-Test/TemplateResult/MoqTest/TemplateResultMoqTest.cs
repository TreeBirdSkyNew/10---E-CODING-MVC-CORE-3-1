using __WEB_API__TemplateResult_WebApi;
using _4___E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace __WEB_API__TemplateTechnique_WebApi_Test
{
    public class TemplateResultMoqTest
    {
        private Mock<ITemplateResultService> _mockServiceResult;
        private IMapper _mapper;
        
        public TemplateResultMoqTest()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Index_TemplateTechnique_ReturnOK()
        {
            _mockServiceResult = new Mock<ITemplateResultService>();
            _mockServiceResult.Setup(repo => repo.GetAllTemplateResult())
            .Returns(TestAllTemplateResult());

            var controller = new TemplateResultController(_mapper, _mockServiceResult.Object);
            var result = await controller.Index();

            var okResult = controller.Index().Result as OkObjectResult;
            var items = Assert.IsType<List<TemplateResultVM>>(okResult.Value);
        }        

        public async Task<List<TemplateResult>> TestAllTemplateResult()
        {
            List<TemplateResultItem> TemplateResultItems1 = new List<TemplateResultItem>();           
            TemplateResultItem templateResultItem1 = new TemplateResultItem();
            templateResultItem1.TemplateResultItemId = 1;
            templateResultItem1.TemplateResultId = 1;
            templateResultItem1.TemplateFonctionnelId = 1;
            templateResultItem1.TemplateResultFinalContent = "TemplateResultFinalContent";
            templateResultItem1.TemplateResultItemName = "TemplateResultItemName";
            templateResultItem1.TemplateResultItemTitle = "TemplateResultItemTitle";
            templateResultItem1.TemplateResultItemVersion = "TemplateResultItemVersion";
            templateResultItem1.TemplateResultInitialContent = "TemplateResultInitialContent";
            templateResultItem1.TemplateResultItemDescription = "TemplateResultItemDescription";
            templateResultItem1.TemplateResultItemVersionNET = "TemplateResultItemVersionNET";
            TemplateResultItems1.Add(templateResultItem1);

            TemplateResult templateResult1 = new TemplateResult();
            templateResult1.TemplateResultId = 1;
            templateResult1.TemplateProjectId = 1;
            templateResult1.TemplateResultDescription = "TemplateResultDescription1";
            templateResult1.TemplateResultName = "TemplateResultName1";
            templateResult1.TemplateResultTitle = "TemplateResultTitle1";
            templateResult1.TemplateResultVersion = "TemplateResultVersion1";
            templateResult1.TemplateResultVersionNET = "TemplateResultVersionNET1";
            templateResult1.TemplateResultItem = TemplateResultItems1;

            List<TemplateResultItem> TemplateResultItems2 = new List<TemplateResultItem>();
            TemplateResultItem templateResultItem2 = new TemplateResultItem();
            templateResultItem2.TemplateResultItemId = 2;
            templateResultItem2.TemplateResultId = 2;
            templateResultItem2.TemplateFonctionnelId = 1;
            templateResultItem2.TemplateResultFinalContent = "TemplateResultFinalContent";
            templateResultItem2.TemplateResultItemName = "TemplateResultItemName";
            templateResultItem2.TemplateResultItemTitle = "TemplateResultItemTitle";
            templateResultItem2.TemplateResultItemVersion = "TemplateResultItemVersion";
            templateResultItem2.TemplateResultInitialContent = "TemplateResultInitialContent";
            templateResultItem2.TemplateResultItemDescription = "TemplateResultItemDescription";
            templateResultItem2.TemplateResultItemVersionNET = "TemplateResultItemVersionNET";
            TemplateResultItems2.Add(templateResultItem2);

            TemplateResult templateResult2 = new TemplateResult();
            templateResult2.TemplateResultId = 2;
            templateResult2.TemplateProjectId = 1;
            templateResult2.TemplateResultDescription = "TemplateResultDescription2";
            templateResult2.TemplateResultName = "TemplateResultName2";
            templateResult2.TemplateResultTitle = "TemplateResultTitle2";
            templateResult2.TemplateResultVersion = "TemplateResultVersion2";
            templateResult2.TemplateResultVersionNET = "TemplateResultVersionNET2";
            templateResult2.TemplateResultItem = TemplateResultItems2;

            List<TemplateResult> TemplateResults = new List<TemplateResult>();
            TemplateResults.Add(templateResult1);
            TemplateResults.Add(templateResult2);

            await Task.Delay(1);
            return TemplateResults;
        }
    }
}
