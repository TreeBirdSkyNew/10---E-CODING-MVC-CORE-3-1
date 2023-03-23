using E_CODING_Service_Abstraction.Project;
using E_CODING_Service_Abstraction.Result;
using E_CODING_Service_Abstraction.Technique;
using E_CODING_Services.Project;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __WEB_API__TemplateProject_WebApi_Tests.Mocks
{
    internal class MockIRepositoryWrapper
    {
        public static Mock<IProjectRepositoryWrapper> GetMock()
        {
            var mock = new Mock<IProjectRepositoryWrapper>();
            var projectRepoMock = MockIProjectRepository.GetMock();
            var techniqueRepoMock = MockITechniqueRepository.GetMock();
            var resultRepoMock = MockIResultRepository.GetMock();

            mock.Setup(m => m.ProjectRepository).Returns(() => new Mock<ITemplateProjectRepository>().Object);
            mock.Setup(m => m.TechniqueRepository).Returns(() => new Mock<ITemplateTechniqueRepository>().Object);
            mock.Setup(m => m.ResultRepository).Returns(() => new Mock<ITemplateResultRepository>().Object);
            mock.Setup(m => m.Save()).Callback(() => { return; });

            return mock;
        }
    }
}
