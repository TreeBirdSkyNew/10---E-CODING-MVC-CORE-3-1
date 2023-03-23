using _4___E_CODING_DAL;
using _4___E_CODING_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Project
{
    public class TemplateProjectRepository 
        : RepositoryBase<TemplateProject>, ITemplateProjectRepository
    {

        public TemplateProjectRepository(TemplateProjectDbContext templateProjectDbContext) : base(templateProjectDbContext)
        {
        }

        public IEnumerable<TemplateProject> GetAllTemplateProject()
        {
            return FindAll().ToList(); ;
        }

        public TemplateProject FindByCondition(int id)
        {
            return FindByCondition(TemplateProject => TemplateProject.TemplateProjectId.Equals(id))
                    .FirstOrDefault();
        }

        public void CreateTemplateProject(TemplateProject templateProject)
        {
            CreateTemplateProject(templateProject);
        }

        public void UpdateTemplateProject(TemplateProject templateProject)
        {
            UpdateTemplateProject(templateProject);
        }

        public void DeleteTemplateProject(TemplateProject templateProject)
        {
            DeleteTemplateProject(templateProject);
        }
    }
}
