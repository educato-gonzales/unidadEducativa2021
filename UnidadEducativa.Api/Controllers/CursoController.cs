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

    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;
        private readonly IMapper _mapper;

        public CursoController(ICursoService cursoService, IMapper mapper)
        {
            _cursoService = cursoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCursos()
        {
            var cursos = _cursoService.GetCursos();
            var cursoDtos = _mapper.Map<IEnumerable<CursoDto>>(cursos);

            var response = new ApiResponse<IEnumerable<CursoDto>>(cursoDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCurso(long Id)
        {
            var curso = await _cursoService.GetCurso(Id);
            var cursoDto = _mapper.Map<CursoDto>(curso);

            var response = new ApiResponse<CursoDto>(cursoDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CursoDto cursoDto)
        {
            var curso = _mapper.Map<Curso>(cursoDto);
            await _cursoService.InsertCurso(curso);

            cursoDto = _mapper.Map<CursoDto>(curso);
            var response = new ApiResponse<CursoDto>(cursoDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, CursoDto cursoDto)
        {
            var curso = _mapper.Map<Curso>(cursoDto);
            curso.Id = Id;
            var result = await _cursoService.UpdateCurso(curso);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _cursoService.DeleteCurso(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
