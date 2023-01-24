using _4___E_CODING_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateResulItemVM
    {
        public int TemplateResultItemId { get; set; }
        public int TemplateResultId { get; set; }
        public int TemplateTechniqueId { get; set; }
        public int TemplateProjectId { get; set; }
        public string TemplateResultItemName { get; set; }
        public string TemplateResultItemVersion { get; set; }
        public string TemplateResultItemVersionNET { get; set; }
        public string TemplateResultItemTitle { get; set; }
        public string TemplateResultItemDescription { get; set; }
        public virtual TemplateResultVM TemplateResultVM { get; set; }
    }
}
