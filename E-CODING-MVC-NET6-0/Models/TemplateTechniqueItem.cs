using _4___E_CODING_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateTechniqueItemVM
    {
        public int TemplateTechniqueItemId { get; set; }
        public int TemplateTechniqueId { get; set; }
        public string TemplateTechniqueItemName { get; set; }
        public string TemplateTechniqueItemTitle { get; set; }
        public string TemplateTechniqueItemDescription { get; set; }
        public string TemplateTechniqueItemVersion { get; set; }
        public string TemplateTechniqueItemVersionNET { get; set; }
        public string TemplateTechniqueInitialFile { get; set; }
        public string TemplateTechniqueFinalContent { get; set; }
        public TemplateTechniqueVM TemplateTechniqueVM { get; set; }

    }
}
