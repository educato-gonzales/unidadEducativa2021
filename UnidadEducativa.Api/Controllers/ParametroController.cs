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

    public class ParametroController : ControllerBase
    {
        private readonly IParametroService _parametroService;
        private readonly IMapper _mapper;

        public ParametroController(IParametroService parametroService, IMapper mapper)
        {
            _parametroService = parametroService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetParametros()
        {
            var parametros = _parametroService.GetParametros();
            var parametroDtos = _mapper.Map<IEnumerable<ParametroDto>>(parametros);

            var response = new ApiResponse<IEnumerable<ParametroDto>>(parametroDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetParametro(long Id)
        {
            var parametro = await _parametroService.GetParametro(Id);
            var parametroDto = _mapper.Map<ParametroDto>(parametro);

            var response = new ApiResponse<ParametroDto>(parametroDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ParametroDto parametroDto)
        {
            var parametro = _mapper.Map<Parametro>(parametroDto);
            await _parametroService.InsertParametro(parametro);

            parametroDto = _mapper.Map<ParametroDto>(parametro);
            var response = new ApiResponse<ParametroDto>(parametroDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, ParametroDto parametroDto)
        {
            var parametro = _mapper.Map<Parametro>(parametroDto);
            parametro.Id = Id;
            var result = await _parametroService.UpdateParametro(parametro);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _parametroService.DeleteParametro(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
