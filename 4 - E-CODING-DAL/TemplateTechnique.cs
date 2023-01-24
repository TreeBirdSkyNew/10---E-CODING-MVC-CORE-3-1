using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL
{
    public class TemplateTechnique
    {
        public TemplateTechnique()
        {
            TemplateTechniqueItem = new HashSet<TemplateTechniqueItem>();
        }
        public int TemplateTechniqueId { get; set; }
        public string TemplateTechniqueName { get; set; }
        public string TemplateTechniqueVersion { get; set; }
        public string TemplateTechniqueTitle { get; set; }
        public string TemplateTechniqueDescription { get; set; }
        public string TemplateTechniqueVersionNET { get; set; }
        public int TemplateProjectId { get; set; }
        public IList<ProjectTechnique> ProjectTechnique { get; set; }
        public ICollection<TemplateTechniqueItem> TemplateTechniqueItem { get; set; }
    }
}
