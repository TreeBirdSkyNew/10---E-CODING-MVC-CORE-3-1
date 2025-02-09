using _4___E_CODING_DAL;
using _4___E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_MVC_NET6_0.InfraStructure.Project;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_MVC_NET6_0.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{
    [Route("TemplateTechnique")]
    public class TemplateTechniqueController : Controller
    {
        private ITemplateTechniqueApiClient _techniqueApiClient;
        private ITemplateProjectApiClient _projectApiClient;
        private const string _clientName = "ClientApiTechnique";
        private const string _clientProjectName = "ClientApiProject";

        public TemplateTechniqueController(
            ITemplateProjectApiClient projectApiClient,
            ITemplateTechniqueApiClient techniqueApiClient)
        {
            _techniqueApiClient = techniqueApiClient;
            _projectApiClient = projectApiClient;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index(int? selectedProjectId)
        {
            List<TemplateProjectVM> projects = await _projectApiClient.GetAllTemplateProject(_clientProjectName, "api/TemplateProject/Index");
            var viewModel = new ProjectViewModel
            {
                Projects = projects,
                SelectedProjectId = selectedProjectId ?? 0
            };
            return View(viewModel);        
        }

        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            TemplateProjectVM projects = await _projectApiClient.GetTemplateProject(_clientProjectName, "api/TemplateProject/ProjectDetails/" + id);
            ICollection<TemplateTechniqueVM> templates = _techniqueApiClient.GetAllTemplateTechnique(_clientName, "api/TemplateTechnique/ProjectAllTechniques/" + id.ToString()).Result;
            projects.TemplateTechnique = templates;
            return View(projects);  // Vue partielle qui affiche les templates
        }

        [Route("TechniqueItems/{id}")]
        [HttpGet]
        public async Task<IActionResult> TechniqueItems(int id)
        {
            TemplateTechniqueVM template = await _techniqueApiClient.GetTemplateTechnique(_clientName, "api/TemplateTechnique/TechniqueDetails/" + id.ToString());
            return View(template);
        }

        [HttpGet]
        [Route("CreateTechnique")]
        public IActionResult CreateTemplateTechnique()
        {
            TemplateTechniqueVM templateTechniqueVM = new TemplateTechniqueVM();
            return View(templateTechniqueVM);
        }

        [HttpPost]
        [Route("CreateTechnique")]
        public async Task<IActionResult> CreateTemplateTechnique(TemplateTechniqueVM templateTechniqueVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateTechniqueVM), Encoding.UTF8, "application/json");
            await this._techniqueApiClient.PostTemplateTechnique(_clientName, "api/TemplateTechnique/CreateTechnique", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditTechnique/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            TemplateTechniqueVM templateTechniqueVM = await _techniqueApiClient.GetTemplateTechnique(_clientName, "api/TemplateTechnique/TechniqueDetails/" + id);
            return View(templateTechniqueVM);
        }

        [HttpPost]
        [Route("EditTechnique/{id}")]
        public async Task<IActionResult> Edit(int id,TemplateTechniqueVM templateTechniqueVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateTechniqueVM), Encoding.UTF8, "application/json");
            await this._techniqueApiClient.PostTemplateTechnique(_clientName, "api/TemplateTechnique/EditTechnique/"+id, content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("DeleteTechnique")]
        public IActionResult DeleteTemplateTechnique(int id)
        {
            this._techniqueApiClient.DeleteTemplateTechnique(_clientName, "api/TemplateTechnique/Delete?id=" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("TechniqueAllItems")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> TemplateTechniqueItems(int id)
        {
            IEnumerable<TemplateTechniqueItemVM> templateTechniqueItemVMs = await _techniqueApiClient.GetAllTemplateTechniqueItem(_clientName, "api/TemplateTechnique/TechniqueAllItems/" + id);
            await Task.Delay(1);
            return Json(templateTechniqueItemVMs, new JsonSerializerOptions { WriteIndented = true });
        }

        [HttpGet]
        [Route("TechniqueItemDetails")]
        public async Task<IActionResult> TemplateTechniqueItem(int id)
        {
            TemplateTechniqueItemVM templateTechniqueItemVM = await _techniqueApiClient.GetTemplateTechniqueItem(_clientName, "api/TemplateTechnique/TechniqueItemDetails?id=" + id);
            return View(templateTechniqueItemVM);

        }

        [HttpGet]
        [Route("CreateTechniqueItem/{id}")]
        public async Task<IActionResult> CreateTemplateTechniqueItem(int id)
        {
            await Task.Delay(1);
            TemplateTechniqueItemVM templateTechniqueItemVM = new TemplateTechniqueItemVM();
            templateTechniqueItemVM.TemplateTechniqueId = id;
            return View(templateTechniqueItemVM);
        }

        [HttpPost]
        [Route("CreateTechniqueItem/{id}")]
        public async Task<IActionResult> CreateTemplateTechniqueItem(int id,TemplateTechniqueItemVM templateTechniqueItemVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateTechniqueItemVM), Encoding.UTF8, "application/json");
            await this._techniqueApiClient.PostTemplateTechniqueItem(_clientName, "api/TemplateTechnique/CreateTechniqueItem", content);
            return RedirectToAction("Index");
        }       


        [HttpGet]
        [Route("EditTechniqueItem/{id}")]
        public async Task<IActionResult> EditTemplateTechniqueItem(int id)
        {
            TemplateTechniqueItemVM templateTechniqueVM = await _techniqueApiClient.GetTemplateTechniqueItem(_clientName, "api/TemplateTechnique/TechniqueItemDetails/" + id);
            return View(templateTechniqueVM);
        }

        [HttpPost]
        [Route("EditTechniqueItem/{id}")]
        public async Task<IActionResult> EditTemplateTechniqueItem(int id,TemplateTechniqueItemVM templateTechniqueItemVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateTechniqueItemVM), Encoding.UTF8, "application/json");
            await this._techniqueApiClient.PostTemplateTechniqueItem(_clientName, "api/TemplateTechnique/EditTechniqueItem/" + id, content);
            return RedirectToAction("Index");
        }               
    }
}
