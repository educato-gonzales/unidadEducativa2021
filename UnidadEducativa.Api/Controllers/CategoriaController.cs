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

    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService categoriaService, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategorias()
        {
            var categorias = _categoriaService.GetCategorias();
            var categoriaDtos = _mapper.Map<IEnumerable<CategoriaDto>>(categorias);

            var response = new ApiResponse<IEnumerable<CategoriaDto>>(categoriaDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategoria(long Id)
        {
            var categoria = await _categoriaService.GetCategoria(Id);
            var categoriaDto = _mapper.Map<CategoriaDto>(categoria);

            var response = new ApiResponse<CategoriaDto>(categoriaDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoriaDto categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaService.InsertCategoria(categoria);

            categoriaDto = _mapper.Map<CategoriaDto>(categoria);
            var response = new ApiResponse<CategoriaDto>(categoriaDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, CategoriaDto categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            categoria.Id = Id;
            var result = await _categoriaService.UpdateCategoria(categoria);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _categoriaService.DeleteCategoria(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
