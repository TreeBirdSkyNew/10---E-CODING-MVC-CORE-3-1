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
        public string TemplateSolutionName { get; set; } = string.Empty;
        public string TemplateSolutionTitle { get; set; } = string.Empty;
        public string TemplateSolutionDescription { get; set; } = string.Empty;
        public string TemplateSolutionVersion { get; set; } = string.Empty;
        public string TemplateSolutionVersionNet { get; set; } = string.Empty;
        public ICollection<SolutionProjectVM>? SolutionProject { get; set; }
    }
}
