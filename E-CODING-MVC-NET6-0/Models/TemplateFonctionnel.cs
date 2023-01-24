using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateFonctionnelVM
    {
        public TemplateFonctionnelVM()
        {
           
        }

        public int TemplateFonctionnelId { get; set; }
        public string TemplateFonctionnelName { get; set; }
        public string TemplateFonctionnelTitle { get; set; }
        public string TemplateFonctionnelDescription { get; set; }
        public string TemplateFonctionnelContent { get; set; }
        public string TemplateFonctionnelEFVersion { get; set; }
        public int TemplateProjectId { get; set; }
        public TemplateProjectVM TemplateProject { get; set; }
        public virtual List<TemplateFonctionnelEntityVM> TemplateFonctionnelEntity { get; set; }
        

    }


    
    
}
