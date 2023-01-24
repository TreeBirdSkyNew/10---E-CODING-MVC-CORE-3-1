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

namespace E_CODING_MVC_NET6_0
{

    [Route("TemplateProject")]
    public class TemplateProjectController : Controller
    {
        private readonly ITemplateProjectApiClient _itemplateProjectApiClient;
        private readonly ITemplateTechniqueApiClient _itemplateTechniqueApiClient;
        private readonly ITemplateResultApiClient _itemplateResultApiClient;
        private readonly ITemplateFonctionnelApiClient _itemplateFonctionnelApiClient;


        public TemplateProjectController(ITemplateProjectApiClient itemplateProjectApiClient,
                                         ITemplateTechniqueApiClient itemplateTechniqueApiClient,
                                         ITemplateResultApiClient itemplateResultApiClient,
                                         ITemplateFonctionnelApiClient itemplateFonctionnelApiClient)
        {
            _itemplateTechniqueApiClient = itemplateTechniqueApiClient;
            _itemplateFonctionnelApiClient = itemplateFonctionnelApiClient;
            _itemplateProjectApiClient = itemplateProjectApiClient;
            _itemplateResultApiClient = itemplateResultApiClient;
        }

        
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            List<TemplateProjectVM> templateProjectVMResult = new List<TemplateProjectVM>();
            List<TemplateProjectVM> templateProjectVMs = await _itemplateProjectApiClient.GetAllTemplateProject("api/TemplateProject/Index");
            foreach (TemplateProjectVM project in templateProjectVMs)
            {
                List<TemplateTechniqueVM> TemplateTechniquesVM = await _itemplateTechniqueApiClient.GetAllTemplateTechnique("api/TemplateTechnique/TemplateTechniqueByProject?id=" + project.TemplateProjectId);
                if (TemplateTechniquesVM!=null)
                {
                    project.TemplateTechniquesVM = TemplateTechniquesVM;
                }
                
                TemplateFonctionnelVM templateFonctionnelVM = await _itemplateFonctionnelApiClient.GetTemplateFonctionnel("api/TemplateFonctionnel/TemplateFonctionnelByProject?id=" + project.TemplateProjectId);
                if (TemplateTechniquesVM != null)
                {
                    project.TemplateFonctionnelVM = templateFonctionnelVM;
                }
                templateProjectVMResult.Add(project);
            }
            return View(templateProjectVMResult);
        }

        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            TemplateProjectVM templateProjectVM = await _itemplateProjectApiClient.GetTemplateProject("api/TemplateProject/Details?id=" + id);
            return View(templateProjectVM);
        }

        [Route("DetailsTechnique")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> DetailsTechnique(int id)
        {
            TemplateProjectVM templateProjectVM = await _itemplateProjectApiClient.GetTemplateProject("api/TemplateProject/Details?id=" + id);
            List<TemplateTechniqueVM> TemplateTechniquesVM = await _itemplateProjectApiClient.DetailsTechnique("api/TemplateProject/DetailsTechnique?id=" + id);
            return Json(TemplateTechniquesVM, new JsonSerializerOptions { WriteIndented = true });
        }

        [Route("DetailsEntity")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> DetailsEntity(int id)
        {
            TemplateProjectVM templateProjectVM = await _itemplateProjectApiClient.GetTemplateProject("api/TemplateProject/Details?id=" + id);
            List<TemplateFonctionnelEntityVM> TemplateTechniquesVM = await _itemplateProjectApiClient.DetailsEntity("api/TemplateProject/DetailsEntity?id=" + id);
            return Json(TemplateTechniquesVM, new JsonSerializerOptions { WriteIndented = true });
        }
        

        [Route("DetailsFonctionnel")]
        public async Task<IActionResult> DetailsFonctionnel(int id)
        {
            TemplateFonctionnelVM templateProjectVM = await _itemplateFonctionnelApiClient.GetTemplateFonctionnel("api/TemplateFonctionnel/Details?id=" + id);
            List<TemplateFonctionnelEntityVM> templateProjectEntitiesVM = await _itemplateFonctionnelApiClient.GetTemplateFonctionnelEntities("api/TemplateFonctionnel/DetailsEntity?id=" + id);
            List<TemplateFonctionnelPropertyVM> TemplateFonctionnelPropertiesVM = await _itemplateFonctionnelApiClient.GetTemplateFonctionnelProperties("api/TemplateFonctionnel/DetailsEntity?id=" + id);
            return View(templateProjectVM);
        }


        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            TemplateProjectVM templateProjectVM = await _itemplateProjectApiClient.GetTemplateProject("api/TemplateProject/Details?id=" + id);
            return View(templateProjectVM);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(TemplateProjectVM templateProjectVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateProjectVM), Encoding.UTF8, "application/json");
            await this._itemplateProjectApiClient.PostTemplateProject("api/TemplateProject/Edit", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> CreateTemplateProject()
        {
            TemplateProjectVM templateProjectVM = await _itemplateProjectApiClient.GetTemplateProject("api/TemplateProject/Create");
            return View(templateProjectVM);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTemplateProject(TemplateProjectVM templateProjectVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateProjectVM), Encoding.UTF8, "application/json");
            await this._itemplateProjectApiClient.PostTemplateProject("api/TemplateProject/Create", content);
            return RedirectToAction("Index");
        }

        [Route("Delete")]
        public async Task<IActionResult> DeleteTemplateProject(int id)
        {
            await this._itemplateProjectApiClient.DeleteTemplateProject("api/TemplateProject/Delete?id=" + id);
            return RedirectToAction("Index");
        }

    }
}
