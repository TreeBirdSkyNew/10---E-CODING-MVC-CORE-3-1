using E_CODING_MVC_NET6_0.InfraStructure.Project;
using E_CODING_MVC_NET6_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using System.Net.Http;

namespace E_CODING_MVC_NET6_0.components
{
    public class ProjectTemplatesViewComponent : ViewComponent
    {
        private ITemplateTechniqueApiClient _techniqueApiClient;
        private ITemplateProjectApiClient _projectApiClient;
        private const string _clientTechnique = "ClientApiTechnique";
        private const string _clientProject = "ClientApiProject";

        public ProjectTemplatesViewComponent(
                    ITemplateTechniqueApiClient techniqueApiClient,
                    ITemplateProjectApiClient projectApiClient
            )
        {
            _techniqueApiClient = techniqueApiClient;
            _projectApiClient = projectApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Appel à l'API pour récupérer la liste des projets
            List<TemplateTechniqueVM> response = await _techniqueApiClient.GetAllTemplateTechnique(_clientTechnique, "api/TemplateTechnique/ProjectAllTechniques/1");

            // Retourne la vue partielle avec les projets récupérés
            return View(response);
        }
    }
}
