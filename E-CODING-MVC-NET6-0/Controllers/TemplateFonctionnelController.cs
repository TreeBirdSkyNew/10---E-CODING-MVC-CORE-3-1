using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_CODING_MVC_NET6_0
{   
    [Route("TemplateFonctionnel")]
    public class TemplateFonctionnelController : Controller
    {
        private readonly ITemplateFonctionnelApiClient _itemplateFonctionnelApiClient;

        public TemplateFonctionnelController(ITemplateFonctionnelApiClient itemplateFonctionnelApiClient)
        {
            _itemplateFonctionnelApiClient = itemplateFonctionnelApiClient;
        }
     
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            List<TemplateFonctionnelVM> templateFonctionnelVMs = await _itemplateFonctionnelApiClient.GetAllTemplateFonctionnel("api/TemplateFonctionnel/Index");
            return View(templateFonctionnelVMs);
        }

        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            TemplateFonctionnelVM templateFonctionnelVM = await _itemplateFonctionnelApiClient.GetTemplateFonctionnel("api/TemplateFonctionnel/Details?id=" + id);
            return View(templateFonctionnelVM);
        }

        [Route("TemplateFonctionnelEntities")]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult TemplateFonctionnelEntities(int id)
        {
            List<TemplateFonctionnelEntityVM> templateTechniqueItemVMs = _itemplateFonctionnelApiClient.GetTemplateFonctionnelEntities("api/TemplateFonctionnel/TemplateFonctionnelEntities?id=" + id).Result;
             return Json(templateTechniqueItemVMs, new JsonSerializerOptions { WriteIndented = true });
        }

        [Route("TemplateFonctionnelEntity")]
        public IActionResult TemplateFonctionnelEntity(int id)
        {
            TemplateFonctionnelEntityVM templateFonctionnelEntityVM = _itemplateFonctionnelApiClient.GetTemplateFonctionnelEntity("api/TemplateFonctionnel/TemplateFonctionnelEntity?id=" + id).Result;
            return View(templateFonctionnelEntityVM);
        }


        [Route("TemplateFonctionnelProperties")]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult TemplateFonctionnelProperties(int id)
        {
            List<TemplateFonctionnelPropertyVM> templateTechniqueItemVMs = _itemplateFonctionnelApiClient.GetTemplateFonctionnelProperties("api/TemplateFonctionnel/TemplateFonctionnelProperties?id=" + id).Result;
            return Json(templateTechniqueItemVMs, new JsonSerializerOptions { WriteIndented = true });
        }


        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            TemplateFonctionnelVM templateFonctionnelVM = await _itemplateFonctionnelApiClient.GetTemplateFonctionnel("api/TemplateFonctionnel/Details?id=" + id);
             return View(templateFonctionnelVM);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(TemplateFonctionnelVM templateFonctionnelVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateFonctionnelVM), Encoding.UTF8, "application/json");
            await this._itemplateFonctionnelApiClient.PostTemplateFonctionnel("api/TemplateFonctionnel/Edit", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditTemplateFonctionnelEntity")]
        public async Task<IActionResult> EditTemplateFonctionnelEntity(int id)
        {
            TemplateFonctionnelEntityVM templateFonctionnelEntityVM = await _itemplateFonctionnelApiClient.GetTemplateFonctionnelEntity("api/TemplateFonctionnel/TemplateFonctionnelEntity?id=" + id);
            return View(templateFonctionnelEntityVM);
        }

        [HttpPost]
        [Route("EditTemplateFonctionnelEntity")]
        public async Task<IActionResult> EditTemplateFonctionnelEntity(TemplateFonctionnelEntityVM templateFonctionnelEntityVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateFonctionnelEntityVM), Encoding.UTF8, "application/json");
            await this._itemplateFonctionnelApiClient.PostTemplateFonctionnelEntity("api/TemplateFonctionnel/EditTemplateFonctionnelEntity", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateTemplateFonctionnel()
        {
            TemplateFonctionnelVM templateFonctionnelVM = new TemplateFonctionnelVM();
            return View(templateFonctionnelVM);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTemplateFonctionnel(TemplateFonctionnelVM templateFonctionnelVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateFonctionnelVM), Encoding.UTF8, "application/json");
            await this._itemplateFonctionnelApiClient.PostTemplateFonctionnel("api/TemplateFonctionnel/Create", content);
            return RedirectToAction("Index");
        }

        [Route("Delete")]
        public async Task<IActionResult> DeleteTemplateFonctionnel(int id)
        {
            await this._itemplateFonctionnelApiClient.DeleteTemplateFonctionnel("api/TemplateFonctionnel/Delete?id=" + id);
            return RedirectToAction("Index");
        }

    }
}
