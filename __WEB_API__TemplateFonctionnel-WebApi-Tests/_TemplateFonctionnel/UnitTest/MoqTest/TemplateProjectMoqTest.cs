using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFonctionnel_WebApi;
using Xunit;

namespace __WEB_API__TemplateFonctionnel_WebApi_Tests
{
    public class TemplateFonctionnelMoqTest
    {
        private Mock<ITemplateFonctionnelService> _mockServiceFonctionnel;
        private IMapper _mapper;
        
        public TemplateFonctionnelMoqTest()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Index_TemplateTechnique_ReturnOK()
        {
            _mockServiceFonctionnel = new Mock<ITemplateFonctionnelService>();
            _mockServiceFonctionnel.Setup(repo => repo.GetAllTemplateFonctionnel())
            .Returns(TestAllTemplateFonctionnel());

            var controller = new TemplateFonctionnelController(_mapper, _mockServiceFonctionnel.Object);
            var result = await controller.Index();

            var okResult = controller.Index().Result as OkObjectResult;
            var items = Assert.IsType<List<TemplateFonctionnelVM>>(okResult);
        }
        

        public async Task<List<TemplateFonctionnel>> TestAllTemplateFonctionnel()
        {
            
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

            

            await Task.Delay(1);

            List<TemplateFonctionnel> templateFonctionnels = new List<TemplateFonctionnel>();
            templateFonctionnels.Add(templateFonctionnel);
            return templateFonctionnels;
        }
    }
}
