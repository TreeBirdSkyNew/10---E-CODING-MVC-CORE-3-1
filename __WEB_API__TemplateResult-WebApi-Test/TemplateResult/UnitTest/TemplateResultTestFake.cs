using __WEB_API__TemplateResult_WebApi;
using _4___E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;


namespace __WEB_API__TemplateTechnique_WebApi_Test._TemplateTechnique.UnitTest
{
    public class TemplateResultTestFake
    {
        TemplateResultController _controller;
        ITemplateResultService _service;
        IMapper _mapper;

        public TemplateResultTestFake()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
            _service = new TemplateResultServiceFake();
            _controller = new TemplateResultController(_mapper, _service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = _controller.Index();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var okResult = _controller.Index().Result as OkObjectResult;
            var items = Assert.IsType<List<TemplateResultVM>>(okResult.Value);
        }

        
        [Fact]
        public async Task Add_ValidObjectPassed_ReturnsCreatedResponseAsync()
        {
            List<TemplateResultItem> templateResultItems = new List<TemplateResultItem>();
            TemplateResultItem templateResultItem5 = new TemplateResultItem();
            templateResultItem5.TemplateResultItemId = 5;
            templateResultItem5.TemplateResultId = 5;
            templateResultItem5.TemplateFonctionnelId = 3;
            templateResultItem5.TemplateResultFinalContent = "TemplateResultFinalContent4";
            templateResultItem5.TemplateResultInitialContent = "TemplateResultInitialContent4";
            templateResultItem5.TemplateResultItemDescription = "TemplateResultItemDescription4";
            templateResultItem5.TemplateResultItemName = "TemplateResultItemName4";
            templateResultItem5.TemplateResultItemTitle = "TemplateResultItemTitle4";
            templateResultItem5.TemplateResultItemVersion = "TemplateResultItemVersion4";
            templateResultItem5.TemplateResultItemVersionNET = "TemplateResultItemVersionNET4";
            templateResultItems.Add(templateResultItem5);
            
            TemplateResultItem templateResultItem6 = new TemplateResultItem();
            templateResultItem6.TemplateResultItemId = 6;
            templateResultItem6.TemplateResultId = 5;
            templateResultItem6.TemplateFonctionnelId = 3;
            templateResultItem6.TemplateResultFinalContent = "TemplateResultFinalContent4";
            templateResultItem6.TemplateResultInitialContent = "TemplateResultInitialContent4";
            templateResultItem6.TemplateResultItemDescription = "TemplateResultItemDescription4";
            templateResultItem6.TemplateResultItemName = "TemplateResultItemName4";
            templateResultItem6.TemplateResultItemTitle = "TemplateResultItemTitle4";
            templateResultItem6.TemplateResultItemVersion = "TemplateResultItemVersion4";
            templateResultItem6.TemplateResultItemVersionNET = "TemplateResultItemVersionNET4";
            templateResultItems.Add(templateResultItem6);

            TemplateResult templateResult = new TemplateResult();
            templateResult.TemplateResultId = 5;
            templateResult.TemplateProjectId = 1;
            templateResult.TemplateResultDescription = "TemplateResultDescription3";
            templateResult.TemplateResultName = "TemplateResultName3";
            templateResult.TemplateResultTitle = "TemplateResultTitle3";
            templateResult.TemplateResultVersion = "TemplateResultVersion3";
            templateResult.TemplateResultVersionNET = "TemplateResultVersionNET3";
            templateResult.TemplateResultItem = templateResultItems;            

            TemplateProject templateProject = new TemplateProject();
            templateProject.TemplateProjectId = 3;
            templateProject.TemplateProjectDescription = "TemplateProjectDescription3";
            templateProject.TemplateProjectName = "TemplateProjectName3";
            templateProject.TemplateProjectTitle = "TemplateProjectTitle3";
            templateProject.TemplateProjectVersion = "TemplateProjectVersion3";
            templateProject.TemplateProjectVersionNet = "TemplateProjectVersionNet3";
            templateProject.ProjectResult = new List<ProjectResult>()
            {
               new ProjectResult()
               {
                   TemplateProjectId=3 ,
                   TemplateResultId=5,
                   TemplateResult=templateResult,
                   TemplateProject=templateProject
               },
               
             };

            var createdResponse = await _controller.TemplateResultCreate(templateResult) as CreatedAtActionResult;
            var okResult = _controller.Index().Result as OkObjectResult;
            var items = Assert.IsType<List<TemplateResultVM>>(okResult.Value);

        }
    }
}
