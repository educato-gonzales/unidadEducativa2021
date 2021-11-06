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

    public class FotosController : ControllerBase
    {
        private readonly IFotosService _fotosService;
        private readonly IMapper _mapper;

        public FotosController(IFotosService fotosService, IMapper mapper)
        {
            _fotosService = fotosService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFotoss()
        {
            var fotoss = _fotosService.GetFotoss();
            var fotosDtos = _mapper.Map<IEnumerable<FotosDto>>(fotoss);

            var response = new ApiResponse<IEnumerable<FotosDto>>(fotosDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetFotos(long Id)
        {
            var fotos = await _fotosService.GetFotos(Id);
            var fotosDto = _mapper.Map<FotosDto>(fotos);

            var response = new ApiResponse<FotosDto>(fotosDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(FotosDto fotosDto)
        {
            var fotos = _mapper.Map<Fotos>(fotosDto);
            await _fotosService.InsertFotos(fotos);

            fotosDto = _mapper.Map<FotosDto>(fotos);
            var response = new ApiResponse<FotosDto>(fotosDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, FotosDto fotosDto)
        {
            var fotos = _mapper.Map<Fotos>(fotosDto);
            fotos.Id = Id;
            var result = await _fotosService.UpdateFotos(fotos);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _fotosService.DeleteFotos(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
