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

    public class ParaleloController : ControllerBase
    {
        private readonly IParaleloService _paraleloService;
        private readonly IMapper _mapper;

        public ParaleloController(IParaleloService paraleloService, IMapper mapper)
        {
            _paraleloService = paraleloService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetParalelos()
        {
            var paralelos = _paraleloService.GetParalelos();
            var paraleloDtos = _mapper.Map<IEnumerable<ParaleloDto>>(paralelos);

            var response = new ApiResponse<IEnumerable<ParaleloDto>>(paraleloDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetParalelo(long Id)
        {
            var paralelo = await _paraleloService.GetParalelo(Id);
            var paraleloDto = _mapper.Map<ParaleloDto>(paralelo);

            var response = new ApiResponse<ParaleloDto>(paraleloDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ParaleloDto paraleloDto)
        {
            var paralelo = _mapper.Map<Paralelo>(paraleloDto);
            await _paraleloService.InsertParalelo(paralelo);

            paraleloDto = _mapper.Map<ParaleloDto>(paralelo);
            var response = new ApiResponse<ParaleloDto>(paraleloDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, ParaleloDto paraleloDto)
        {
            var paralelo = _mapper.Map<Paralelo>(paraleloDto);
            paralelo.Id = Id;
            var result = await _paraleloService.UpdateParalelo(paralelo);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _paraleloService.DeleteParalelo(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
