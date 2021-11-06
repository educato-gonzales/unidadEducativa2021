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

    public class PeriodoController : ControllerBase
    {
        private readonly IPeriodoService _periodoService;
        private readonly IMapper _mapper;

        public PeriodoController(IPeriodoService periodoService, IMapper mapper)
        {
            _periodoService = periodoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPeriodos()
        {
            var periodos = _periodoService.GetPeriodos();
            var periodoDtos = _mapper.Map<IEnumerable<PeriodoDto>>(periodos);

            var response = new ApiResponse<IEnumerable<PeriodoDto>>(periodoDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPeriodo(long Id)
        {
            var periodo = await _periodoService.GetPeriodo(Id);
            var periodoDto = _mapper.Map<PeriodoDto>(periodo);

            var response = new ApiResponse<PeriodoDto>(periodoDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PeriodoDto periodoDto)
        {
            var periodo = _mapper.Map<Periodo>(periodoDto);
            await _periodoService.InsertPeriodo(periodo);

            periodoDto = _mapper.Map<PeriodoDto>(periodo);
            var response = new ApiResponse<PeriodoDto>(periodoDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, PeriodoDto periodoDto)
        {
            var periodo = _mapper.Map<Periodo>(periodoDto);
            periodo.Id = Id;
            var result = await _periodoService.UpdatePeriodo(periodo);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _periodoService.DeletePeriodo(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
