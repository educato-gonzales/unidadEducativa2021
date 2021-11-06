using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class ParaleloService : IParaleloService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParaleloService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Paralelo> GetParalelo(long Id)
        {
            return await _unitOfWork.ParaleloRepository.GetById(Id);
        }

        public IEnumerable<Paralelo> GetParalelos()
        {
            return _unitOfWork.ParaleloRepository.GetAll();
        }

        public async Task InsertParalelo(Paralelo paralelo)
        {
            await _unitOfWork.ParaleloRepository.Add(paralelo);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateParalelo(Paralelo paralelo)
        {
            _unitOfWork.ParaleloRepository.Update(paralelo);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteParalelo(long Id)
        {
            await _unitOfWork.ParaleloRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
