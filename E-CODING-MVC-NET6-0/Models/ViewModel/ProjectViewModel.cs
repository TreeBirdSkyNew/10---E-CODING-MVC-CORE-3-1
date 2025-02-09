using Microsoft.CodeAnalysis;

namespace E_CODING_MVC_NET6_0.Models.ViewModel
{
    public class ProjectViewModel
    {
        public int SelectedProjectId { get; set; }
        public List<TemplateProjectVM> Projects { get; set; }
    }
}
