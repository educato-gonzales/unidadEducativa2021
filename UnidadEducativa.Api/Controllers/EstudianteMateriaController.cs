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

    public class EstudianteMateriaController : ControllerBase
    {
        private readonly IEstudianteMateriaService _estudianteMateria;
        private readonly IMapper _mapper;

        public EstudianteMateriaController(IEstudianteMateriaService estudianteMateriaService, IMapper mapper)
        {
            _estudianteMateria = estudianteMateriaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEstudianteMaterias()
        {
            var estudianteMaterias = _estudianteMateria.GetEstudianteMaterias();
            var estudianteMateriaDtos = _mapper.Map<IEnumerable<EstudianteMateriaDto>>(estudianteMaterias);

            var response = new ApiResponse<IEnumerable<EstudianteMateriaDto>>(estudianteMateriaDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEstudianteMateria(long Id)
        {
            var estudianteMateria = await _estudianteMateria.GetEstudianteMateria(Id);
            var estudianteMateriaDto = _mapper.Map<EstudianteMateriaDto>(estudianteMateria);

            var response = new ApiResponse<EstudianteMateriaDto>(estudianteMateriaDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EstudianteMateriaDto estudianteMateriaDto)
        {
            var estudianteMateria = _mapper.Map<EstudianteMateria>(estudianteMateriaDto);
            await _estudianteMateria.InsertEstudianteMateria(estudianteMateria);

            estudianteMateriaDto = _mapper.Map<EstudianteMateriaDto>(estudianteMateria);
            var response = new ApiResponse<EstudianteMateriaDto>(estudianteMateriaDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, EstudianteMateriaDto estudianteMateriaDto)
        {
            var estudianteMateria = _mapper.Map<EstudianteMateria>(estudianteMateriaDto);
            estudianteMateria.Id = Id;
            var result = await _estudianteMateria.UpdateEstudianteMateria(estudianteMateria);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _estudianteMateria.DeleteEstudianteMateria(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
