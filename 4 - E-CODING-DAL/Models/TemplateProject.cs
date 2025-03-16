using System;
using System.Collections.Generic;

namespace _4___E_CODING_DAL.Models
{
    public class TemplateProject
    {
        public int TemplateProjectId { get; set; }
        public string TemplateProjectName { get; set; } = string.Empty;
        public string TemplateProjectTitle { get; set; } = string.Empty;
        public string TemplateProjectDescription { get; set; } = string.Empty;
        public string TemplateProjectVersion { get; set; } = string.Empty;
        public string TemplateProjectVersionNet { get; set; } = string.Empty;
        public int TemplateSolutionId { get; set; }
        public TemplateSolution? TemplateSolution { get; set; }
        public ICollection<TemplateTechnique>? TemplateTechnique { get; set; }

    }
}
