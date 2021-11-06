using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class AutoevaluacionService : IAutoevaluacionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AutoevaluacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Autoevaluacion> GetAutoevaluacion(long Id)
        {
            return await _unitOfWork.AutoevaluacionRepository.GetById(Id);
        }

        public IEnumerable<Autoevaluacion> GetAutoevaluaciones()
        {
            return _unitOfWork.AutoevaluacionRepository.GetAll();
        }

        public async Task InsertAutoevaluacion(Autoevaluacion autoevaluacion)
        {
            await _unitOfWork.AutoevaluacionRepository.Add(autoevaluacion);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateAutoevaluacion(Autoevaluacion autoevaluacion)
        {
            _unitOfWork.AutoevaluacionRepository.Update(autoevaluacion);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAutoevaluacion(long Id)
        {
            await _unitOfWork.AutoevaluacionRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
