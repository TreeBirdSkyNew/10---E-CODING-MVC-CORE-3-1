using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateFonctionnelPropertyVM
    {
        public int TemplateFonctionnelPropertyId { get; set; }
        public int TemplateFonctionnelEntityId { get; set; }
        public int TemplateFonctionnelId { get; set; }
        public int TemplateProjetId { get; set; }
        public string TemplateFonctionnelPropertyName { get; set; }
        public string TemplateFonctionnelPropertyTitle { get; set; }
        public string TemplateFonctionnelPropertyDescription { get; set; }
        public string TemplateFonctionnelPropertyContent { get; set; }
        public string TemplateFonctionnelPropertyVersionEF { get; set; }
        public string TemplateFonctionnelPropertyVersionNET { get; set; }
        public virtual TemplateFonctionnelVM TemplateFonctionnelVM { get; set; }
    }
}
