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
using E_CODING_MVC_NET6_0.InfraStructure.Solution;
using E_CODING_MVC_NET6_0.InfraStructure.Project;

namespace E_CODING_MVC_NET6_0.Controllers
{
    [Route("TemplateSolution")]
    public class TemplateSolutionController : Controller
    {
        private ITemplateProjectApiClient _projectApiClient;
        private ITemplateSolutionApiClient _solutionApiClient;
        
        private const string _clientProjectName = "ClientApiProject";
        private const string _clientSolutionName = "ClientApiSolution";

        public TemplateSolutionController(
                        ITemplateProjectApiClient projectApiClient,
                        ITemplateSolutionApiClient solutionApiClient)
        {
            _projectApiClient = projectApiClient;
            _solutionApiClient = solutionApiClient;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            List<TemplateSolutionVM?> templateProjectVMs = await _solutionApiClient.GetAllTemplateSolution(_clientSolutionName, "api/TemplateSolution/Index");
            return View(templateProjectVMs);
        }

    }
}
