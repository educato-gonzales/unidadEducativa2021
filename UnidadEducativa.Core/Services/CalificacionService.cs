using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class CalificacionService : ICalificacionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CalificacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Calificacion> GetCalificacion(long Id)
        {
            return await _unitOfWork.CalificacionRepository.GetById(Id);
        }

        public IEnumerable<Calificacion> GetCalificaciones()
        {
            return _unitOfWork.CalificacionRepository.GetAll();
        }

        public async Task InsertCalificacion(Calificacion calificacion)
        {
            await _unitOfWork.CalificacionRepository.Add(calificacion);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateCalificacion(Calificacion calificacion)
        {
            _unitOfWork.CalificacionRepository.Update(calificacion);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCalificacion(long Id)
        {
            await _unitOfWork.CalificacionRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
