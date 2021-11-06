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

    public class EvaluacionProfesorController : ControllerBase
    {
        private readonly IEvaluacionProfesorService _evaluacionProfesorService;
        private readonly IMapper _mapper;
        private readonly colegioContext _colegioContext;

        public EvaluacionProfesorController(IEvaluacionProfesorService evaluacionProfesorService, IMapper mapper, colegioContext colegioContext)
        {
            _evaluacionProfesorService = evaluacionProfesorService;
            _mapper = mapper;
            _colegioContext = colegioContext;
        }

        [HttpGet]
        public IActionResult GetEvaluacionProfesores()
        {
            var evaluacionProfesores = _evaluacionProfesorService.GetEvaluacionProfesores();
            var evaluacionProfesorDtos = _mapper.Map<IEnumerable<EvaluacionProfesorDto>>(evaluacionProfesores);

            var response = new ApiResponse<IEnumerable<EvaluacionProfesorDto>>(evaluacionProfesorDtos);
            return Ok(response);
        }

       /* [HttpGet("{Id}")]
        public async Task<IActionResult> GetEvaluacionProfesor(long Id)
        {
            var evaluacionProfesor = await _evaluacionProfesorService.GetEvaluacionProfesor(Id);
            var evaluacionProfesorDto = _mapper.Map<EvaluacionProfesorDto>(evaluacionProfesor);

            var response = new ApiResponse<EvaluacionProfesorDto>(evaluacionProfesorDto);
            return Ok(response);
        }*/

        [HttpPost]
        public async Task<IActionResult> Post(EvaluacionProfesorDto evaluacionProfesorDto)
        {
            var evaluacionProfesor = _mapper.Map<EvaluacionProfesor>(evaluacionProfesorDto);
            await _evaluacionProfesorService.InsertEvaluacionProfesor(evaluacionProfesor);

            evaluacionProfesorDto = _mapper.Map<EvaluacionProfesorDto>(evaluacionProfesor);
            var response = new ApiResponse<EvaluacionProfesorDto>(evaluacionProfesorDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, EvaluacionProfesorDto evaluacionProfesorDto)
        {
            var evaluacionProfesor = _mapper.Map<EvaluacionProfesor>(evaluacionProfesorDto);
            evaluacionProfesor.Id = Id;
            var result = await _evaluacionProfesorService.UpdateEvaluacionProfesor(evaluacionProfesor);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _evaluacionProfesorService.DeleteEvaluacionProfesor(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        //Para capturar IdEvalPoseedor de Nota
        [HttpGet("{notaId}")]
        public ActionResult<EvaluacionProfesorDto> GetNota(long notaId)
        {
            var nota = _colegioContext.EvaluacionProfesor.FirstOrDefault(ele => ele.IdEvalPoseedor == notaId);
            if (nota == null)
            {
                return NotFound();
            }
            var notaDto = _mapper.Map<EvaluacionProfesorDto>(nota);

            return notaDto;
        }


    }
}
