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

    public class NotaController : ControllerBase
    {
        private readonly INotaService _notaService;
        private readonly IMapper _mapper;

        public NotaController(INotaService notaService, IMapper mapper)
        {
            _notaService = notaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetNotas()
        {
            var notas = _notaService.GetNotas();
            var notaDtos = _mapper.Map<IEnumerable<NotaDto>>(notas);

            var response = new ApiResponse<IEnumerable<NotaDto>>(notaDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetNota(long Id)
        {
            var nota = await _notaService.GetNota(Id);
            var notaDto = _mapper.Map<NotaDto>(nota);

            var response = new ApiResponse<NotaDto>(notaDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NotaDto notaDto)
        {
            var nota = _mapper.Map<Nota>(notaDto);
            await _notaService.InsertNota(nota);

            notaDto = _mapper.Map<NotaDto>(nota);
            var response = new ApiResponse<NotaDto>(notaDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, NotaDto notaDto)
        {
            var nota = _mapper.Map<Nota>(notaDto);
            nota.Id = Id;
            var result = await _notaService.UpdateNota(nota);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _notaService.DeleteNota(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        
    }
}
