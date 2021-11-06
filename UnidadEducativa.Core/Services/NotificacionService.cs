using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class NotificacionService : INotificacionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Notificacion> GetNotificacion(long Id)
        {
            return await _unitOfWork.NotificacionRepository.GetById(Id);
        }

        public IEnumerable<Notificacion> GetNotificaciones()
        {
            return _unitOfWork.NotificacionRepository.GetAll();
        }

        public async Task InsertNotificacion(Notificacion notificacion)
        {
            await _unitOfWork.NotificacionRepository.Add(notificacion);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateNotificacion(Notificacion notificacion)
        {
            _unitOfWork.NotificacionRepository.Update(notificacion);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteNotificacion(long Id)
        {
            await _unitOfWork.NotificacionRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
