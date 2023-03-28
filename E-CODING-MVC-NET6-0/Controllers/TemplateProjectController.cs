﻿using _4___E_CODING_DAL;
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

namespace E_CODING_MVC_NET6_0
{

    [Route("TemplateProject")]
    public class TemplateProjectController : Controller
    {
        private ITemplateProjectApiClient _projectApiClient;
        private ITemplateTechniqueApiClient _techniqueApiClient;
        private ITemplateResultApiClient _resultApiClient;
        private ITemplateFonctionnelApiClient _fonctionnelApiClient;

        private const string _clientProjectName = "ClientApiProject";
        private const string _clientTechniqueName = "ClientApiTechnique";
        private const string _clientFonctionnelName = "ClientApiFonctionnel";
        private const string _clientResultName = "ClientApiResult";

        public TemplateProjectController(
                        ITemplateProjectApiClient projectApiClient,
                        ITemplateTechniqueApiClient techniqueApiClient,
                        ITemplateResultApiClient resultApiClient,
                        ITemplateFonctionnelApiClient fonctionnelApiClient)
        {
            _projectApiClient = projectApiClient;
            _techniqueApiClient = techniqueApiClient;
            _resultApiClient = resultApiClient;
            _fonctionnelApiClient = fonctionnelApiClient;
        }

        [HttpGet]
        [Route("TemplateProject/Index")]
        public async Task<IActionResult> TemplateProjectIndex()
        {
            List<TemplateProjectVM?> templateProjectVMs = await _projectApiClient.GetAllTemplateProject(_clientProjectName,"api/TemplateProject/Index");
            
            return View(templateProjectVMs);
        }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            TemplateProjectVM? templateProjectVM = await _projectApiClient.GetTemplateProject(_clientProjectName,"api/TemplateProject/Details?id=" + id);
            return View(templateProjectVM);
        }

        [HttpGet]
        [Route("DetailsTechnique")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> DetailsTechnique(int id)
        {
            TemplateProjectVM? templateProjectVM = await _projectApiClient.GetTemplateProject(_clientProjectName,"api/TemplateProject/ProjectDetails?id=" + id);
            List<TemplateTechniqueVM> TemplateTechniquesVM = await _techniqueApiClient.GetAllTemplateTechnique(_clientProjectName,"api/TemplateProject/TechniqueDetails?id=" + id);
            return Json(TemplateTechniquesVM, new JsonSerializerOptions { WriteIndented = true });
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
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            TemplateProjectVM? templateProjectVM = await _projectApiClient.GetTemplateProject(_clientProjectName,"api/TemplateProject/ProjectDetails?id=" + id);
            return View(templateProjectVM);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(TemplateProjectVM templateProjectVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateProjectVM), Encoding.UTF8, "application/json");
            await this._projectApiClient.PostTemplateProject(_clientProjectName,"api/TemplateProject/Edit", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> CreateTemplateProject()
        {
            TemplateProjectVM templateProjectVM = new TemplateProjectVM();
            return View(templateProjectVM);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTemplateProject(TemplateProjectVM templateProjectVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateProjectVM), Encoding.UTF8, "application/json");
            await this._projectApiClient.PostTemplateProject(_clientProjectName,"api/TemplateProject/Create", content);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteTemplateProject(int id)
        {
            await this._projectApiClient.DeleteTemplateProject(_clientProjectName,"api/TemplateProject/Delete?id=" + id);
            return RedirectToAction("Index");
        }

    }
}
