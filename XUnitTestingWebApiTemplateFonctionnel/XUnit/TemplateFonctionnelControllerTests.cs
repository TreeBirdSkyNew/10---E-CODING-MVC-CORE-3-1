using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TemplateFonctionnel_WebApi;
using Xunit;
using XUnitTestingWebApiTemplateFonctionnel.XUnit.Mock;

namespace XUnitTestingWebApiTemplateFonctionnel.XUnit
{
    public class TemplateFonctionnelControllerTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public void WhenGettingAllTemplateFonctionnel_ThenAllTemplateFonctionnelReturn()
        {
            var repositoryWrapperMock = MockFonctionnelRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var templateFonctionnelController = new TemplateFonctionnelController(repositoryWrapperMock.Object,mapper,logger );

            var result = templateFonctionnelController.Index() as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<TemplateFonctionnelVM>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<TemplateFonctionnelVM>);
        }

        [Fact]
        public void GivenValidRequest_WhenCreatingTemplateFonctionnel_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockFonctionnelRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var templateFonctionnelController = new TemplateFonctionnelController(repositoryWrapperMock.Object,mapper, logger  );

            var templateProject = new TemplateProjectVM()
            {
                TemplateProjectId = 1,
                TemplateProjectDescription = "TemplateProjectDescription1",
                TemplateProjectName = "TemplateProjectName1",
                TemplateProjectTitle = "TemplateProjectTitle1",
                TemplateProjectVersion = "TemplateProjectVersion1",
                TemplateProjectVersionNet = "TemplateProjectVersionNet1",
                
            };

            var templateFonctionnelProperties = new List<TemplateFonctionnelPropertyVM>()
            {
                new TemplateFonctionnelPropertyVM()  {
                    TemplateFonctionnelPropertyName = "TemplateTechniqueName1",
                    TemplateFonctionnelPropertyTitle = "TemplateTechniqueTitle1",
                    TemplateFonctionnelPropertyDescription = "TemplateTechniqueDescription1",
                    TemplateFonctionnelPropertyVersionEF = "TemplateTechniqueDescription1",
                    TemplateFonctionnelPropertyVersionNET = "TemplateTechniqueDescription1",
                    TemplateFonctionnelPropertyId = 1
                }
            };

            var templateFonctionnelEntities = new List<TemplateFonctionnelEntityVM>()
            {
                new TemplateFonctionnelEntityVM()  {
                    TemplateFonctionnelEntityName = "TemplateTechniqueName1",
                    TemplateFonctionnelEntityTitle = "TemplateTechniqueTitle1",
                    TemplateFonctionnelEntityDescription = "TemplateTechniqueDescription1",
                    TemplateFonctionnelEntityVersionEF = "TemplateTechniqueDescription1",
                    TemplateFonctionnelEntityVersionNET = "TemplateTechniqueDescription1",
                    TemplateFonctionnelEntityContent = "TemplateTechniqueDescription1",
                    TemplateFonctionnelEntityTypeNet = "TemplateTechniqueDescription1",
                    TemplateFonctionnelEntityTypeSQL = "TemplateTechniqueDescription1",
                    TemplateFonctionnelEntityId = 1,
                    TemplateFonctionnelProperty=templateFonctionnelProperties
                }
            };

            var templateFonctionnel = new TemplateFonctionnelVM()
            {
                TemplateFonctionnelName = "TemplateTechniqueName1",
                TemplateFonctionnelTitle = "TemplateTechniqueTitle1",
                TemplateFonctionnelDescription = "TemplateTechniqueDescription1",
                TemplateFonctionnelContent = "TemplateFonctionnelContent1",
                TemplateFonctionnelEFVersion = "TemplateFonctionnelEFVersion1",
                TemplateFonctionnelEntity= templateFonctionnelEntities,
                TemplateProjectId = 1,
            };


            var result = templateFonctionnelController.TemplateFonctionnelCreate(templateFonctionnel) as ObjectResult;
            Assert.NotNull(result);
            Assert.IsAssignableFrom<CreatedAtRouteResult>(result);
            Assert.Equal((int)HttpStatusCode.Created, result!.StatusCode);
            Assert.Equal("TemplateFonctionnelById", (result as CreatedAtRouteResult)!.RouteName);
        }
    }
}
