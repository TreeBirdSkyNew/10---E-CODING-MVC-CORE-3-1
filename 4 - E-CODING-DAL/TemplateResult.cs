using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL
{
    public class TemplateResult
    {
        public TemplateResult()
        {
            TemplateResultItem = new HashSet<TemplateResultItem>();
        }
        public int TemplateResultId { get; set; }
        public string TemplateResultName { get; set; }
        public string TemplateResultVersion { get; set; }
        public string TemplateResultVersionNET { get; set; }
        public string TemplateResultTitle { get; set; }
        public string TemplateResultDescription { get; set; }
        public int TemplateProjectId { get; set; }
        public IList<ProjectResult> ProjectResult { get; set; }
        public ICollection<TemplateResultItem> TemplateResultItem { get; set; }
    }
}
