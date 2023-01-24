using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL
{
    public class TemplateResultItem
    {
        public int TemplateResultItemId { get; set; }
        public int TemplateResultId { get; set; }
        public int TemplateTechniqueId { get; set; }
        public int TemplateFonctionnelId { get; set; }
        public string TemplateResultItemName { get; set; }
        public string TemplateResultItemTitle { get; set; }
        public string TemplateResultItemDescription { get; set; }
        public string TemplateResultItemVersion { get; set; }
        public string TemplateResultItemVersionNET { get; set; }        
        public string TemplateResultInitialContent { get; set; }
        public string TemplateResultFinalContent { get; set; }
        public TemplateResult TemplateResult { get; set; }
    }
}
