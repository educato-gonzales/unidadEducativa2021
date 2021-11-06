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

    public class HorarioController : ControllerBase
    {
        private readonly IHorarioService _horarioService;
        private readonly IMapper _mapper;

        public HorarioController(IHorarioService horarioService, IMapper mapper)
        {
            _horarioService = horarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetHorarios()
        {
            var horarios = _horarioService.GetHorarios();
            var horarioDtos = _mapper.Map<IEnumerable<HorarioDto>>(horarios);

            var response = new ApiResponse<IEnumerable<HorarioDto>>(horarioDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetHorario(long Id)
        {
            var horario = await _horarioService.GetHorario(Id);
            var horarioDto = _mapper.Map<HorarioDto>(horario);

            var response = new ApiResponse<HorarioDto>(horarioDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(HorarioDto horarioDto)
        {
            var horario = _mapper.Map<Horario>(horarioDto);
            await _horarioService.InsertHorario(horario);

            horarioDto = _mapper.Map<HorarioDto>(horario);
            var response = new ApiResponse<HorarioDto>(horarioDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, HorarioDto horarioDto)
        {
            var horario = _mapper.Map<Horario>(horarioDto);
            horario.Id = Id;
            var result = await _horarioService.UpdateHorario(horario);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _horarioService.DeleteHorario(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
