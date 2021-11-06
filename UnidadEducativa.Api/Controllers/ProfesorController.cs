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

    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService _profesorService;
        private readonly IMapper _mapper;
        private readonly colegioContext _colegioContext;

        public ProfesorController(IProfesorService profesorService, IMapper mapper, colegioContext colegioContext)
        {
            _profesorService = profesorService;
            _mapper = mapper;
            _colegioContext = colegioContext;
        }

        [HttpGet]
        public IActionResult GetProfesores()
        {
            var profesores = _profesorService.GetProfesores();
            var profesorDtos = _mapper.Map<IEnumerable<ProfesorDto>>(profesores);

            var response = new ApiResponse<IEnumerable<ProfesorDto>>(profesorDtos);
            return Ok(response);
        }

        /*[HttpGet("{Id}")]
        public async Task<IActionResult> GetProfesor(long Id)
        {
            var profesor = await _profesorService.GetProfesor(Id);
            var profesorDto = _mapper.Map<ProfesorDto>(profesor);

            var response = new ApiResponse<ProfesorDto>(profesorDto);
            return Ok(response);
        }*/

        [HttpPost]
        public async Task<IActionResult> Post(ProfesorDto profesorDto)
        {
            var profesor = _mapper.Map<Profesor>(profesorDto);
            await _profesorService.InsertProfesor(profesor);

            profesorDto = _mapper.Map<ProfesorDto>(profesor);
            var response = new ApiResponse<ProfesorDto>(profesorDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, ProfesorDto profesorDto)
        {
            var profesor = _mapper.Map<Profesor>(profesorDto);
            profesor.Id = Id;
            var result = await _profesorService.UpdateProfesor(profesor);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _profesorService.DeleteProfesor(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        //Buscar por CI
        [HttpGet("{cedulaIdentidad}")]
        public ActionResult<ProfesorDto> GetProfesor(string cedulaIdentidad)
        {
            var profesor = _colegioContext.Profesor.FirstOrDefault(ele => ele.CedulaIdentidad == cedulaIdentidad);
            if (profesor == null)
            {
                return NotFound();
            }
            var profesorDto = _mapper.Map<ProfesorDto>(profesor);

            return profesorDto;
        }

    }
}
