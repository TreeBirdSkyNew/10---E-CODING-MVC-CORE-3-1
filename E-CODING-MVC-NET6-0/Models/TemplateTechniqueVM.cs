using _4___E_CODING_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateTechniqueVM
    {
        public TemplateTechniqueVM()
        {
            TemplateTechniqueItemVM = new HashSet<TemplateTechniqueItemVM>();
         }
        public int TemplateTechniqueId { get; set; }
        public int TemplateProjectId { get; set; }
        public string TemplateTechniqueName { get; set; } = string.Empty;
        public string TemplateTechniqueVersion { get; set; } = string.Empty;
        public string TemplateTechniqueVersionNET { get; set; } = string.Empty;
        public string TemplateTechniqueTitle { get; set; } = string.Empty;
        public string TemplateTechniqueDescription { get; set; } = string.Empty;
        public virtual TemplateProjectVM? TemplateProjectVM { get; set; }
        public virtual ICollection<TemplateTechniqueItemVM>? TemplateTechniqueItemVM { get; set; }
        public virtual ICollection<TemplateProjectVM>? TemplateProjectVMs { get; set; }

    }


}
