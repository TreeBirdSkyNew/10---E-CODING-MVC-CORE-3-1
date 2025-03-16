using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4___E_CODING_DAL.Models
{
    public class TemplateSolution
    {
        public int TemplateSolutionId { get; set; }
        public string TemplateSolutionName { get; set; }
        public string TemplateSolutionTitle { get; set; }
        public string TemplateSolutionDescription { get; set; }
        public string TemplateSolutionVersion { get; set; }
        public string TemplateSolutionVersionNet { get; set; }

        public int? ParentSolutionId { get; set; }
        public TemplateSolution ParentSolution { get; set; }
        public ICollection<TemplateSolution> ChildSolutions { get; set; }
        public ICollection<TemplateProject> TemplateProject { get; set; }
    }
}
