using _4___E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Project
{
    public interface ITemplateProjectRepository
    {
        TemplateProject FindByCondition(int id);
        List<TemplateProject> GetAllTemplateProject();
        void CreateTemplateProject(TemplateProject templateProject);
        void UpdateTemplateProject(TemplateProject templateProject);
        void DeleteTemplateProject(TemplateProject templateProject);
    }
}
