using System;
using System.Collections.Generic;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateProjectVM
    {
        public int TemplateProjectId { get; set; }
        public string TemplateProjectName { get; set; }
        public string TemplateProjectTitle { get; set; }
        public string TemplateProjectDescription { get; set; }
        public string TemplateProjectVersion { get; set; }
        public string TemplateProjectVersionNet { get; set; }
        public TemplateFonctionnelVM TemplateFonctionnelVM { get; set; }
        public List<TemplateTechniqueVM> TemplateTechniquesVM { get; set; }
        public List<TemplateResultVM> TemplateResultsVM { get; set; }
    }
}
