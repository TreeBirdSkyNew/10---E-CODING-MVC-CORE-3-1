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
    internal class MockIFonctionnelPropertyRepository
    {
        public static Mock<ITemplateFonctionnelPropertyRepository> GetMock()
        {
            var mock = new Mock<ITemplateFonctionnelPropertyRepository>();

            var templateFonctionnelProperties = new List<TemplateFonctionnelProperty>()
            {
                new TemplateFonctionnelProperty()
                {
                    TemplateFonctionnelEntityId=1,
                    TemplateFonctionnelPropertyId=1,
                    TemplateFonctionnelPropertyName="TemplateFonctionnelPropertyName1",
                    TemplateFonctionnelPropertyTitle="TemplateFonctionnelPropertyTitle1",
                    TemplateFonctionnelPropertyDescription="TemplateFonctionnelPropertyDescription1",
                    TemplateFonctionnelPropertyVersionEF="TemplateFonctionnelPropertyVersionEF1",
                    TemplateFonctionnelPropertyVersionNET="TemplateFonctionnelPropertyVersionNET1"
                },
                new TemplateFonctionnelProperty()
                {
                    TemplateFonctionnelEntityId=2,
                    TemplateFonctionnelPropertyId=2,
                    TemplateFonctionnelPropertyName="TemplateFonctionnelPropertyName2",
                    TemplateFonctionnelPropertyTitle="TemplateFonctionnelPropertyTitle2",
                    TemplateFonctionnelPropertyDescription="TemplateFonctionnelPropertyDescription2",
                    TemplateFonctionnelPropertyVersionEF="TemplateFonctionnelPropertyVersionEF2",
                    TemplateFonctionnelPropertyVersionNET="TemplateFonctionnelPropertyVersionNET2"
                }
            };


            // Set up
            mock.Setup(m => m.GetAllTemplateFonctionnelProperty(It.IsAny<int>())).Returns(() => templateFonctionnelProperties);

            mock.Setup(m => m.FindByCondition(It.IsAny<int>()))
                .Returns((int id) => templateFonctionnelProperties.FirstOrDefault(o => o.TemplateFonctionnelPropertyId == id));

            mock.Setup(m => m.CreateTemplateFonctionnelProperty(It.IsAny<TemplateFonctionnelProperty>()))
                .Callback(() => { return; });
            mock.Setup(m => m.UpdateTemplateFonctionnelProperty(It.IsAny<TemplateFonctionnelProperty>()))
               .Callback(() => { return; });
            mock.Setup(m => m.DeleteTemplateFonctionnelProperty(It.IsAny<TemplateFonctionnelProperty>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
