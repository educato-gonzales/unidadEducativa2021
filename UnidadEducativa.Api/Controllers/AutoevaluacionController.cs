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

    public class AutoevaluacionController : ControllerBase
    {
        private readonly IAutoevaluacionService _autoevaluacionService;
        private readonly IMapper _mapper;
        private readonly colegioContext _colegioContext;

        public AutoevaluacionController(IAutoevaluacionService autoevaluacionService, IMapper mapper, colegioContext colegioContext)
        {
            _autoevaluacionService = autoevaluacionService;
            _mapper = mapper;
            _colegioContext = colegioContext;
        }

        [HttpGet]
        public IActionResult GetAutoevaluaciones()
        {
            var autoevaluaciones = _autoevaluacionService.GetAutoevaluaciones();
            var autoevaluacionDtos = _mapper.Map<IEnumerable<AutoevaluacionDto>>(autoevaluaciones);

            var response = new ApiResponse<IEnumerable<AutoevaluacionDto>>(autoevaluacionDtos);
            return Ok(response);
        }

        /*[HttpGet("{Id}")]
        public async Task<IActionResult> GetAutoevaluacion(long Id)
        {
            var autoevaluacion = await _autoevaluacionService.GetAutoevaluacion(Id);
            var autoevaluacionDto = _mapper.Map<AutoevaluacionDto>(autoevaluacion);

            var response = new ApiResponse<AutoevaluacionDto>(autoevaluacionDto);
            return Ok(response);
        }*/

        [HttpPost]
        public async Task<IActionResult> Post(AutoevaluacionDto autoevaluacionDto)
        {
            var autoevaluacion = _mapper.Map<Autoevaluacion>(autoevaluacionDto);
            await _autoevaluacionService.InsertAutoevaluacion(autoevaluacion);

            autoevaluacionDto = _mapper.Map<AutoevaluacionDto>(autoevaluacion);
            var response = new ApiResponse<AutoevaluacionDto>(autoevaluacionDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, AutoevaluacionDto autoevaluacionDto)
        {
            var autoevaluacion = _mapper.Map<Autoevaluacion>(autoevaluacionDto);
            autoevaluacion.Id = Id;
            var result = await _autoevaluacionService.UpdateAutoevaluacion(autoevaluacion);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _autoevaluacionService.DeleteAutoevaluacion(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        //Para capturar IdEvalPoseedor de Nota
        [HttpGet("{notaId}")]
        public ActionResult<AutoevaluacionDto> GetNota(long notaId)
        {
            var nota = _colegioContext.Autoevaluacion.FirstOrDefault(ele => ele.IdEvalPoseedor == notaId);
            if (nota == null)
            {
                return NotFound();
            }
            var notaDto = _mapper.Map<AutoevaluacionDto>(nota);

            return notaDto;
        }
    }
}
