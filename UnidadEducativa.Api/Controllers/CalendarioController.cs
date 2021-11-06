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

    public class CalendarioController : ControllerBase
    {
        private readonly ICalendarioService _calendarioService;
        private readonly IMapper _mapper;

        public CalendarioController(ICalendarioService calendarioService, IMapper mapper)
        {
            _calendarioService = calendarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCalendarios()
        {
            var calendarios = _calendarioService.GetCalendarios();
            var calendarioDtos = _mapper.Map<IEnumerable<CalendarioDto>>(calendarios);

            var response = new ApiResponse<IEnumerable<CalendarioDto>>(calendarioDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCalendario(long Id)
        {
            var calendario = await _calendarioService.GetCalendario(Id);
            var calendarioDto = _mapper.Map<CalendarioDto>(calendario);

            var response = new ApiResponse<CalendarioDto>(calendarioDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CalendarioDto calendarioDto)
        {
            var calendario = _mapper.Map<Calendario>(calendarioDto);
            await _calendarioService.InsertCalendario(calendario);

            calendarioDto = _mapper.Map<CalendarioDto>(calendario);
            var response = new ApiResponse<CalendarioDto>(calendarioDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, CalendarioDto calendarioDto)
        {
            var calendario = _mapper.Map<Calendario>(calendarioDto);
            calendario.Id = Id;
            var result = await _calendarioService.UpdateCalendario(calendario);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _calendarioService.DeleteCalendario(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
