using E_CODING_Services;
using E_CODING_Services.Technique;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestingWebApiTemplateFonctionnel.XUnit.Mock
{
    internal class MockFonctionnelRepositoryWrapper
    {
        public static Mock<IFonctionnelRepositoryWrapper> GetMock()
        {
            var mock = new Mock<IFonctionnelRepositoryWrapper>();
            var fonctionnelRepoMock = MockIFonctionnelRepository.GetMock();
            var fonctionnelEntityRepoMock = MockIFonctionnelEntityRepository.GetMock();
            var fonctionnelPropertyRepoMock = MockIFonctionnelPropertyRepository.GetMock();

            // Setup the mock
            mock.Setup(m => m.FonctionnelRepository).Returns(() => fonctionnelRepoMock.Object);
            mock.Setup(m => m.FonctionnelEntityRepository).Returns(() => fonctionnelEntityRepoMock.Object);
            mock.Setup(m => m.FonctionnelPropertyRepository).Returns(() => fonctionnelPropertyRepoMock.Object);
            mock.Setup(m => m.Save()).Callback(() => { return; });

            return mock;
        }
    }
}
