using _4___E_CODING_DAL.Models;
using AutoMapper;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Service_Abstraction;
using E_CODING_Services.Project;
using E_CODING_Services.Solution;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace TemplateSolution_WebApi.Controllers
{
    [Route("api/TemplateSolution")]
    public class TemplateSolutionController : ControllerBase
    {
        private readonly ISolutionRepositoryWrapper _solutionRepositoryWrapper;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public TemplateSolutionController(
            ISolutionRepositoryWrapper solutionRepositoryWrapper,
            IMapper mapper,
            ILoggerManager logger)
        {
            _solutionRepositoryWrapper = solutionRepositoryWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("Index")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Index()
        {
            try
            {
                IEnumerable<TemplateSolution> templateProjects = _solutionRepositoryWrapper.SolutionRepository.GetAllTemplateSolution();
                _logger.LogInfo($"Returned all templateProjects from database.");
                List<TemplateSolutionVM> templateProjectsVM = _mapper.Map<List<TemplateSolutionVM>>(templateProjects.ToList());
                return Ok(templateProjectsVM);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateProject/Index action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("SolutionDetails/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateSolution))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult TemplateSolutionDetails(int id)
        {
            try
            {
                TemplateSolution templateSolution = _solutionRepositoryWrapper.SolutionRepository.GetTemplateSolution(id);
                if (templateSolution is null)
                {
                    _logger.LogError($"Returned TemplateProjectDetails TemplateSolution={id} from database.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned TemplateSolutionDetails TemplateSolution: {id}");
                    TemplateSolutionVM templateSolutionVM = _mapper.Map<TemplateSolutionVM>(templateSolution);
                    return Ok(templateSolutionVM);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateSolutionDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [Route("SolutionChilds/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateSolution))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SolutionChilds(int id)
        {
            try
            {
                List<TemplateSolution> templateSolution = _solutionRepositoryWrapper.SolutionRepository.GetAllTemplateSolution(id);
                if (templateSolution is null)
                {
                    _logger.LogError($"Returned TemplateProjectDetails TemplateSolution={id} from database.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned TemplateSolutionDetails TemplateSolution: {id}");
                    List<TemplateSolutionVM> templateSolutionVM = _mapper.Map<List<TemplateSolutionVM>>(templateSolution);
                    return Ok(templateSolutionVM);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateSolutionDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("ProjectBySolution/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateSolution))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ProjectBySolution(int id)
        {
            try
            {
                List<TemplateProject> templateSolution = _solutionRepositoryWrapper.SolutionRepository.GetAllTemplateProject(id);
                if (templateSolution is null)
                {
                    _logger.LogError($"Returned TemplateProjectDetails TemplateSolution={id} from database.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned TemplateSolutionDetails TemplateSolution: {id}");
                    List<TemplateProjectVM> templateSolutionVM = _mapper.Map<List<TemplateProjectVM>>(templateSolution);
                    return Ok(templateSolutionVM);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateSolutionDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }




        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Create")]
        public IActionResult TemplateSolutionCreate([FromBody] TemplateSolutionVMForCreation templateSolutionVM)
        {
            try
            {
                if (templateSolutionVM is null)
                {
                    _logger.LogError("templateTechnique object sent from client is null.");
                    return BadRequest("templateTechnique object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid templateTechnique object sent from client.");
                    return BadRequest("Invalid model object");
                }
                TemplateSolution TemplateSolutionEntity = _mapper.Map<TemplateSolution>(templateSolutionVM);
                _solutionRepositoryWrapper.SolutionRepository.CreateTemplateSolution(TemplateSolutionEntity);
                _solutionRepositoryWrapper.Save();
                var templateSolution = _mapper.Map<TemplateSolutionVM>(TemplateSolutionEntity);
                return CreatedAtRoute("TemplateSolutionById", new { id = templateSolution.TemplateSolutionId }, templateSolution);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateSolutionCreate action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")]
        [Route("Edit")]
        public IActionResult TemplateSolutionEdit(int id, [FromBody] TemplateSolutionVM templateSolutionVM)
        {
            try
            {
                if (templateSolutionVM is null)
                {
                    _logger.LogError("TemplateResult object sent from client is null.");
                    return BadRequest("TemplateResult object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid TemplateResult object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var templateSolutionEntity = _mapper.Map<TemplateSolution>(templateSolutionVM);
                _solutionRepositoryWrapper.SolutionRepository.UpdateTemplateSolution(templateSolutionEntity);
                _solutionRepositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TemplateSolution action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        
    }
}