using _4___E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_Service_Abstraction.Solution
{
    public interface ITemplateSolutionRepository
    {
        List<TemplateSolution> GetAllTemplateSolution();
        TemplateSolution GetTemplateSolution(int id);
        List<TemplateSolution> GetAllTemplateSolution(int id);
        List<TemplateProject> GetAllTemplateProject(int id);
        void CreateTemplateSolution(TemplateSolution templateSolution);
        void UpdateTemplateSolution(TemplateSolution templateSolution);
        void DeleteTemplateSolution(TemplateSolution templateSolution);
    }
}
