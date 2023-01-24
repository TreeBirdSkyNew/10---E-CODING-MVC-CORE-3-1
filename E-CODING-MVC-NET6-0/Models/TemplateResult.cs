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
            TemplateResultItemVM = new HashSet<TemplateResulItemVM>();
        }

        public int TemplateResultId { get; set; }
        public int TemplateFonctionnelId { get; set; }
        public int TemplateTechniqueId { get; set; }
        public int TemplateProjetId { get; set; }
        public string TemplateResultName { get; set; }
        public string TemplateResultVersion { get; set; }
        public string TemplateResultVersionNET { get; set; }
        public string TemplateResultTitle { get; set; }
        public string TemplateResultDescription { get; set; }

        public virtual TemplateProjectVM TemplateProjectVM { get; set; }
        public virtual ICollection<TemplateResulItemVM> TemplateResultItemVM { get; set; }
    }
}
