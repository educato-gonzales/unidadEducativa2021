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

    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;
        private readonly IMapper _mapper;
        private readonly colegioContext _colegioContext;

        public EstudianteController(IEstudianteService estudianteService, IMapper mapper, colegioContext colegioContext)
        {
            _estudianteService = estudianteService;
            _mapper = mapper;
            _colegioContext = colegioContext;
        }

        [HttpGet]
        public IActionResult GetEstudiantes()
        {
            var estudiantes = _estudianteService.GetEstudiantes();
            var estudianteDtos = _mapper.Map<IEnumerable<EstudianteDto>>(estudiantes);

            var response = new ApiResponse<IEnumerable<EstudianteDto>>(estudianteDtos);
            return Ok(response);
        }

        //Para buscar datos en RUDE
        //[HttpGet("{Id}")]
        [HttpGet("{id}/{idBuscar}")]
        public async Task<IActionResult> GetEstudiante(long id, long idBuscar)
        {
            var vacio = idBuscar;
            var estudiante = await _estudianteService.GetEstudiante(id);
            var estudianteDto = _mapper.Map<EstudianteDto>(estudiante);

            var response = new ApiResponse<EstudianteDto>(estudianteDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EstudianteDto estudianteDto)
        {
            var estudiante = _mapper.Map<Estudiante>(estudianteDto);
            await _estudianteService.InsertEstudiante(estudiante);

            estudianteDto = _mapper.Map<EstudianteDto>(estudiante);
            var response = new ApiResponse<EstudianteDto>(estudianteDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, EstudianteDto estudianteDto)
        {
            var estudiante = _mapper.Map<Estudiante>(estudianteDto);
            estudiante.Id = Id;
            var result = await _estudianteService.UpdateEstudiante(estudiante);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _estudianteService.DeleteEstudiante(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        // GET: api/Usuarios/Nombre/Clave
        [HttpGet("{cedulaIdentidad}")]
        public ActionResult<EstudianteDto> GetEstudiante(string cedulaIdentidad)
        {
            var estudiante = _colegioContext.Estudiante.FirstOrDefault(ele => ele.CedulaIdentidad == cedulaIdentidad );
            if (estudiante == null)
            {
                return NotFound();
            }
            var estudianteDto = _mapper.Map<EstudianteDto>(estudiante);

            return estudianteDto;
        }

    }
}
