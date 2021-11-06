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

    public class AsistenciaController : ControllerBase
    {
        private readonly IAsistenciaService _asistenciaService;
        private readonly IMapper _mapper;

        public AsistenciaController(IAsistenciaService asistenciaService, IMapper mapper)
        {
            _asistenciaService = asistenciaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAsistencias()
        {
            var asistencias = _asistenciaService.GetAsistencias();
            var asistenciaDtos = _mapper.Map<IEnumerable<AsistenciaDto>>(asistencias);

            var response = new ApiResponse<IEnumerable<AsistenciaDto>>(asistenciaDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsistencia(long Id)
        {
            var asistencia = await _asistenciaService.GetAsistencia(Id);
            var asistenciaDto = _mapper.Map<AsistenciaDto>(asistencia);

            var response = new ApiResponse<AsistenciaDto>(asistenciaDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AsistenciaDto asistenciaDto)
        {
            var asistencia = _mapper.Map<Asistencia>(asistenciaDto);
            await _asistenciaService.InsertAsistencia(asistencia);

            asistenciaDto = _mapper.Map<AsistenciaDto>(asistencia);
            var response = new ApiResponse<AsistenciaDto>(asistenciaDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, AsistenciaDto asistenciaDto)
        {
            var asistencia = _mapper.Map<Asistencia>(asistenciaDto);
            asistencia.Id = Id;
            var result = await _asistenciaService.UpdateAsistencia(asistencia);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _asistenciaService.DeleteAsistencia(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
