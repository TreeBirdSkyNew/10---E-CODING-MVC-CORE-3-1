using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL
{
    public class TemplateFonctionnel
    {
        public TemplateFonctionnel()
        {
            TemplateFonctionnelEntity = new HashSet<TemplateFonctionnelEntity>();
        }
        public int TemplateFonctionnelId { get; set; }
        public string TemplateFonctionnelName { get; set; }        
        public string TemplateFonctionnelTitle { get; set; }
        public string TemplateFonctionnelDescription { get; set; }
        public string TemplateFonctionnelContent { get; set; }
        public string TemplateFonctionnelEFVersion { get; set; }
        public int TemplateProjectId { get; set; }
        public TemplateProject TemplateProject { get; set; }
        public ICollection<TemplateFonctionnelEntity> TemplateFonctionnelEntity { get; set; }
    }
}
