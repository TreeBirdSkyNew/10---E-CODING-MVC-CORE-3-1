using _4___E_CODING_DAL.Models;
using E_CODING_Service_Abstraction.Project;
using E_CODING_Service_Abstraction.Technique;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace __WEB_API__TemplateProject_WebApi_Tests.Mocks
{
    internal class MockITechniqueRepository
    {
        public static Mock<ITemplateTechniqueRepository> GetMock()
        {
            var mock = new Mock<ITemplateTechniqueRepository>();
            var templateTechniques = new List<TemplateTechnique>()
            {
                new TemplateTechnique()
                {
                    TemplateTechniqueId =1,
                    TemplateProjectId= 1,
                    TemplateTechniqueName = "TemplateTechniqueName1",
                    TemplateTechniqueTitle = "TemplateTechniqueTitle1",
                    TemplateTechniqueDescription = "TemplateTechniqueDescription1",
                    TemplateTechniqueVersion = "TemplateTechniqueVersion1",
                    TemplateTechniqueItem = new List<TemplateTechniqueItem>()
                    {
                        new TemplateTechniqueItem()
                        {
                            TemplateTechniqueItemId =1,
                            TemplateTechniqueId =1,
                            TemplateTechniqueItemName = "TemplateTechniqueItemName1",
                            TemplateTechniqueItemTitle = "TemplateTechniqueItemTitle1",
                            TemplateTechniqueItemDescription = "TemplateTechniqueItemDescription1",
                            TemplateTechniqueItemVersion = "TemplateTechniqueItemVersion1"
                        },
                        new TemplateTechniqueItem()
                        {
                            TemplateTechniqueItemId =2,
                            TemplateTechniqueId =1,
                            TemplateTechniqueItemName = "TemplateTechniqueItemName2",
                            TemplateTechniqueItemTitle = "TemplateTechniqueItemTitle2",
                            TemplateTechniqueItemDescription = "TemplateTechniqueItemDescription2",
                            TemplateTechniqueItemVersion = "TemplateTechniqueItemVersion2"
                        }
                    }
                }
            };

            // Set up
            mock.Setup(m => m.GetAllTemplateTechnique()).Returns(() => templateTechniques);

            mock.Setup(m => m.FindByCondition(It.IsAny<int>()))
                .Returns((int id) => templateTechniques.FirstOrDefault(o => o.TemplateProjectId == id));

            mock.Setup(m => m.CreateTemplateTechnique(It.IsAny<TemplateTechnique>()))
               .Callback(() => { return; });

            mock.Setup(m => m.UpdateTemplateTechnique(It.IsAny<TemplateTechnique>()))
               .Callback(() => { return; });

            mock.Setup(m => m.DeleteTemplateTechnique(It.IsAny<TemplateTechnique>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
