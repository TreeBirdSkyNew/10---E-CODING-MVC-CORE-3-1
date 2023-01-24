using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL
{
    public class TemplateFonctionnelEntity
    {
        public int TemplateFonctionnelEntityId { get; set; }
        public int TemplateFonctionnelId { get; set; }
        public string TemplateFonctionnelEntityName { get; set; }
        public string TemplateFonctionnelEntityTitle { get; set; }
        public string TemplateFonctionnelEntityDescription { get; set; }
        public string TemplateFonctionnelEntityContent { get; set; }
        public string TemplateFonctionnelEntityTypeNet { get; set; }
        public string TemplateFonctionnelEntityTypeSQL { get; set; }
        public string TemplateFonctionnelEntityVersionEF { get; set; }
        public string TemplateFonctionnelEntityVersionNET { get; set; }
        public TemplateFonctionnel TemplateFonctionnel { get; set; }
        public ICollection<TemplateFonctionnelProperty> TemplateFonctionnelProperty { get; set; }
    }

}
