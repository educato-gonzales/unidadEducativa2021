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

    public class NotasController : ControllerBase
    {
        private readonly INotasService _notasService;
        private readonly IMapper _mapper;

        public NotasController(INotasService notasService, IMapper mapper)
        {
            _notasService = notasService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetNotass()
        {
            var notas = _notasService.GetNotass();
            var notasDtos = _mapper.Map<IEnumerable<NotasDto>>(notas);

            var response = new ApiResponse<IEnumerable<NotasDto>>(notasDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetNotas(long Id)
        {
            var notas = await _notasService.GetNotas(Id);
            var notasDto = _mapper.Map<NotasDto>(notas);

            var response = new ApiResponse<NotasDto>(notasDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NotasDto notasDto)
        {
            var notas = _mapper.Map<Notas>(notasDto);
            await _notasService.InsertNotas(notas);

            notasDto = _mapper.Map<NotasDto>(notas);
            var response = new ApiResponse<NotasDto>(notasDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, NotasDto notasDto)
        {
            var notas = _mapper.Map<Notas>(notasDto);
            notas.Id = Id;
            var result = await _notasService.UpdateNotas(notas);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _notasService.DeleteNotas(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
