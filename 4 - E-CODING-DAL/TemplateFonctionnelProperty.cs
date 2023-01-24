using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL
{
    public class TemplateFonctionnelProperty
    {
        public int TemplateFonctionnelPropertyId { get; set; }
        public int TemplateFonctionnelEntityId { get; set; }
        public int TemplateFonctionnelId { get; set; }
        public string TemplateFonctionnelPropertyName { get; set; }
        public string TemplateFonctionnelPropertyTitle { get; set; }
        public string TemplateFonctionnelPropertyDescription { get; set; }
        public string TemplateFonctionnelPropertyVersionEF { get; set; }
        public string TemplateFonctionnelPropertyVersionNET { get; set; }
        //public TemplateSharpToSQLType PropertyType { get; set; }
        public TemplateFonctionnelEntity TemplateFonctionnelEntity { get; set; }
    }
}
