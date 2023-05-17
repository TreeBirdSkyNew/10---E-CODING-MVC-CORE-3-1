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
        public int TemplateProjectId { get; set; }
        public string TemplateSolutionName { get; set; } = string.Empty;
        public string TemplateSolutionTitle { get; set; } = string.Empty;
        public string TemplateSolutionDescription { get; set; } = string.Empty;
        public string TemplateSolutionVersion { get; set; } = string.Empty;
        public string TemplateSolutionVersionNet { get; set; } = string.Empty;
        public Category? Category { get; set; } 
        public ICollection<SolutionProject> SolutionProject { get; set; }
    }
}
