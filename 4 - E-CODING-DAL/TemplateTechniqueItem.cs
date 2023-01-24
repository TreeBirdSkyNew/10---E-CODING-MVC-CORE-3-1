using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL
{
    public class TemplateTechniqueItem
    {
        public TemplateTechniqueItem()
        {    
            TemplateParameter = new HashSet<TemplateParameter>();             
        }
        public int TemplateTechniqueItemId { get; set; }
        public int TemplateTechniqueId { get; set; }
        public string TemplateTechniqueItemName { get; set; }        
        public string TemplateTechniqueItemTitle { get; set; }
        public string TemplateTechniqueItemDescription { get; set; }
        public string TemplateTechniqueItemVersion { get; set; }
        public string TemplateTechniqueItemVersionNET { get; set; }
        public string TemplateTechniqueInitialFile { get; set; }
        public string TemplateTechniqueFinalContent { get; set; }
        public TemplateTechnique TemplateTechnique { get; set; }
        public ICollection<TemplateParameter> TemplateParameter { get; set; }
    }
}
