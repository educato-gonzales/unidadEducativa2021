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
using UnidadEducativa.Infrastructure.Data;

namespace UnidadEducativa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RepresentanteController : ControllerBase
    {
        private readonly IRepresentanteService _representanteService;
        private readonly IMapper _mapper;
        private readonly colegioContext _colegioContext;

        public RepresentanteController(IRepresentanteService representanteService, IMapper mapper, colegioContext colegioContext)
        {
            _representanteService = representanteService;
            _mapper = mapper;
            _colegioContext = colegioContext;
        }

        [HttpGet]
        public IActionResult GetRepresentantes()
        {
            var representantes = _representanteService.GetRepresentantes();
            var representanteDtos = _mapper.Map<IEnumerable<RepresentanteDto>>(representantes);

            var response = new ApiResponse<IEnumerable<RepresentanteDto>>(representanteDtos);
            return Ok(response);
        }

        /*[HttpGet("{Id}")]
        public async Task<IActionResult> GetRepresentante(long Id)
        {
            var representante = await _representanteService.GetRepresentante(Id);
            var representanteDto = _mapper.Map<RepresentanteDto>(representante);

            var response = new ApiResponse<RepresentanteDto>(representanteDto);
            return Ok(response);
        }*/

        //Para buscar datos en RUDE
        [HttpGet("{id}/{idBuscar}")]
        public async Task<IActionResult> GetRepresentante(long id, long idBuscar)
        {
            var vacio = idBuscar;
            var representante = await _representanteService.GetRepresentante(id);
            var representanteDto = _mapper.Map<RepresentanteDto>(representante);

            var response = new ApiResponse<RepresentanteDto>(representanteDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RepresentanteDto representanteDto)
        {
            var representante = _mapper.Map<Representante>(representanteDto);
            await _representanteService.InsertRepresentante(representante);

            representanteDto = _mapper.Map<RepresentanteDto>(representante);
            var response = new ApiResponse<RepresentanteDto>(representanteDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, RepresentanteDto representanteDto)
        {
            var representante = _mapper.Map<Representante>(representanteDto);
            representante.Id = Id;
            var result = await _representanteService.UpdateRepresentante(representante);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _representanteService.DeleteRepresentante(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        // Bucsar por CI
        [HttpGet("{cedulaIdentidad}")]
        public ActionResult<RepresentanteDto> GetRepresentante(string cedulaIdentidad)
        {
            var representante = _colegioContext.Representante.FirstOrDefault(ele => ele.CedulaIdentidad == cedulaIdentidad);
            if (representante == null)
            {
                return NotFound();
            }
            var representanteDto = _mapper.Map<RepresentanteDto>(representante);

            return representanteDto;
        }

    }
}
