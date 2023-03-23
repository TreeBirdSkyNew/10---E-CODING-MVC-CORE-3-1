using _4___E_CODING_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateResultVM
    {
        public TemplateResultVM()
        {
            TemplateResultItemVM = new HashSet<TemplateResultItemVM>();
        }

        public int TemplateResultId { get; set; }
        public int TemplateFonctionnelId { get; set; }
        public int TemplateTechniqueId { get; set; }
        public int TemplateProjetId { get; set; }
        public string TemplateResultName { get; set; } = string.Empty;
        public string TemplateResultVersion { get; set; } = string.Empty;
        public string TemplateResultVersionNET { get; set; } = string.Empty;
        public string TemplateResultTitle { get; set; } = string.Empty;
        public string TemplateResultDescription { get; set; } = string.Empty;

        public virtual TemplateProjectVM? TemplateProjectVM { get; set; }
        public virtual ICollection<TemplateResultItemVM>? TemplateResultItemVM { get; set; }
    }
}
