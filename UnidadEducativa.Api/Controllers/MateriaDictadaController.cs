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
using UnidadEducativa.Infrastructure.Data;

namespace UnidadEducativa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MateriaDictadaController : ControllerBase
    {
        private readonly IMateriaDictadaService _materiaDictadaService;
        private readonly IMapper _mapper;
        private readonly colegioContext _colegioContext;

        public MateriaDictadaController(IMateriaDictadaService materiaDictadaService, IMapper mapper, colegioContext colegioContext)
        {
            _materiaDictadaService = materiaDictadaService;
            _mapper = mapper;
            _colegioContext = colegioContext;
        }

        [HttpGet]
        public IActionResult GetMateriaDictadas()
        {
            var materiaDictadas = _materiaDictadaService.GetMateriaDictadas();
            var materiaDictadaDtos = _mapper.Map<IEnumerable<MateriaDictadaDto>>(materiaDictadas);

            var response = new ApiResponse<IEnumerable<MateriaDictadaDto>>(materiaDictadaDtos);
            return Ok(response);
        }

        /*[HttpGet("{Id}")]
        public async Task<IActionResult> GetAutoevaluacion(long Id)
        {
            var materiaDictada = await _materiaDictadaService.GetMateriaDictada(Id);
            var MateriaDictadaDto = _mapper.Map<MateriaDictadaDto>(materiaDictada);

            var response = new ApiResponse<MateriaDictadaDto>(MateriaDictadaDto);
            return Ok(response);
        }*/

        [HttpPost]
        public async Task<IActionResult> Post(MateriaDictadaDto MateriaDictadaDto)
        {
            var materiaDictada = _mapper.Map<MateriaDictada>(MateriaDictadaDto);
            await _materiaDictadaService.InsertMateriaDictada(materiaDictada);

            MateriaDictadaDto = _mapper.Map<MateriaDictadaDto>(materiaDictada);
            var response = new ApiResponse<MateriaDictadaDto>(MateriaDictadaDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, MateriaDictadaDto MateriaDictadaDto)
        {
            var materiaDictada = _mapper.Map<MateriaDictada>(MateriaDictadaDto);
            materiaDictada.Id = Id;
            var result = await _materiaDictadaService.UpdateMateriaDictada(materiaDictada);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _materiaDictadaService.DeleteMateriaDictada(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        //Para capturar IdEvalPoseedor de Curso ID
        [HttpGet("{cursoId}")]
        public ActionResult<MateriaDictadaDto> GetCurso(long cursoId)
        {
            var curso = _colegioContext.MateriaDictada.FirstOrDefault(ele => ele.IdCurso == cursoId);
            if (curso == null)
            {
                return NotFound();
            }
            var cursoDto = _mapper.Map<MateriaDictadaDto>(curso);

            return cursoDto;
        }
        //Para listar
        [HttpGet("{encontrado}/{ide}")]
        public IActionResult GetIdProfesor(long encontrado, long ide)
        {

            IEnumerable<MateriaDictada> listaProfesores = null;
            var materiaDictadas = _materiaDictadaService.GetMateriaDictadas();

            listaProfesores = materiaDictadas.Where(ele => ele.IdProfesor.Equals(encontrado));

            var profesorDtos = _mapper.Map<IEnumerable<MateriaDictadaDto>>(listaProfesores);

            var response = new ApiResponse<IEnumerable<MateriaDictadaDto>>(profesorDtos);
            return Ok(response);
        }

    }
}
