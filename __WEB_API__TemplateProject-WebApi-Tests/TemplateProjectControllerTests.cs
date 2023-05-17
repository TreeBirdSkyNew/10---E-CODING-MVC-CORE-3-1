using __WEB_API__TemplateProject_WebApi.Controllers;
using __WEB_API__TemplateProject_WebApi;
using _4___E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TemplateProject_WebApi;

namespace __WEB_API__TemplateProject_WebApi_Tests.Mocks
{
    public class TemplateProjectControllerTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public void WhenGettingAllOwners_ThenAllOwnersReturn()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var templateController = new TemplateProjectController(repositoryWrapperMock.Object, mapper, logger);

            var result = templateController.Index() as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<TemplateProjectVM>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<TemplateProjectVM>);
        }

    }
}
