using _4___E_CODING_DAL.Models;
using E_CODING_MVC_NET6_0;
using E_CODING_MVC_NET6_0.InfraStructure.Project;
using E_CODING_MVC_NET6_0.InfraStructure.TemplateFonctionnel;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Services.Project;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTestingFrontMVCTemplateProject.Mock;

namespace UnitTestingFrontMVCTemplateProject
{
    public class TemplateProjectFrontMVCControllerTests
    {
        private readonly Mock<ITemplateProjectApiClient> _mockProjectApiClient;
        private readonly Mock<ITemplateTechniqueApiClient> _mockTechniqueApiClient;
        private readonly Mock<ITemplateResultApiClient> _mockResultApiClient;
        private readonly Mock<ITemplateFonctionnelApiClient> _mockFonctionnelApiClient;
        public TemplateProjectFrontMVCControllerTests()
        {
            _mockTechniqueApiClient = new Mock<ITemplateTechniqueApiClient>();
            _mockResultApiClient = new Mock<ITemplateResultApiClient>();
            _mockFonctionnelApiClient = new Mock<ITemplateFonctionnelApiClient>();
            _mockProjectApiClient = new Mock<ITemplateProjectApiClient>();
        }

        [Fact]
        public async Task Index_ActionExecutes_ReturnsViewForIndex()
        {
            var _controller = new TemplateProjectController(
                _mockProjectApiClient.Object,
                _mockTechniqueApiClient.Object,
                _mockResultApiClient.Object,
                _mockFonctionnelApiClient.Object);
            var result = await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public async Task Index_ActionExecutes_ReturnsExactNumberOfEmployees()
        {
                var _controller = new TemplateProjectController(
                _mockProjectApiClient.Object,
                _mockTechniqueApiClient.Object,
                _mockResultApiClient.Object,
                _mockFonctionnelApiClient.Object);

            _mockProjectApiClient.Setup(repo => repo.GetAllTemplateProject(It.IsAny<string>(), 
                                                                           It.IsAny<string>()))
            .Returns(GetTestTemplateProjects());
            var result = await _controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var employees = Assert.IsType<List<TemplateProjectVM>>(viewResult.Model);
            Assert.Equal(2, employees.Count);
        }

        
        private async Task<List<TemplateProjectVM>> GetTestTemplateProjects()
        {
            await Task.Delay(1);
            var templateProjects = new List<TemplateProjectVM>();
            templateProjects.Add(new TemplateProjectVM()
            {
                TemplateProjectId=1,
                TemplateProjectName= "TemplateProjectName1",
                TemplateProjectTitle = "TemplateProjectTitle1",
                TemplateProjectDescription = "TemplateProjectDescription1",
                TemplateProjectVersion = "TemplateProjectVersion1",
                TemplateProjectVersionNet = "TemplateProjectVersionNet1",
            });
            templateProjects.Add(new TemplateProjectVM()
            {
                TemplateProjectId = 2,
                TemplateProjectName = "TemplateProjectName2",
                TemplateProjectTitle = "TemplateProjectTitle2",
                TemplateProjectDescription = "TemplateProjectDescription2",
                TemplateProjectVersion = "TemplateProjectVersion2",
                TemplateProjectVersionNet = "TemplateProjectVersionNet2",
            });
            return templateProjects;
        }

    }
}