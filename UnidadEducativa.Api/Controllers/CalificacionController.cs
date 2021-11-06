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

    public class CalificacionController : ControllerBase
    {
        private readonly ICalificacionService _calificacionService;
        private readonly IMapper _mapper;

        public CalificacionController(ICalificacionService calificacionService, IMapper mapper)
        {
            _calificacionService = calificacionService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCalificaciones()
        {
            var calificaciones = _calificacionService.GetCalificaciones();
            var calificacionDtos = _mapper.Map<IEnumerable<CalificacionDto>>(calificaciones);

            var response = new ApiResponse<IEnumerable<CalificacionDto>>(calificacionDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCalificacion(long Id)
        {
            var calificacion = await _calificacionService.GetCalificacion(Id);
            var CalificacionDto = _mapper.Map<CalificacionDto>(calificacion);

            var response = new ApiResponse<CalificacionDto>(CalificacionDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CalificacionDto CalificacionDto)
        {
            var calificacion = _mapper.Map<Calificacion>(CalificacionDto);
            await _calificacionService.InsertCalificacion(calificacion);

            CalificacionDto = _mapper.Map<CalificacionDto>(calificacion);
            var response = new ApiResponse<CalificacionDto>(CalificacionDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, CalificacionDto CalificacionDto)
        {
            var calificacion = _mapper.Map<Calificacion>(CalificacionDto);
            calificacion.Id = Id;
            var result = await _calificacionService.UpdateCalificacion(calificacion);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _calificacionService.DeleteCalificacion(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
