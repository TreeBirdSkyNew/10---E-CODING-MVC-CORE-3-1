using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private  ITemplateTechniqueApiClient _techniqueApiClient;
        public TemplateTechniqueController(ITemplateTechniqueApiClient techniqueApiClient)
        {
            _techniqueApiClient = techniqueApiClient;
        }
        
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            List<TemplateTechniqueVM> projectsVMs = await _techniqueApiClient.GetAllTemplateTechnique("api/TemplateTechnique/Index");
            await Task.Delay(1);
            return View(projectsVMs);
        }

        [HttpGet]
        [Route("TemplateTechniqueByProject")]
        public async Task<IActionResult> TemplateTechniqueByProject(int id)
        {
            IEnumerable<TemplateTechniqueVM> templateTechniqueVMs = await _techniqueApiClient.GetAllTemplateTechnique("api/TemplateTechnique/TemplateTechniqueByProject?id=" + id);
            await Task.Delay(1);
            return View("Index",templateTechniqueVMs);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateTemplateTechnique()
        {
            TemplateTechniqueVM templateTechniqueVM = new TemplateTechniqueVM();
            return View(templateTechniqueVM);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTemplateTechnique(TemplateTechniqueVM templateTechniqueVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateTechniqueVM), Encoding.UTF8, "application/json");
            await this._techniqueApiClient.PostTemplateTechnique("api/TemplateTechnique/Create", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("CreateItem")]
        public async Task<IActionResult> CreateTemplateTechniqueItem()
        {
            await Task.Delay(1);
            TemplateTechniqueItemVM templateTechniqueItemVM = new TemplateTechniqueItemVM();
            return View(templateTechniqueItemVM);
        }


        [HttpPost]
        [Route("CreateItem")]
        public async Task<IActionResult> CreateTemplateTechniqueItem(TemplateTechniqueItemVM templateTechniqueItemVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateTechniqueItemVM), Encoding.UTF8, "application/json");
            await this._techniqueApiClient.PostTemplateTechniqueItem("api/TemplateTechnique/CreateItem", content);
            return RedirectToAction("Index");
        }

        [Route("TemplateTechniqueItems")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> TemplateTechniqueItems(int id)
        {
            IEnumerable<TemplateTechniqueItemVM> templateTechniqueItemVMs =  await _techniqueApiClient.DetailsTemplateTechniqueItems("api/TemplateTechnique/TemplateTechniqueItems?id=" + id);
            await Task.Delay(1);
            return Json(templateTechniqueItemVMs, new JsonSerializerOptions { WriteIndented = true });
        }
        /*
        [Route("TemplateTechniqueItems")]
        public async Task<IActionResult> TemplateTechniqueItems(int id)
        {
            List<TemplateTechniqueItemVM> templateTechniqueItemVMs = await _techniqueApiClient.DetailsTemplateTechniqueItems("api/TemplateTechnique/TemplateTechniqueItems?id=" + id);
            return View(templateTechniqueItemVMs);
        }*/

        [Route("TemplateTechniqueItem")]
        public async Task<IActionResult> TemplateTechniqueItem(int id)
        {
            TemplateTechniqueItemVM templateTechniqueItemVM = await _techniqueApiClient.DetailsTemplateTechniqueItem("api/TemplateTechnique/TemplateTechniqueItemDetail?id=" + id);
            return View(templateTechniqueItemVM);

        }

        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            TemplateTechniqueVM templateTechniqueVM = await _techniqueApiClient.GetTemplateTechnique("api/TemplateTechnique/Details?id=" + id);
            return View(templateTechniqueVM);
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            TemplateTechniqueVM templateTechniqueVM = await _techniqueApiClient.GetTemplateTechnique("api/TemplateTechnique/Details?id=" + id);
            return View(templateTechniqueVM);
        }        

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(TemplateTechniqueVM templateTechniqueVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateTechniqueVM), Encoding.UTF8, "application/json");
            await this._techniqueApiClient.PostTemplateTechnique("api/TemplateTechnique/Edit", content);
            return RedirectToAction("Index");
        }       


        [HttpGet]
        [Route("EditTemplateTechniqueItem")]
        public async Task<IActionResult> EditTemplateTechniqueItem(int id)
        {
            TemplateTechniqueItemVM templateTechniqueVM = await _techniqueApiClient.DetailsTemplateTechniqueItem("api/TemplateTechnique/DetailsItem?id=" + id);
            return View(templateTechniqueVM);
        }

        [HttpPost]
        [Route("EditTemplateTechniqueItem")]
        public async Task<IActionResult> EditTemplateTechniqueItem(TemplateTechniqueItemVM templateTechniqueItemVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateTechniqueItemVM), Encoding.UTF8, "application/json");
            await this._techniqueApiClient.PostTemplateTechniqueItem("api/TemplateTechnique/EditTemplateTechniqueItem", content);
            return RedirectToAction("Index");
        }               

        [Route("Delete")]
        public IActionResult DeleteTemplateTechnique(int id)
        {
            this._techniqueApiClient.DeleteTemplateTechnique("api/TemplateTechnique/Delete?id=" + id);
            return RedirectToAction("Index");
        }
    }
}
