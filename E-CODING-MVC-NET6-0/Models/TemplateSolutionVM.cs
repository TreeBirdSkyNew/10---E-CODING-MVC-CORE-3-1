﻿using _4___E_CODING_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0.Models
{
    public class TemplateSolutionVM
    {
        public int TemplateSolutionId { get; set; }
        public string TemplateSolutionName { get; set; }
        public string TemplateSolutionTitle { get; set; }
        public string TemplateSolutionDescription { get; set; }
        public string TemplateSolutionVersion { get; set; }
        public string TemplateSolutionVersionNet { get; set; }

        public int? ParentSolutionId { get; set; }
        public TemplateSolutionVM ParentSolution { get; set; }
        public ICollection<TemplateSolutionVM> ChildSolutions { get; set; }
        public ICollection<TemplateProjectVM> TemplateProject { get; set; }
    }
}
