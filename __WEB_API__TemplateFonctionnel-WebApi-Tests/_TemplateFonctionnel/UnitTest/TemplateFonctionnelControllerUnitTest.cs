using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace __WEB_API__TemplateFonctionnel_WebApi_Tests._TemplateFonctionnel.UnitTest
{
    public class TemplateFonctionnelControllerUnitTest
    {
        private readonly Mock<ITemplateFonctionnelService> _mockItemplateFonctionnelService;
        private readonly Mock<IMapper> _mockMapper;

        public TemplateFonctionnelControllerUnitTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockItemplateFonctionnelService = new Mock<ITemplateFonctionnelService>();
        }

        public TemplateFonctionnelControllerUnitTest Instance()
        {
            return new TemplateFonctionnelControllerUnitTest();
        }

        [Fact]
        public void UnitTestTemplateFonctionnelIndex()
        {
            List<TemplateFonctionnelVM> listeTemplateFonctionnelVM = new List<TemplateFonctionnelVM>();
            listeTemplateFonctionnelVM.Add(
                new TemplateFonctionnelVM()
                {
                    TemplateFonctionnelId=1,
                    TemplateFonctionnelName= "TemplateFonctionnelName1",
                    TemplateFonctionnelTitle = "TemplateFonctionnelTitle1",
                    TemplateFonctionnelDescription = "TemplateFonctionnelDescription1",
                    TemplateFonctionnelContent = "TemplateFonctionnelContent1",
                    TemplateFonctionnelEFVersion = "TemplateFonctionnelEFVersion1",
                    TemplateProjectId = 1,
                    TemplateFonctionnelEntity = new List<TemplateFonctionnelEntityVM>()
                    {
                        
                    }
                }
            );
        }
    }
}
