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

    public class NotificacionController : ControllerBase
    {
        private readonly INotificacionService _notificacionService;
        private readonly IMapper _mapper;

        public NotificacionController(INotificacionService notificacionService, IMapper mapper)
        {
            _notificacionService = notificacionService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetNotificaciones()
        {
            var notificaciones = _notificacionService.GetNotificaciones();
            var notificacionDtos = _mapper.Map<IEnumerable<NotificacionDto>>(notificaciones);

            var response = new ApiResponse<IEnumerable<NotificacionDto>>(notificacionDtos);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetNotificacion(long Id)
        {
            var notificacion = await _notificacionService.GetNotificacion(Id);
            var notificacionDto = _mapper.Map<NotificacionDto>(notificacion);

            var response = new ApiResponse<NotificacionDto>(notificacionDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NotificacionDto notificacionDto)
        {
            var notificacion = _mapper.Map<Notificacion>(notificacionDto);
            await _notificacionService.InsertNotificacion(notificacion);

            notificacionDto = _mapper.Map<NotificacionDto>(notificacion);
            var response = new ApiResponse<NotificacionDto>(notificacionDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, NotificacionDto notificacionDto)
        {
            var notificacion = _mapper.Map<Notificacion>(notificacionDto);
            notificacion.Id = Id;
            var result = await _notificacionService.UpdateNotificacion(notificacion);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _notificacionService.DeleteNotificacion(Id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
