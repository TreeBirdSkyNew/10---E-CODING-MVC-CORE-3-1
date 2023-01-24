using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_MVC_NET6_0;
using E_CODING_MVC_NET6_0.Models;
using E_CODING_Service_Abstraction;
using E_CODING_Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace TemplateFonctionnel_WebApi
{
    [ApiController]
    [Route("api/TemplateFonctionnel")]
    public class TemplateFonctionnelController : ControllerBase
    {
        private readonly ITemplateFonctionnelService _itemplateFonctionnelService;
        private readonly ITemplateFonctionnelRepository _templateFonctionnelRepository;
        private IMapper _mapper;
        public TemplateFonctionnelController(IMapper mapper, ITemplateFonctionnelService templateFonctionnelService)
        {
            _mapper = mapper;
            _templateFonctionnelRepository = new TemplateFonctionnelRepository();
            _itemplateFonctionnelService = templateFonctionnelService;
            _itemplateFonctionnelService = new TemplateFonctionnelService(_templateFonctionnelRepository);
        }

        [HttpGet]
        [Route("Index")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<TemplateFonctionnel> templateFonctionnels = await _itemplateFonctionnelService.GetAllTemplateFonctionnel();
                List<TemplateFonctionnelVM> templateFonctionnelsVM = _mapper.Map<List<TemplateFonctionnelVM>>(templateFonctionnels);
                return Ok(templateFonctionnelsVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateProject Index error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("Details")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateProject))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateFonctionnelDetail(int id)
        {            
            try
            {
                TemplateFonctionnel templateFonctionnel = await _itemplateFonctionnelService.DetailTemplateFonctionnel(id);
                TemplateFonctionnelVM templateFonctionnelVM = _mapper.Map<TemplateFonctionnelVM> (templateFonctionnel);
                return Ok(templateFonctionnelVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelDetail error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("TemplateFonctionnelByProject")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemplateFonctionnel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateFonctionnelByProject(int id)
        {
            try
            {
                TemplateFonctionnel templateFonctionnel = await _itemplateFonctionnelService.TemplateFonctionnelByProject(id);
                TemplateFonctionnelVM templateFonctionnelVM = _mapper.Map<TemplateFonctionnelVM>(templateFonctionnel);
                if (templateFonctionnelVM == null)
                    templateFonctionnelVM = new TemplateFonctionnelVM();
                return Ok(templateFonctionnelVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelDetail error: " + ex.Message);
            }
        }

        


        [HttpGet]
        [Route("DetailsEntities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateFonctionnelDetailsEntities(int id)
        {
            try
            {
                List<TemplateFonctionnelEntity> templateFonctionnelEntities = await _itemplateFonctionnelService.DetailTemplateFonctionnelEntities(id);
                List<TemplateFonctionnelEntityVM> templateFonctionnelEntitiesVM = _mapper.Map<List<TemplateFonctionnelEntityVM>>(templateFonctionnelEntities);
                return Ok(templateFonctionnelEntitiesVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelDetailsEntities Index error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("TemplateFonctionnelEntities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> TemplateFonctionnelEntities(int id)
        {            
            try
            {
               List<TemplateFonctionnelEntity> templateFonctionnelEntities = await _itemplateFonctionnelService.DetailTemplateFonctionnelEntities(id);
               List<TemplateFonctionnelEntityVM> templateFonctionnelEntitiesVM = _mapper.Map<List<TemplateFonctionnelEntityVM>>(templateFonctionnelEntities);
               return Ok(templateFonctionnelEntitiesVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelEntities Index error: " + ex.Message);
            }
        }

        

        [HttpGet]
        [Route("TemplateFonctionnelEntity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateFonctionnelEntity(int id)
        {            
            try
            {
                TemplateFonctionnelEntity templateFonctionnelEntity = await _itemplateFonctionnelService.DetailTemplateFonctionnelEntity(id);
                TemplateFonctionnelEntityVM templateFonctionnelEntityVM = _mapper.Map<TemplateFonctionnelEntityVM>(templateFonctionnelEntity);
                return Ok(templateFonctionnelEntityVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelEntity Index error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("DetailsProperties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateFonctionnelDetailsProperties(int id)
        {            
            try
            {
                List<TemplateFonctionnelProperty> templateFonctionnelProperties = await _itemplateFonctionnelService.DetailTemplateFonctionnelProperties(id);
                List<TemplateFonctionnelPropertyVM> templateFonctionnelPropertiesVM = _mapper.Map<List<TemplateFonctionnelPropertyVM>>(templateFonctionnelProperties);
                return Ok(templateFonctionnelPropertiesVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelDetailsProperties Index error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("TemplateFonctionnelProperties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> TemplateFonctionnelProperties(int id)
        {
            try
            {
                List<TemplateFonctionnelProperty> templateFonctionnelProperties = await _itemplateFonctionnelService.DetailTemplateFonctionnelProperties(id);
                List<TemplateFonctionnelPropertyVM> templateFonctionnelPropertiesVM = _mapper.Map<List<TemplateFonctionnelPropertyVM>>(templateFonctionnelProperties);
                return Ok(templateFonctionnelPropertiesVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelProperties Index error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("TemplateFonctionnelProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateFonctionnelProperty(int id)
        {            
            try
            {
                TemplateFonctionnelProperty templateFonctionnelProperties = await _itemplateFonctionnelService.DetailTemplateFonctionnelProperty(id);
                TemplateFonctionnelPropertyVM templateFonctionnelPropertiesVM = _mapper.Map<TemplateFonctionnelPropertyVM>(templateFonctionnelProperties);
                return Ok(templateFonctionnelPropertiesVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelProperty Index error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> TemplateFonctionnelCreate()
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateFonctionnel templateFonctionnel = await _itemplateFonctionnelService.CreateTemplateFonctionnel();
                    TemplateFonctionnelVM templateFonctionnelVM = _mapper.Map<TemplateFonctionnelVM>(templateFonctionnel);
                    //return Ok(templateFonctionnelVM);
                    return CreatedAtAction("Get", new { id = templateFonctionnelVM.TemplateFonctionnelId }, templateFonctionnelVM);
                }
                else return BadRequest("TemplateFonctionnelCreate IsValid=false");
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelCreate error: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateFonctionnelCreate([FromBody] TemplateFonctionnelVM templateFonctionnelVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateFonctionnel _templateFonctionnel = _mapper.Map<TemplateFonctionnel>(templateFonctionnelVM);
                    TemplateFonctionnel templateFonctionnel = await _itemplateFonctionnelService.CreateTemplateFonctionnel(_templateFonctionnel);
                    TemplateFonctionnelVM _templateFonctionnelVM = _mapper.Map<TemplateFonctionnelVM>(templateFonctionnel);
                    return CreatedAtAction("Get", new { id = templateFonctionnelVM.TemplateFonctionnelId }, templateFonctionnelVM);
                    //return Ok(_templateFonctionnelVM);
                }
                else return BadRequest("TemplateFonctionnelCreate IsValid=false");
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelCreate error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("CreateFonctionnelEntity")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateFonctionnelEntityCreate()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateFonctionnelEntity templateFonctionnelEntity = await _itemplateFonctionnelService.CreateTemplateFonctionnelEntity();
                    TemplateFonctionnelEntityVM templateFonctionnelEntityVM = _mapper.Map<TemplateFonctionnelEntityVM>(templateFonctionnelEntity);
                    //return Ok(templateFonctionnelEntityVM);
                    return CreatedAtAction("Get", new { id = templateFonctionnelEntityVM.TemplateFonctionnelEntityId }, templateFonctionnelEntityVM);
                }
                else return BadRequest("TemplateFonctionnelEntityCreate IsValid=false");
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelEntityCreate error: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateFonctionnelEntity")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateFonctionnelEntityCreate([FromBody] TemplateFonctionnelEntity templateFonctionnelEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateFonctionnelEntity _templateFonctionnelEntity = await _itemplateFonctionnelService.CreateTemplateFonctionnelEntity(templateFonctionnelEntity);
                    TemplateFonctionnelEntityVM templateFonctionnelEntityVM = _mapper.Map<TemplateFonctionnelEntityVM>(_templateFonctionnelEntity);
                    //return Ok(templateFonctionnelEntityVM);
                    return CreatedAtAction("Get", new { id = templateFonctionnelEntityVM.TemplateFonctionnelEntityId }, templateFonctionnelEntityVM);

                }
                else return BadRequest("TemplateFonctionnelEntityCreate IsValid=false");
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelEntityCreate error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("CreateFonctionnelProperty")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateFonctionnelPropertyCreate()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateFonctionnelProperty templateFonctionnelProperty = await _itemplateFonctionnelService.CreateTemplateFonctionnelProperty();
                    TemplateFonctionnelPropertyVM templateFonctionnelPropertyVM = _mapper.Map<TemplateFonctionnelPropertyVM>(templateFonctionnelProperty);
                    return CreatedAtAction("Get", new { id = templateFonctionnelPropertyVM.TemplateFonctionnelPropertyId }, templateFonctionnelPropertyVM);
                    //return Ok(templateFonctionnelPropertyVM);
                }
                else return BadRequest("TemplateFonctionnelPropertyCreate IsValid=false");
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelPropertyCreate error: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateFonctionnelProperty")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateFonctionnelPropertyCreate([FromBody] TemplateFonctionnelProperty templateFonctionnelProperty)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateFonctionnelProperty _templateFonctionnelProperty = await _itemplateFonctionnelService.CreateTemplateFonctionnelProperty(templateFonctionnelProperty);
                    TemplateFonctionnelPropertyVM templateFonctionnelPropertyVM = _mapper.Map<TemplateFonctionnelPropertyVM>(templateFonctionnelProperty);
                    //return Ok(templateFonctionnelPropertyVM);
                    return CreatedAtAction("Get", new { id = templateFonctionnelPropertyVM.TemplateFonctionnelPropertyId }, templateFonctionnelPropertyVM);
                }
                else return BadRequest("TemplateFonctionnelPropertyCreate IsValid=false");
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateFonctionnelPropertyCreate error: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("Edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditTemplateFonctionnel([FromBody] TemplateFonctionnel templateFonctionnel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   TemplateFonctionnel _templateFonctionnel = await this._itemplateFonctionnelService.EditTemplateFonctionnel(templateFonctionnel);
                   TemplateFonctionnelVM templateFonctionnelVM = _mapper.Map<TemplateFonctionnelVM>(_templateFonctionnel);
                   //return Ok(templateFonctionnelVM);
                   return CreatedAtAction("Get", new { id = templateFonctionnelVM.TemplateFonctionnelId }, templateFonctionnelVM);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("EditTemplateFonctionnelEntity error: " + ex.Message);
            }
            return BadRequest("EditTemplateFonctionnelEntity error: ");
        }

        [HttpPost]
        [Route("EditTemplateFonctionnelEntity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditTemplateFonctionnelEntity([FromBody] TemplateFonctionnelEntity templateFonctionnelEntity)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    TemplateFonctionnelEntity _templateFonctionnelEntity = await this._itemplateFonctionnelService.EditTemplateFonctionnelEntity(templateFonctionnelEntity);
                    TemplateFonctionnelEntityVM templateFonctionnelEntityVM = _mapper.Map<TemplateFonctionnelEntityVM>(_templateFonctionnelEntity);
                    //return Ok(templateFonctionnelEntityVM);
                    return CreatedAtAction("Get", new { id = templateFonctionnelEntityVM.TemplateFonctionnelEntityId }, templateFonctionnelEntityVM);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("EditTemplateFonctionnelEntity error: " + ex.Message);
            }
            return BadRequest("EditTemplateFonctionnelEntity error: ");
        }

        [Route("Delete")]
        public void TemplateFonctionnelDelete(int id)
        {
            this._itemplateFonctionnelService.DeleteTemplateFonctionnel(id);
        }

        
        
    }
}
