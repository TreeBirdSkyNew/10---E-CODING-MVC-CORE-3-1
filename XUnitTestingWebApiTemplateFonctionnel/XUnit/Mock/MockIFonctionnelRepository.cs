using _4___E_CODING_DAL.Models;
using E_CODING_Service_Abstraction.Fonctionnel;
using E_CODING_Service_Abstraction.Technique;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestingWebApiTemplateFonctionnel.XUnit.Mock
{
    internal class MockIFonctionnelRepository
    {
        public static Mock<ITemplateFonctionnelRepository> GetMock()
        {
            var mock = new Mock<ITemplateFonctionnelRepository>();

            var templateFonctionnels = new List<TemplateFonctionnel>()
            {
                new TemplateFonctionnel()
                {
                    TemplateFonctionnelId=1,
                    TemplateFonctionnelName="TemplateFonctionnelName1",
                    TemplateFonctionnelContent="TemplateFonctionnelContent1",
                    TemplateFonctionnelTitle="TemplateFonctionnelTitle1",
                    TemplateFonctionnelDescription="TemplateFonctionnelDescription1",
                    TemplateFonctionnelEFVersion="TemplateFonctionnelEFVersion1",
                    TemplateProjectId=1
                },
                new TemplateFonctionnel()
                {
                    TemplateFonctionnelId=2,
                    TemplateFonctionnelName="TemplateFonctionnelName2",
                    TemplateFonctionnelContent="TemplateFonctionnelContent2",
                    TemplateFonctionnelTitle="TemplateFonctionnelTitle2",
                    TemplateFonctionnelDescription="TemplateFonctionnelDescription2",
                    TemplateFonctionnelEFVersion="TemplateFonctionnelEFVersion2",
                    TemplateProjectId=1
                }
            };


            // Set up
            mock.Setup(m => m.GetAllTemplateFonctionnel()).Returns(() => templateFonctionnels);

            mock.Setup(m => m.FindByCondition(It.IsAny<int>()))
                .Returns((int id) => templateFonctionnels.FirstOrDefault(o => o.TemplateFonctionnelId == id));

            mock.Setup(m => m.CreateTemplateFonctionnel(It.IsAny<TemplateFonctionnel>()))
                .Callback(() => { return; });
            mock.Setup(m => m.UpdateTemplateFonctionnel(It.IsAny<TemplateFonctionnel>()))
               .Callback(() => { return; });
            mock.Setup(m => m.DeleteTemplateFonctionnel(It.IsAny<TemplateFonctionnel>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
