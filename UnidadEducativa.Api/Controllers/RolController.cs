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

    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;
        private readonly IMapper _mapper;

        public RolController(IRolService rolService, IMapper mapper)
        {
            _rolService = rolService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetRols()
        {
            var rols = _rolService.GetRols();            
            var rolDtos = _mapper.Map<IEnumerable<RolDto>>(rols);

            var response = new ApiResponse<IEnumerable<RolDto>>(rolDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetRol(long Id)
        {
            var rol = await _rolService.GetRol(Id);
            var rolDto = _mapper.Map<RolDto>(rol);

            var response = new ApiResponse<RolDto>(rolDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RolDto rolDto)
        {
            var rol = _mapper.Map<Rol>(rolDto);
            await _rolService.InsertRol(rol);

            rolDto = _mapper.Map<RolDto>(rol);
            var response = new ApiResponse<RolDto>(rolDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, RolDto rolDto)
        {
            var rol = _mapper.Map<Rol>(rolDto);
            rol.Id = Id;
            var result = await _rolService.UpdateRol(rol);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _rolService.DeleteRol(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
