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

    public class EstudianteCursoController : ControllerBase
    {
        private readonly IEstudianteCursoService _estudianteCursoService;
        private readonly IMapper _mapper;
        private readonly colegioContext _colegioContext;

        public EstudianteCursoController(IEstudianteCursoService estudianteCursoService, IMapper mapper, colegioContext colegioContext)
        {
            _estudianteCursoService = estudianteCursoService;
            _mapper = mapper;
            _colegioContext = colegioContext;
        }

        [HttpGet]
        public IActionResult GetEstudianteCursos()
        {
            var estudianteCursos = _estudianteCursoService.GetEstudianteCursos();
            var estudianteCursoDtos = _mapper.Map<IEnumerable<EstudianteCursoDto>>(estudianteCursos);

            var response = new ApiResponse<IEnumerable<EstudianteCursoDto>>(estudianteCursoDtos);
            return Ok(response);
        }

        /*[HttpGet("{Id}")]
        public async Task<IActionResult> GetEstudianteCurso(long Id)
        {
            var estudianteCurso = await _estudianteCursoService.GetEstudianteCurso(Id);
            var EstudianteCursoDto = _mapper.Map<EstudianteCursoDto>(estudianteCurso);

            var response = new ApiResponse<EstudianteCursoDto>(EstudianteCursoDto);
            return Ok(response);
        }
        */
        [HttpPost]
        public async Task<IActionResult> Post(EstudianteCursoDto EstudianteCursoDto)
        {
            var estudianteCurso = _mapper.Map<EstudianteCurso>(EstudianteCursoDto);
            await _estudianteCursoService.InsertEstudianteCurso(estudianteCurso);

            EstudianteCursoDto = _mapper.Map<EstudianteCursoDto>(estudianteCurso);
            var response = new ApiResponse<EstudianteCursoDto>(EstudianteCursoDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, EstudianteCursoDto EstudianteCursoDto)
        {
            var estudianteCurso = _mapper.Map<EstudianteCurso>(EstudianteCursoDto);
            estudianteCurso.Id = Id;
            var result = await _estudianteCursoService.UpdateEstudianteCurso(estudianteCurso);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _estudianteCursoService.DeleteEstudianteCurso(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        //Para listar
        [HttpGet("{encontrado}/{ide}")]
        public IActionResult GetIdCurso(long encontrado, long ide)
        {

            IEnumerable<EstudianteCurso> listaEstudianteCursos = null;
            var estudianteCursos = _estudianteCursoService.GetEstudianteCursos();

            listaEstudianteCursos = estudianteCursos.Where(ele => ele.IdCurso.Equals(encontrado));

            var estudianteCursoDtos = _mapper.Map<IEnumerable<EstudianteCursoDto>>(listaEstudianteCursos);

            var response = new ApiResponse<IEnumerable<EstudianteCursoDto>>(estudianteCursoDtos);
            return Ok(response);
        }
        //Para capturar IdEvalPoseedor de Nota
        [HttpGet("{estudianteId}")]
        public ActionResult<EstudianteCursoDto> GetEstudiante(long estudianteId)
        {
            var estudiante = _colegioContext.EstudianteCurso.FirstOrDefault(ele => ele.IdEstudiante == estudianteId);
            if (estudiante == null)
            {
                return NotFound();
            }
            var estudianteDto = _mapper.Map<EstudianteCursoDto>(estudiante);

            return estudianteDto;
        }


    }
}
