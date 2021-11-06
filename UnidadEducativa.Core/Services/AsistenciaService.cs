using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class AsistenciaService : IAsistenciaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AsistenciaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Asistencia> GetAsistencia(long Id)
        {
            return await _unitOfWork.AsistenciaRepository.GetById(Id);
        }

        public IEnumerable<Asistencia> GetAsistencias()
        {
            return _unitOfWork.AsistenciaRepository.GetAll();
        }

        public async Task InsertAsistencia(Asistencia asistencia)
        {
            await _unitOfWork.AsistenciaRepository.Add(asistencia);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsistencia(Asistencia asistencia)
        {
            _unitOfWork.AsistenciaRepository.Update(asistencia);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsistencia(long Id)
        {
            await _unitOfWork.AsistenciaRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
