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

    public class RudeController : ControllerBase
    {
        private readonly IRudeService _rudeService;
        private readonly IMapper _mapper;
        private readonly colegioContext _colegioContext;

        public RudeController(IRudeService rudeService, IMapper mapper, colegioContext colegioContext)
        {
            _rudeService = rudeService;
            _mapper = mapper;
            _colegioContext = colegioContext;
        }

        [HttpGet]
        public IActionResult GetRudes()
        {
            var rudes = _rudeService.GetRudes();
            var rudeDtos = _mapper.Map<IEnumerable<RudeDto>>(rudes);

            var response = new ApiResponse<IEnumerable<RudeDto>>(rudeDtos);
            return Ok(response);
        }

        /*[HttpGet("{Id}")]
        public async Task<IActionResult> GetRude(long Id)
        {
            var rude = await _rudeService.GetRude(Id);
            var rudeDto = _mapper.Map<RudeDto>(rude);

            var response = new ApiResponse<RudeDto>(rudeDto);
            return Ok(response);
        }*/

        [HttpPost]
        public async Task<IActionResult> Post(RudeDto rudeDto)
        {
            var rude = _mapper.Map<Rude>(rudeDto);
            await _rudeService.InsertRude(rude);

            rudeDto = _mapper.Map<RudeDto>(rude);
            var response = new ApiResponse<RudeDto>(rudeDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, RudeDto rudeDto)
        {
            var rude = _mapper.Map<Rude>(rudeDto);
            rude.Id = Id;
            var result = await _rudeService.UpdateRude(rude);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _rudeService.DeleteRude(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpGet("{codRude}")]
        public ActionResult<RudeDto> GetRude(string codRude)
        {
            var rude = _colegioContext.Rude.FirstOrDefault(ele => ele.CodRude == codRude);
            if (rude == null)
            {
                return NotFound();
            }
            var rudeDto = _mapper.Map<RudeDto>(rude);

            return rudeDto;
        }

    }
}

