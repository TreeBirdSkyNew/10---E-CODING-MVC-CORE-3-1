using _4___E_CODING_DAL.Models;
using E_CODING_Service_Abstraction.Fonctionnel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestingWebApiTemplateFonctionnel.XUnit.Mock
{
    internal class MockIFonctionnelEntityRepository
    {
        public static Mock<ITemplateFonctionnelEntityRepository> GetMock()
        {
            var mock = new Mock<ITemplateFonctionnelEntityRepository>();

            var templateFonctionnelEntities = new List<TemplateFonctionnelEntity>()
            {
                new TemplateFonctionnelEntity()
                {
                    TemplateFonctionnelId=1,
                    TemplateFonctionnelEntityId=1,
                    TemplateFonctionnelEntityName="TemplateFonctionnelEntityName1",
                    TemplateFonctionnelEntityTitle="TemplateFonctionnelEntityTitle1",
                    TemplateFonctionnelEntityDescription="TemplateFonctionnelEntityDescription1",
                    TemplateFonctionnelEntityContent="TemplateFonctionnelEntityContent1",
                    TemplateFonctionnelEntityTypeNet="TemplateFonctionnelEntityTypeNet1",
                    TemplateFonctionnelEntityTypeSQL="TemplateFonctionnelEntityTypeSQL1",
                    TemplateFonctionnelEntityVersionEF="TemplateFonctionnelEntityVersionEF1",
                    TemplateFonctionnelEntityVersionNET="TemplateFonctionnelEntityVersionNET1"
                },
                new TemplateFonctionnelEntity()
                {
                    TemplateFonctionnelId=1,
                    TemplateFonctionnelEntityId=2,
                    TemplateFonctionnelEntityName="TemplateFonctionnelEntityName2",
                    TemplateFonctionnelEntityTitle="TemplateFonctionnelEntityTitle2",
                    TemplateFonctionnelEntityDescription="TemplateFonctionnelEntityDescription2",
                    TemplateFonctionnelEntityContent="TemplateFonctionnelEntityContent2",
                    TemplateFonctionnelEntityTypeNet="TemplateFonctionnelEntityTypeNet2",
                    TemplateFonctionnelEntityTypeSQL="TemplateFonctionnelEntityTypeSQL2",
                    TemplateFonctionnelEntityVersionEF="TemplateFonctionnelEntityVersionEF2",
                    TemplateFonctionnelEntityVersionNET="TemplateFonctionnelEntityVersionNET2"
                }
            };


            // Set up
            mock.Setup(m => m.GetAllTemplateFonctionnelEntity(It.IsAny<int>())).Returns(() => templateFonctionnelEntities);

            mock.Setup(m => m.FindByCondition(It.IsAny<int>()))
                .Returns((int id) => templateFonctionnelEntities.FirstOrDefault(o => o.TemplateFonctionnelId == id));

            mock.Setup(m => m.CreateTemplateFonctionnelEntity(It.IsAny<TemplateFonctionnelEntity>()))
                .Callback(() => { return; });
            mock.Setup(m => m.UpdateTemplateFonctionnelEntity(It.IsAny<TemplateFonctionnelEntity>()))
               .Callback(() => { return; });
            mock.Setup(m => m.DeleteTemplateFonctionnelEntity(It.IsAny<TemplateFonctionnelEntity>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
