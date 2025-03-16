using _4___E_CODING_DAL.Models;
using _4___E_CODING_DAL;
using E_CODING_Service_Abstraction.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace E_CODING_Service_Abstraction.Solution
{
    public class TemplateSolutionRepository
    : RepositoryBase<TemplateSolution>, ITemplateSolutionRepository
    {

        public TemplateSolutionRepository(TemplateProjectDbContext templateProjectDbContext) : base(templateProjectDbContext)
        {
        }

        public List<TemplateSolution> GetAllTemplateSolution()
        {
            return FindAll().ToList();
        }

        public List<TemplateSolution> GetAllTemplateSolution(int id)
        {
            var solution = FindByCondition(TemplateSolution => TemplateSolution.TemplateSolutionId.Equals(id))
                .Include(x => x.ChildSolutions)
                .FirstOrDefault();

            return solution.ChildSolutions.ToList();
        }

        public List<TemplateProject> GetAllTemplateProject(int id)
        {
            var solution = FindByCondition(TemplateSolution => TemplateSolution.TemplateSolutionId.Equals(id))
                .Include(x => x.TemplateProject)
                .FirstOrDefault();

            return solution.TemplateProject.ToList();
        }

        public TemplateSolution GetTemplateSolution(int id)
        {
            return FindByCondition(TemplateSolution => TemplateSolution.TemplateSolutionId.Equals(id))
                    .FirstOrDefault();
        }

        public void CreateTemplateSolution(TemplateSolution templateSolution)
        {
            Create(templateSolution);
        }

        public void UpdateTemplateSolution(TemplateSolution templateSolution)
        {
            Update(templateSolution);
        }

        public void DeleteTemplateSolution(TemplateSolution templateSolution)
        {
            Delete(templateSolution);
        }

        
    }
}
