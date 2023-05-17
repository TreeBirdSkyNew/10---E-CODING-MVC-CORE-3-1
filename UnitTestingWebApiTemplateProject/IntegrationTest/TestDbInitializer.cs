using _4___E_CODING_DAL.Models;
using _4___E_CODING_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UnitTestingWebApiTemplateProject.IntegrationTest
{
    public class TestDbInitializer
    {
        public static void TestDbContext()
        {
            var options = new DbContextOptionsBuilder<TemplateProjectDbContext>()
                     .UseInMemoryDatabase(Guid.NewGuid().ToString())
                     .Options;
            var context = new TemplateProjectDbContext(options);

            /*******************TemplateProject*************************/
            InitializeTemplateProject(context);
        }


        public static void InitializeTemplateProject(TemplateProjectDbContext context)
        {
            var templateProjects = new TemplateProject[]
            {
                new TemplateProject()
                {
                    TemplateProjectId = 1,
                    TemplateProjectDescription = "TemplateProjectDescription1",
                    TemplateProjectName = "TemplateProjectName1",
                    TemplateProjectTitle = "TemplateProjectTitle1",
                    TemplateProjectVersion = "TemplateProjectVersion1",
                    TemplateProjectVersionNet = "TemplateProjectVersionNet1"
                },
                new TemplateProject()
                {
                    TemplateProjectId = 2,
                    TemplateProjectDescription = "TemplateProjectDescription2",
                    TemplateProjectName = "TemplateProjectName2",
                    TemplateProjectTitle = "TemplateProjectTitle2",
                    TemplateProjectVersion = "TemplateProjectVersion2",
                    TemplateProjectVersionNet = "TemplateProjectVersionNet2"
                }
            };
            foreach (TemplateProject project in templateProjects)
            {
                context.TemplateProject.Add(project);
            }
            context.SaveChanges();
        }
    }
}
