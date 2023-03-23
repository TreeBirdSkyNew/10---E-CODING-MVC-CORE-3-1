using _4___E_CODING_DAL.Models;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Service_Abstraction.Project;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace __WEB_API__TemplateProject_WebApi_Tests.Mocks
{
    internal class MockIProjectRepository
    {
        public static Mock<ITemplateProjectRepository> GetMock()
        {
            var mock = new Mock<ITemplateProjectRepository>();
            var templateProjects = new List<TemplateProject>()
            {
                new TemplateProject()
                {
                    TemplateProjectId =1,
                    TemplateProjectName =   "TemplateProjectName1",
                    TemplateProjectTitle =   "TemplateProjectTitle1",
                    TemplateProjectDescription =   "TemplateProjectDescription1",
                    TemplateProjectVersion =   "TemplateProjectVersion1",
                    TemplateProjectVersionNet =   "TemplateProjectVersionNet1",
                },
                new TemplateProject()
                {
                    TemplateProjectId =2,
                    TemplateProjectName =   "TemplateProjectName2",
                    TemplateProjectTitle =   "TemplateProjectTitle2",
                    TemplateProjectDescription =   "TemplateProjectDescription2",
                    TemplateProjectVersion =   "TemplateProjectVersion2",
                    TemplateProjectVersionNet =   "TemplateProjectVersionNet2",
                }
            };

            // Set up
            mock.Setup(m => m.GetAllTemplateProject()).Returns(() => templateProjects);

            mock.Setup(m => m.FindByCondition(It.IsAny<int>()))
                .Returns((int id) => templateProjects.FirstOrDefault(o => o.TemplateProjectId == id));

             mock.Setup(m => m.CreateTemplateProject(It.IsAny<TemplateProject>()))
                .Callback(() => { return; });

            mock.Setup(m => m.UpdateTemplateProject(It.IsAny<TemplateProject>()))
               .Callback(() => { return; });

            mock.Setup(m => m.DeleteTemplateProject(It.IsAny<TemplateProject>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
