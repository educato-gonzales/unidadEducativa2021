using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{
    public class PeriodoService : IPeriodoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PeriodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Periodo> GetPeriodo(long Id)
        {
            return await _unitOfWork.PeriodoRepository.GetById(Id);
        }

        public IEnumerable<Periodo> GetPeriodos()
        {
            return _unitOfWork.PeriodoRepository.GetAll();
        }

        public async Task InsertPeriodo(Periodo periodo)
        {
            await _unitOfWork.PeriodoRepository.Add(periodo);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePeriodo(Periodo periodo)
        {
            _unitOfWork.PeriodoRepository.Update(periodo);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePeriodo(long Id)
        {
            await _unitOfWork.PeriodoRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
