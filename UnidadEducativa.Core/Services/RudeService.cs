using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class RudeService : IRudeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RudeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Rude> GetRude(long Id)
        {
            return await _unitOfWork.RudeRepository.GetById(Id);
        }

        public IEnumerable<Rude> GetRudes()
        {
            return _unitOfWork.RudeRepository.GetAll();
        }

        public async Task InsertRude(Rude rude)
        {
            await _unitOfWork.RudeRepository.Add(rude);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateRude(Rude rude)
        {
            _unitOfWork.RudeRepository.Update(rude);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRude(long Id)
        {
            await _unitOfWork.RudeRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
