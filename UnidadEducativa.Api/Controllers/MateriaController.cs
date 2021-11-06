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

    public class MateriaController : ControllerBase
    {
        private readonly IMateriaService _materiaService;
        private readonly IMapper _mapper;

        public MateriaController(IMateriaService materiaService, IMapper mapper)
        {
            _materiaService = materiaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMaterias()
        {
            var materias = _materiaService.GetMaterias();
            var materiaDtos = _mapper.Map<IEnumerable<MateriaDto>>(materias);

            var response = new ApiResponse<IEnumerable<MateriaDto>>(materiaDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMateria(long Id)
        {
            var materia = await _materiaService.GetMateria(Id);
            var materiaDto = _mapper.Map<MateriaDto>(materia);

            var response = new ApiResponse<MateriaDto>(materiaDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MateriaDto materiaDto)
        {
            var materia = _mapper.Map<Materia>(materiaDto);
            await _materiaService.InsertMateria(materia);

            materiaDto = _mapper.Map<MateriaDto>(materia);
            var response = new ApiResponse<MateriaDto>(materiaDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, MateriaDto materiaDto)
        {
            var materia = _mapper.Map<Materia>(materiaDto);
            materia.Id = Id;
            var result = await _materiaService.UpdateMateria(materia);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _materiaService.DeleteMateria(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
