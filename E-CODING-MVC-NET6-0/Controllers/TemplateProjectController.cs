using _4___E_CODING_DAL;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using E_CODING_Service_Abstraction;
using E_CODING_Services;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_MVC_NET6_0.InfraStructure.TemplateFonctionnel;
using E_CODING_MVC_NET6_0.InfraStructure.Project;
using Ganss.Xss;
using Microsoft.CodeAnalysis;
using E_CODING_MVC_NET6_0.InfraStructure.Solution;
using _4___E_CODING_DAL.Models;


namespace E_CODING_MVC_NET6_0
{

    [Route("TemplateProject")]
    public class TemplateProjectController : Controller
    {
        private ITemplateSolutionApiClient _solutionApiClient;
        private ITemplateProjectApiClient _projectApiClient;
        private ITemplateTechniqueApiClient _techniqueApiClient;
        private ITemplateResultApiClient _resultApiClient;
        private ITemplateFonctionnelApiClient _fonctionnelApiClient;

        private const string _clientSolutionName = "ClientApiSolution";
        private const string _clientProjectName = "ClientApiProject";
        private const string _clientTechniqueName = "ClientApiTechnique";
        private const string _clientFonctionnelName = "ClientApiFonctionnel";
        private const string _clientResultName = "ClientApiResult";

        public TemplateProjectController(
                        ITemplateSolutionApiClient solutionApiClient,
                        ITemplateProjectApiClient projectApiClient,
                        ITemplateTechniqueApiClient techniqueApiClient,
                        ITemplateResultApiClient resultApiClient,
                        ITemplateFonctionnelApiClient fonctionnelApiClient)
        {
            _solutionApiClient= solutionApiClient;
            _projectApiClient = projectApiClient;
            _techniqueApiClient = techniqueApiClient;
            _resultApiClient = resultApiClient;
            _fonctionnelApiClient = fonctionnelApiClient;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            List<TemplateSolutionVM> solutions = await _solutionApiClient.GetAllTemplateSolution(_clientSolutionName, "api/TemplateSolution/Index");
            ViewData["Solutions"] = new SelectList(solutions, "TemplateSolutionId", "TemplateSolutionName");
            return View();
        }

        [HttpGet]
        [Route("ProjetsBySolution")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<JsonResult> ProjetsBySolution(int id)
        {
            List<TemplateProjectVM?> projets = await _projectApiClient.GetAllTemplateProject(_clientProjectName, "api/TemplateProject/ProjectBySolution/" + id);
            return Json(projets, new JsonSerializerOptions { WriteIndented = true });
        }

        [HttpGet]
        [Route("TemplatesByProject")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<JsonResult> TemplatesByProject(int id)
        {
            ICollection<TemplateTechniqueVM> templates = await _techniqueApiClient.GetAllTemplateTechnique(_clientTechniqueName, "api/TemplateTechnique/ProjectAllTechniques/" + id.ToString());
            return Json(templates, new JsonSerializerOptions { WriteIndented = true });
        }

        [HttpGet]
        [Route("DetailsTechnique/{id}")]
        public async Task<IActionResult> DetailsTechnique(int id)
        {
            TemplateProjectVM projects = await _projectApiClient.GetTemplateProject(_clientProjectName, "api/TemplateProject/ProjectDetails/" + id);
            ICollection<TemplateTechniqueVM> templates = _techniqueApiClient.GetAllTemplateTechnique(_clientProjectName, "api/TemplateTechnique/ProjectAllTechniques/" + id.ToString()).Result;
            projects.TemplateTechnique = templates;
            return View(projects);  
        }

        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            TemplateProjectVM? templateProjectVM = await _projectApiClient.GetTemplateProject(_clientProjectName, "api/TemplateProject/ProjectDetails/" + id);
            ICollection<TemplateTechniqueVM> templateTechniques =  _techniqueApiClient.GetAllTemplateTechnique(_clientTechniqueName, "api/TemplateTechnique/ProjectAllTechniques/" + id).Result;
            if(templateTechniques!=null) 
                templateProjectVM.TemplateTechnique = templateTechniques;
            return View(templateProjectVM);
        }

        [HttpGet]
        [Route("DetailsEntity")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> DetailsEntity(int id)
        {
            TemplateProjectVM? templateProjectVM = await _projectApiClient.GetTemplateProject(_clientProjectName,"api/TemplateProject/ProjectDetails?id=" + id);
            List<TemplateFonctionnelEntityVM> TemplateTechniquesVM = await _fonctionnelApiClient.GetAllTemplateFonctionnelEntity(_clientProjectName,"api/TemplateProject/FonctionnelEntityDetails?id=" + id);
            return Json(TemplateTechniquesVM, new JsonSerializerOptions { WriteIndented = true });
        }

        [HttpGet]
        [Route("DetailsFonctionnel")]
        public async Task<IActionResult> DetailsFonctionnel(int id)
        {
            TemplateFonctionnelVM templateProjectVM = await _fonctionnelApiClient.GetTemplateFonctionnel(_clientProjectName, "api/TemplateFonctionnel/FonctionnelEntityDetails?id=" + id);
            List<TemplateFonctionnelEntityVM> templateProjectEntitiesVM = await _fonctionnelApiClient.GetAllTemplateFonctionnelEntity(_clientProjectName, "api/TemplateFonctionnel/FonctionnelAllEntities?id=" + id);
            List<TemplateFonctionnelPropertyVM> TemplateFonctionnelPropertiesVM = await _fonctionnelApiClient.GetAllTemplateFonctionnelProperty(_clientProjectName, "api/TemplateFonctionnel/FonctionnelAllProperties?id=" + id);
            return View(templateProjectVM);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            TemplateProjectVM? templateProjectVM = await _projectApiClient.GetTemplateProject(_clientProjectName,"api/TemplateProject/ProjectDetails/" + id);
            return View(templateProjectVM);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, TemplateProjectVM templateProjectVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateProjectVM), Encoding.UTF8, "application/json");
            await this._projectApiClient.PostTemplateProject(_clientProjectName, "api/TemplateProject/Edit/"+id, content);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("EditDescription")]
        public async Task<IActionResult> EditDescription(int id , string description)
        {
            TemplateProjectVM? templateProjectVM = await _projectApiClient.GetTemplateProject(_clientProjectName, "api/TemplateProject/ProjectDetails/" + id);
            templateProjectVM.TemplateProjectDescription=description;
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateProjectVM), Encoding.UTF8, "application/json");
            await this._projectApiClient.PostTemplateProject(_clientProjectName, "api/TemplateProject/Edit", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateTemplateProject()
        {
            TemplateProjectVM templateProjectVM = new TemplateProjectVM();
            return  View(templateProjectVM);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTemplateProject(TemplateProjectVM templateProjectVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateProjectVM), Encoding.UTF8, "application/json");
            await this._projectApiClient.PostTemplateProject(_clientProjectName,"api/TemplateProject/Create", content);
            return RedirectToAction("Index");
        }

        [HttpPost("{id}")]
        [Route("Delete")]
        public async Task<IActionResult> DeleteTemplateProject(int id)
        {
            await this._projectApiClient.DeleteTemplateProject(_clientProjectName,$"api/TemplateProject/Delete/{id}");
            return RedirectToAction("Index");
        }

        [HttpPost("{id}")]
        [Route("DeleteAjax")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> DeleteAjaxTemplateProject(int id)
        {
            await this._projectApiClient.DeleteTemplateProject(_clientProjectName, $"api/TemplateProject/Delete/{id}");
            return Json(false, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
