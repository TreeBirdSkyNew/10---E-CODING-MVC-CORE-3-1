using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using Microsoft.AspNetCore.Mvc;
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
    [Route("TemplateResult")]
    public class TemplateResultController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITemplateResultApiClient _itemplateResultApiClient;

        public TemplateResultController(IMapper mapper,
                                         ITemplateResultApiClient itemplateResultApiClient)
        {
            _mapper = mapper;
            _itemplateResultApiClient = itemplateResultApiClient;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            List<TemplateResultVM> templateResults = await _itemplateResultApiClient.GetAllTemplateResult("api/TemplateResult/Index");
            return View(templateResults);
        }

        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            TemplateResultVM templateResultVM = await _itemplateResultApiClient.GetTemplateResult("api/TemplateResult/Details?id=" + id);
            return View(templateResultVM);
        }

        [Route("TemplateResultItems")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> TemplateResultItems(int id)
        {
            List<TemplateResulItemVM> TemplateResultItemVMs = await _itemplateResultApiClient.GetTemplateResultItems("api/TemplateResult/TemplateResultItems?id=" + id);
            return Json(TemplateResultItemVMs, new JsonSerializerOptions { WriteIndented = true });
        }

        [Route("TemplateResultItem")]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult TemplateResultItem(int id)
        {
            TemplateResulItemVM TemplateResultItemVMs = _itemplateResultApiClient.GetTemplateResultItem("api/TemplateResult/TemplateResultItem?id=" + id).Result;
            return View(TemplateResultItemVMs);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateTemplateResult()
        {
            TemplateResultVM templateResultVM = new TemplateResultVM();
            return View(templateResultVM);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTemplateResult(TemplateResultVM templateResultVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateResultVM), Encoding.UTF8, "application/json");
            await this._itemplateResultApiClient.PostTemplateResult("api/TemplateResult/Create", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            TemplateResultVM templateResultVM = await _itemplateResultApiClient.GetTemplateResult("api/TemplateResult/Details?id=" + id);
            return View(templateResultVM);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(TemplateResultVM templateResultVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateResultVM), Encoding.UTF8, "application/json");
            await this._itemplateResultApiClient.PostTemplateResult("api/TemplateResult/EditItem?id="+ templateResultVM.TemplateResultId, content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("CreateTemplateResultItem")]
        public TemplateResulItemVM CreateTemplateResultItem()
        {
            TemplateResulItemVM templateResultItemVM = new TemplateResulItemVM();
            return templateResultItemVM;
        }

        [HttpPost]
        [Route("CreateTemplateResultItem")]
        public async Task<IActionResult> CreateTemplateResultItem(TemplateResulItemVM templateResulItemVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateResulItemVM), Encoding.UTF8, "application/json");
            await this._itemplateResultApiClient.PostTemplateResultItem("api/TemplateResult/CreateTemplateResultItem", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditTemplateResultItem")]
        public IActionResult EditTemplateResultItem(int id)
        {
            TemplateResulItemVM templateResulItemVM = _itemplateResultApiClient.GetTemplateResultItem("api/TemplateResult/TemplateResultItem?id=" + id).Result;
            return View(templateResulItemVM);
        }

        [HttpPost]
        [Route("EditTemplateResultItem")]
        public async Task<IActionResult> EditTemplateResultItem(TemplateResulItemVM templateResultItemVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateResultItemVM), Encoding.UTF8, "application/json");
            await this._itemplateResultApiClient.PostTemplateResultItem("api/TemplateResult/EditTemplateResultItem", content);
            return RedirectToAction("Index");
        }

        [Route("Delete")]
        public async Task<IActionResult> DeleteTemplateResult(int id)
        {
            await this._itemplateResultApiClient.DeleteTemplateResult("api/TemplateResult/Delete?id=" + id);
            return RedirectToAction("Index");
        }


    }
}
