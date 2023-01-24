using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateFonctionnelEntityVM
    {
        public int TemplateFonctionnelEntityId { get; set; }
        public int TemplateFonctionnelId { get; set; }
        public string TemplateFonctionnelEntityName { get; set; }
        public string TemplateFonctionnelEntityTitle { get; set; }
        public string TemplateFonctionnelEntityDescription { get; set; }
        public string TemplateFonctionnelEntityContent { get; set; }
        public string TemplateFonctionnelEntityVersionEF { get; set; }
        public string TemplateFonctionnelEntityVersionNET { get; set; }
        public string TemplateFonctionnelEntityTypeNet { get; set; }
        public string TemplateFonctionnelEntityTypeSQL { get; set; }
        public virtual TemplateFonctionnelVM TemplateFonctionnelVM { get; set; }
    }

}
