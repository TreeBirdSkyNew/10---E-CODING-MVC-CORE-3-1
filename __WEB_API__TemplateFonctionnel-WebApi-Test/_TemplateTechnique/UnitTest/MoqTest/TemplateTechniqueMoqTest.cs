using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateTechnique_WebApi;
using Xunit;

namespace __WEB_API__TemplateTechnique_WebApi_Test
{
    public class TemplateTechniqueMoqTest
    {
        private Mock<ITemplateTechniqueService> _mockServiceTechnique;
        private IMapper _mapper;
        
        public TemplateTechniqueMoqTest()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Index_TemplateTechnique_ReturnOK()
        {
            _mockServiceTechnique = new Mock<ITemplateTechniqueService>();
            _mockServiceTechnique.Setup(repo => repo.GetAllTemplateTechnique())
            .Returns(TestAllTemplateTechnique());

            var controller = new TemplateTechniqueController(_mapper,_mockServiceTechnique.Object);
            var result = await controller.Index();

            var okResult = controller.Index().Result as OkObjectResult;
            var items = Assert.IsType<List<TemplateTechniqueVM>>(okResult.Value);
        }        

        public async Task<List<TemplateTechnique>> TestAllTemplateTechnique()
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

            List<TemplateTechniqueItem> templateTechniqueItems4 = new List<TemplateTechniqueItem>();
            TemplateTechniqueItem templateTechniqueItem4 = new TemplateTechniqueItem();
            templateTechniqueItem4.TemplateTechniqueItemId = 4;
            templateTechniqueItem4.TemplateTechniqueItemDescription = "TemplateTechniqueItemDescription4";
            templateTechniqueItem4.TemplateTechniqueInitialFile = "TemplateTechniqueInitialFile4";
            templateTechniqueItem4.TemplateTechniqueItemName = "TemplateTechniqueItemName4";
            templateTechniqueItem4.TemplateTechniqueItemTitle = "TemplateTechniqueItemTitle4";
            templateTechniqueItem4.TemplateTechniqueItemVersion = "TemplateTechniqueItemVersion4";
            templateTechniqueItem4.TemplateTechniqueItemVersionNET = "TemplateTechniqueItemVersionNET4";
            templateTechniqueItems4.Add(templateTechniqueItem4);

            TemplateTechnique templateTechnique4 = new TemplateTechnique();
            templateTechnique4.TemplateTechniqueId = 4;
            templateTechnique4.TemplateProjectId = 4;
            templateTechnique4.TemplateTechniqueDescription = "TemplateTechniqueDescription4";
            templateTechnique4.TemplateTechniqueName = "TemplateTechniqueName4";
            templateTechnique4.TemplateTechniqueTitle = "TemplateTechniqueTitle4";
            templateTechnique4.TemplateTechniqueVersion = "TemplateTechniqueVersion4";
            templateTechnique4.TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET4";
            templateTechnique4.TemplateTechniqueItem = templateTechniqueItems4;            

            List<TemplateTechnique> templateTechniques = new List<TemplateTechnique>();
            templateTechniques.Add(templateTechnique);
            templateTechniques.Add(templateTechnique4);

            await Task.Delay(1);
            return templateTechniques;
        }
    }
}
