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

    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorService _administradorService;
        private readonly IMapper _mapper;
        private readonly colegioContext _colegioContext;

        public AdministradorController(IAdministradorService administradorService, IMapper mapper, colegioContext colegioContext)
        {
            _administradorService = administradorService;
            _mapper = mapper;
            _colegioContext = colegioContext;
        }

        [HttpGet]
        public IActionResult GetAdministradores()
        {
            var administradores = _administradorService.GetAdministradores();
            var administradorDtos = _mapper.Map<IEnumerable<AdministradorDto>>(administradores);

            var response = new ApiResponse<IEnumerable<AdministradorDto>>(administradorDtos);
            return Ok(response);
        }

        /*[HttpGet("{Id}")]
        public async Task<IActionResult> GetAdministrador(long Id)
        {
            var administrador = await _administradorService.GetAdministrador(Id);
            var AdministradorDto = _mapper.Map<AdministradorDto>(administrador);

            var response = new ApiResponse<AdministradorDto>(AdministradorDto);
            return Ok(response);
        }*/

        [HttpPost]
        public async Task<IActionResult> Post(AdministradorDto AdministradorDto)
        {
            var administrador = _mapper.Map<Administrador>(AdministradorDto);
            await _administradorService.InsertAdministrador(administrador);

            AdministradorDto = _mapper.Map<AdministradorDto>(administrador);
            var response = new ApiResponse<AdministradorDto>(AdministradorDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, AdministradorDto AdministradorDto)
        {
            var administrador = _mapper.Map<Administrador>(AdministradorDto);
            administrador.Id = Id;
            var result = await _administradorService.UpdateAdministrador(administrador);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _administradorService.DeleteAdministrador(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        // Buscar por CI
        [HttpGet("{cedulaIdentidad}")]
        public ActionResult<AdministradorDto> GetAdministrador(string cedulaIdentidad)
        {
            var administrador = _colegioContext.Administrador.FirstOrDefault(ele => ele.CedulaIdentidad == cedulaIdentidad);
            if (administrador == null)
            {
                return NotFound();
            }
            var administradorDto = _mapper.Map<AdministradorDto>(administrador);

            return administradorDto;
        }

    }
}
