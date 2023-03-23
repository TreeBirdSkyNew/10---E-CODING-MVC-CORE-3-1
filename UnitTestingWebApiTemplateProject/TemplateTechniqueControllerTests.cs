﻿using _4___E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Services.Technique;
using FluentAssertions;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TemplateProject_WebApi;
using TemplateTechnique_WebApi;
using UnitTestingWebApiTechniqueProject.Mock;
using Xunit;

namespace UnitTestingWebApiTechniqueProject
{
    public class TemplateTechniqueControllerTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new TemplateTechnique_WebApi.MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public void WhenGettingAllTemplateTechnique_ThenAllTemplateTechniqueReturn()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var ownerController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);

            var result = ownerController.Index() as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<TemplateTechniqueVM>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<TemplateTechniqueVM>);
        }

        [Fact]
        public void GivenAnIdOfAnExistingTemplateTechnique_WhenGettingTemplateTechniqueItemsById_ThenTemplateTechniqueItemsReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var ownerController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);
            var id = 1;
            var result = ownerController.TemplateTechniqueAllItems(id) as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<TemplateTechniqueItemVM>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<TemplateTechniqueItemVM>);
        }

        [Fact]
        public void GivenAnIdOfANonExistingTechnique_WhenGettingTechniqueItemsById_ThenNotFoundReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var ownerController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);
            var id = 2;
            var result = ownerController.TemplateTechniqueAllItems(id) as StatusCodeResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public void GivenAnIdOfAnExistingTemplateTechnique_WhenGettingTemplateTechniqueItemById_ThenTemplateTechniqueItemReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var ownerController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);
            var id = 1;
            var result = ownerController.TemplateTechniqueDetails(id) as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<TemplateTechniqueVM>(result.Value);
            Assert.NotNull(result.Value as TemplateTechniqueVM);
        }

        [Fact]
        public void GivenAnIdOfANonExistingTechniqueDetails_WhenGettingTechniqueDetailsById_ThenNotFoundReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var ownerController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);
            var id = 2;
            var result = ownerController.TemplateTechniqueDetails(id) as StatusCodeResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public void GivenValidRequest_WhenCreatingOwner_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var ownerController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);
            var owner = new TemplateTechniqueVM()
            {
                TemplateTechniqueId = 2,
                TemplateTechniqueName = "TemplateTechniqueName1",
                TemplateTechniqueVersion = "TemplateTechniqueVersion1",
                TemplateTechniqueTitle = "TemplateTechniqueTitle1",
                TemplateTechniqueDescription = "TemplateTechniqueDescription1",
                TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET1",
                TemplateProjectId = 1
            };
            var result = ownerController.TemplateTechniqueCreate(owner) as ObjectResult;
            Assert.NotNull(result);
            Assert.IsAssignableFrom<CreatedAtRouteResult>(result);
            Assert.Equal((int)HttpStatusCode.Created, result!.StatusCode);
            Assert.Equal("TemplateTechniqueId", (result as CreatedAtRouteResult)!.RouteName);
        }

        [Fact]
        public void GivenValidRequest_WhenuPDATINGOwner_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockTechniqueRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var ownerController = new TemplateTechniqueController(logger, mapper, repositoryWrapperMock.Object);

            var ownerFinal = new TemplateTechniqueVM()
            {
                TemplateTechniqueId = 1,
                TemplateTechniqueName = "TemplateTechniqueName3",
                TemplateTechniqueVersion = "TemplateTechniqueVersion3",
                TemplateTechniqueTitle = "TemplateTechniqueTitle3",
                TemplateTechniqueDescription = "TemplateTechniqueDescription3",
                TemplateTechniqueVersionNET = "TemplateTechniqueVersionNET3",
                TemplateProjectId = 1
            };           

            var initialTemplateTechnique = ownerController.TemplateTechniqueEdit(1, ownerFinal);
            var finalTemplateTechnique = ownerController.TemplateTechniqueDetails(1) as ObjectResult; 
            var ObjectResult = Assert.IsType<OkObjectResult>(finalTemplateTechnique);
            var testEmployee = finalTemplateTechnique.Value as TemplateTechniqueVM;
            Assert.Equal(ownerFinal.TemplateTechniqueId, testEmployee.TemplateTechniqueId);
        }

    }
}
