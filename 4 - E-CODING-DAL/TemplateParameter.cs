using System;
using System.Collections.Generic;
using System.Text;

namespace _4___E_CODING_DAL
{
    public class TemplateParameter
    {
        public int TemplateParameterId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int TemplateTechniqueItemId { get; set; }
        public TemplateTechniqueItem TemplateTechniqueItem { get; set; }
    }
}
