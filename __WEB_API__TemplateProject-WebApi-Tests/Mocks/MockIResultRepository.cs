using _4___E_CODING_DAL.Models;
using E_CODING_Service_Abstraction.Result;
using E_CODING_Service_Abstraction.Technique;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __WEB_API__TemplateProject_WebApi_Tests.Mocks
{
    internal class MockIResultRepository
    {
        public static Mock<ITemplateResultRepository> GetMock()
        {
            var mock = new Mock<ITemplateResultRepository>();
            var templateResults = new List<TemplateResult>()
            {
                new TemplateResult()
                {
                    TemplateResultId =1,
                    TemplateProjectId= 1,
                    TemplateResultName = "TemplateResultName1",
                    TemplateResultTitle = "TemplateResultTitle1",
                    TemplateResultDescription = "TemplateResultDescription1",
                    TemplateResultVersion = "TemplateResultVersion1",
                    TemplateResultItem = new List<TemplateResultItem>()
                    {
                        new TemplateResultItem()
                        {
                            TemplateResultItemId =1,
                            TemplateTechniqueId =1,
                            TemplateResultItemName = "TemplateResultItemName1",
                            TemplateResultItemTitle = "TemplateResultItemTitle1",
                            TemplateResultItemDescription = "TemplateResultItemDescription1",
                            TemplateResultItemVersion = "TemplateResultItemVersion1"
                        },
                        new TemplateResultItem()
                        {
                            TemplateResultItemId =2,
                            TemplateTechniqueId =1,
                            TemplateResultItemName = "TemplateResultItemName2",
                            TemplateResultItemTitle = "TemplateResultItemTitle2",
                            TemplateResultItemDescription = "TemplateResultItemDescription2",
                            TemplateResultItemVersion = "TemplateResultItemVersion2"
                        }
                    }
                }
            };

            // Set up
            mock.Setup(m => m.GetAllTemplateResult()).Returns(() => templateResults);

            mock.Setup(m => m.FindByCondition(It.IsAny<int>()))
                .Returns((int id) => templateResults.FirstOrDefault(o => o.TemplateProjectId == id));

            mock.Setup(m => m.CreateTemplateResult(It.IsAny<TemplateResult>()))
               .Callback(() => { return; });

            mock.Setup(m => m.UpdateTemplateResult(It.IsAny<TemplateResult>()))
               .Callback(() => { return; });

            mock.Setup(m => m.DeleteTemplateResult(It.IsAny<TemplateResult>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
