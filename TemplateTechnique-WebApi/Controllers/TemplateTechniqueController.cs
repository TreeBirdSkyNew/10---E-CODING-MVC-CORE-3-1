﻿using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_MVC_NET6_0;
using E_CODING_MVC_NET6_0.Models;
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

namespace TemplateTechnique_WebApi
{
    [Route("api/TemplateTechnique")]
    [ApiController]
    public class TemplateTechniqueController : ControllerBase
    {
        private readonly ITemplateTechniqueService _ServiceTechnique;
        private IMapper _mapper;
        public TemplateTechniqueController(IMapper mapper , ITemplateTechniqueService itemplateTechniqueService)
        {
            _mapper = mapper;
            _ServiceTechnique = itemplateTechniqueService;
        }

        [HttpGet]
        [Route("Index")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Index()
        {   
            try
            {
                List<TemplateTechnique> templateTechniques = await _ServiceTechnique.GetAllTemplateTechnique();
                List<TemplateTechniqueVM> templateTechniquesVM = _mapper.Map<List<TemplateTechniqueVM>>(templateTechniques);
                return Ok(templateTechniquesVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateTechnique Index error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("TemplateTechniqueByProject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TemplateTechniqueByProject(int id)
        {
            try
            {
                List<TemplateTechnique> templateTechniques = await _ServiceTechnique.TemplateTechniqueByProject(id);
                List<TemplateTechniqueVM> templateTechniquesVM = _mapper.Map<List<TemplateTechniqueVM>>(templateTechniques);
                return Ok(templateTechniquesVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateTechnique Index error: " + ex.Message);
            }
        }
        


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("TemplateTechniqueItems")]
        public async Task<IActionResult> TemplateTechniqueItems(int id)
        {            
            try
            {
                List<TemplateTechniqueItem> TemplateTechniqueAllItems = await _ServiceTechnique.DetailTemplateTechniqueItems(id);
                List<TemplateTechniqueItemVM> TemplateTechniqueAllItemsVM = _mapper.Map<List<TemplateTechniqueItemVM>>(TemplateTechniqueAllItems);
                return Ok(TemplateTechniqueAllItemsVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateTechnique Index error: " + ex.Message);
            }
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ActionName("TemplateTechniqueDetail")]
        [Route("Details")]
        public async Task<IActionResult> TemplateTechniqueDetail(int id)
        {
            try
            {
                TemplateTechnique templateTechnique = await _ServiceTechnique.DetailTemplateTechnique(id);
                TemplateTechniqueVM templateTechniqueVM = _mapper.Map<TemplateTechniqueVM>(templateTechnique);
                List<TemplateTechniqueItem> templateTechniqueItems = templateTechnique.TemplateTechniqueItem.ToList();                
                List<TemplateTechniqueItemVM> templateTechniqueItemsVM = _mapper.Map<List<TemplateTechniqueItemVM>>(templateTechniqueItems);
                templateTechniqueVM.TemplateTechniqueItemVM = templateTechniqueItemsVM;
                return Ok(templateTechniqueVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateTechnique Detail error: " + ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("TemplateTechniqueItemDetail")]
        public async Task<IActionResult> TemplateTechniqueItemDetail(int id)
        {
            try
            {
                TemplateTechniqueItem templateTechniqueItem = await _ServiceTechnique.DetailTemplateTechniqueItem(id);
                TemplateTechniqueItemVM templateTechniqueVM = _mapper.Map<TemplateTechniqueItemVM>(templateTechniqueItem);
                return Ok(templateTechniqueVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateTechniqueItem Detail error: " + ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TemplateTechniqueCreate()
        {            
            try
            {
                TemplateTechnique templateTechnique = await _ServiceTechnique.CreateTemplateTechnique();
                TemplateTechniqueVM templateTechniqueVM = _mapper.Map<TemplateTechniqueVM>(templateTechnique);
                return CreatedAtAction("templateTechniqueVM", new { id = templateTechniqueVM.TemplateTechniqueId }, templateTechniqueVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateTechniqueCreate error: " + ex.Message);
            }
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TemplateTechniqueCreate(TemplateTechnique templateTechnique)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateTechnique _templateTechnique = await _ServiceTechnique.CreateTemplateTechnique(templateTechnique);
                    TemplateTechniqueVM templateTechniqueVM = _mapper.Map<TemplateTechniqueVM>(templateTechnique);
                    return CreatedAtAction("templateTechniqueVM", new { id = templateTechniqueVM.TemplateTechniqueId }, templateTechniqueVM);
                }
                else return BadRequest("TemplateTechniqueCreate ModelState.IsValid=false");
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateTechniqueCreate error: " + ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ValidateAntiForgeryToken]
        [Route("Edit")]
        public async Task<IActionResult> TemplateTechniqueEdit(int id)
        {
            try
            {
                TemplateTechnique templateTechnique = await this._ServiceTechnique.EditTemplateTechnique(id);
                TemplateTechniqueVM templateTechniqueVM = _mapper.Map<TemplateTechniqueVM>(templateTechnique);
                return Ok(templateTechniqueVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateTechniqueEdit error: " + ex.Message);
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TemplateTechniqueEdit(TemplateTechnique templateTechnique)
        {            
            try
            {
                if(ModelState.IsValid)
                {
                    TemplateTechnique _templateTechnique =  await this._ServiceTechnique.EditTemplateTechnique(templateTechnique);
                    return NoContent();
                }
                else return BadRequest("TemplateTechniqueEdit ModelState.IsValid=false");
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateTechniqueEdit error: " + ex.Message);
            }

        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTemplateTechniqueItem()
        {
            try
            {
                TemplateTechniqueItem templateTechniqueItem = await _ServiceTechnique.CreateTemplateTechniqueItem();
                TemplateTechniqueItemVM templateTechniqueItemVM = _mapper.Map<TemplateTechniqueItemVM>(templateTechniqueItem);
                return Ok(templateTechniqueItemVM);
            }
            catch (Exception ex)
            {
                return BadRequest("TemplateTechniqueCreate error: " + ex.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CreateItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTemplateTechniqueItem([FromBody] TemplateTechniqueItem templateTechniqueItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateTechniqueItem _templateTechniqueItem = await _ServiceTechnique.CreateTemplateTechniqueItem(templateTechniqueItem);
                    TemplateTechniqueItemVM _templateTechniqueItemVM = _mapper.Map<TemplateTechniqueItemVM>(_templateTechniqueItem);
                    return CreatedAtAction("_templateTechniqueItem", new { id = _templateTechniqueItemVM.TemplateTechniqueItemId }, _templateTechniqueItemVM);

                }
                else return BadRequest("CreateTemplateTechniqueItem IsValid=false");
            }
            catch (Exception ex)
            {
                return BadRequest("CreateTemplateTechniqueItem error: " + ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("EditTemplateTechniqueItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTemplateTechniqueItem(int id)
        {            
            try
            {
                TemplateTechniqueItem _templateTechniqueItem = await this._ServiceTechnique.EditTemplateTechniqueItem(id);
                TemplateTechniqueItemVM _templateTechniqueItemVM = _mapper.Map<TemplateTechniqueItemVM>(_templateTechniqueItem);
                return Ok(_templateTechniqueItemVM);
            }
            catch (Exception ex)
            {
                return BadRequest("EditTemplateTechniqueItem error: " + ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("EditTemplateTechniqueItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTemplateTechniqueItem([FromBody] TemplateTechniqueItem templateTechniqueItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateTechniqueItem _templateTechniqueItem = await _ServiceTechnique.EditTemplateTechniqueItem(templateTechniqueItem);
                    TemplateTechniqueItemVM _templateTechniqueItemVM = _mapper.Map<TemplateTechniqueItemVM>(_templateTechniqueItem);
                    return Ok(_templateTechniqueItemVM);
                }
                else return BadRequest("EditTemplateTechniqueItem IsValid=false");
            }
            catch (Exception ex)
            {
                return BadRequest("EditTemplateTechniqueItem error: " + ex.Message);
            }
        }

        [Route("Delete")]
        public void DeleteTemplateTechnique(int id)
        {
            this._ServiceTechnique.DeleteTemplateTechnique(id);
        }

        [Route("DeleteItem")]
        public void DeleteTemplateTechniqueItem(int id)
        {
            this._ServiceTechnique.DeleteTemplateTechniqueItem(id);
        }
    }
}
