using __WEB_API__TemplateTechnique_WebApi_Test._TemplateTechnique.UnitTest.FakeTest;
using _4___E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using TemplateTechnique_WebApi;
using Xunit;

namespace __WEB_API__TemplateTechnique_WebApi_Test
{
    public class TemplateTechniqueFakeTest
    {
        TemplateTechniqueController _controller;
        private readonly ITemplateTechniqueService _service;
        private readonly IMapper _mapper;

        public TemplateTechniqueFakeTest()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
            _service = new TemplateTechniqueServiceFake();
            _controller = new TemplateTechniqueController(_mapper, _service);
        }
            
        [Fact]
        public async Task Index_ReturnsOkResult()
        {
            var okResult = await _controller.Index() as OkObjectResult;
            var items = Assert.IsType<List<TemplateTechniqueVM>>(okResult.Value);
        }

        [Fact]
        public async Task Detail_TemplateTechnique_ReturnsOK()
        {
            var okResult = await _controller.TemplateTechniqueDetail(1) as OkObjectResult;
            Assert.IsType<TemplateTechniqueVM>(okResult.Value);
            Assert.Equal(1, (okResult.Value as TemplateTechniqueVM).TemplateTechniqueId);
        }

        [Fact]
        public async Task Edit_TemplateTechnique_ReturnsOK()
        {
            var okResult = await _controller.TemplateTechniqueEdit(1) as OkObjectResult;
            TemplateTechniqueVM templateTechniqueVM = okResult.Value as TemplateTechniqueVM;
            TemplateTechnique templateTechnique = _mapper.Map<TemplateTechnique>(templateTechniqueVM);
            templateTechnique.TemplateTechniqueVersion = "5.0";
            var okResultEdit = await _controller.TemplateTechniqueEdit(templateTechnique) as OkObjectResult;
            Assert.IsType<TemplateTechniqueVM>(okResult.Value);
            okResult = await _controller.TemplateTechniqueEdit(1) as OkObjectResult;
            Assert.Equal("5.0", (okResult.Value as TemplateTechniqueVM).TemplateTechniqueVersion);
        }

        [Fact]
        public async Task Create_TemplateTechnique_ReturnOk()
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

            var createdResponse = await _controller.TemplateTechniqueCreate(templateTechnique) as CreatedAtActionResult;
            var okResult = _controller.Index().Result as OkObjectResult;
            var items = Assert.IsType<List<TemplateTechniqueVM>>(okResult.Value);
        }

        [Fact]
        public async Task Create_TemplateTechniqueItem_ReturnOk()
        {
            TemplateTechniqueItem templateTechniqueItem = new TemplateTechniqueItem();
            templateTechniqueItem.TemplateTechniqueId = 1;
            templateTechniqueItem.TemplateTechniqueItemId = 5;
            templateTechniqueItem.TemplateTechniqueItemDescription = "TemplateTechniqueItemDescription3";
            templateTechniqueItem.TemplateTechniqueInitialFile = "TemplateTechniqueInitialFile3";
            templateTechniqueItem.TemplateTechniqueItemName = "TemplateTechniqueItemName3";
            templateTechniqueItem.TemplateTechniqueItemTitle = "TemplateTechniqueItemTitle3";
            templateTechniqueItem.TemplateTechniqueItemVersion = "TemplateTechniqueItemVersion3";
            templateTechniqueItem.TemplateTechniqueItemVersionNET = "Create_TemplateTechniqueItem_ReturnOk";

            var createdResponse = await _controller.CreateTemplateTechniqueItem(templateTechniqueItem) as CreatedAtActionResult;
            
            var okResult = _controller.TemplateTechniqueItems(1).Result as OkObjectResult;
            var items = Assert.IsType<List<TemplateTechniqueItemVM>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }
    }
}
