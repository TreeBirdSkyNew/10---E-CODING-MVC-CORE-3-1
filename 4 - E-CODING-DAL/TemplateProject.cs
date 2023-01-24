using System;
using System.Collections.Generic;

namespace _4___E_CODING_DAL
{
    public class TemplateProject
    {
        public int TemplateProjectId { get; set; }
        public string TemplateProjectName { get; set; }       
        public string TemplateProjectTitle { get; set; }
        public string TemplateProjectDescription { get; set; }
        public string TemplateProjectVersion { get; set; }
        public string TemplateProjectVersionNet { get; set; }
        public TemplateFonctionnel TemplateFonctionnel { get; set; }
        public ICollection<ProjectTechnique> ProjectTechnique { get; set; }
        public ICollection<ProjectResult> ProjectResult { get; set; }
    }
}
