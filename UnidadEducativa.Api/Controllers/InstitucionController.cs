using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnidadEducativa.Api.Responses;
using UnidadEducativa.Core.DTO;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class InstitucionController : ControllerBase
    {
        private readonly IInstitucionService _institucionService;
        private readonly IMapper _mapper;

        public InstitucionController(IInstitucionService institucionService, IMapper mapper)
        {
            _institucionService = institucionService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetInstituciones()
        {
            var instituciones = _institucionService.GetInstituciones();
            var institucionDtos = _mapper.Map<IEnumerable<InstitucionDto>>(instituciones);

            var response = new ApiResponse<IEnumerable<InstitucionDto>>(institucionDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetInstitucion(long Id)
        {
            var institucion = await _institucionService.GetInstitucion(Id);
            var institucionDto = _mapper.Map<InstitucionDto>(institucion);

            var response = new ApiResponse<InstitucionDto>(institucionDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InstitucionDto institucionDto)
        {
            var institucion = _mapper.Map<Institucion>(institucionDto);
            await _institucionService.InsertInstitucion(institucion);

            institucionDto = _mapper.Map<InstitucionDto>(institucion);
            var response = new ApiResponse<InstitucionDto>(institucionDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, InstitucionDto institucionDto)
        {
            var institucion = _mapper.Map<Institucion>(institucionDto);
            institucion.Id = Id;
            var result = await _institucionService.UpdateInstitucion(institucion);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _institucionService.DeleteInstitucion(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
