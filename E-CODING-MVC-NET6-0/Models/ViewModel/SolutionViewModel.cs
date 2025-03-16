namespace E_CODING_MVC_NET6_0.Models.ViewModel
{
    public class SolutionViewModel
    {
        public int SelectedSolutionId { get; set; }
        public List<TemplateSolutionVM> Solutions { get; set; }
        public int SelectedProjectId { get; set; }
        public List<TemplateProjectVM> Projects { get; set; }
    }
}
