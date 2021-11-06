using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{
    public class NotasService : INotasService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Notas> GetNotas(long Id)
        {
            return await _unitOfWork.NotasRepository.GetById(Id);
        }

        public IEnumerable<Notas> GetNotass()
        {
            return _unitOfWork.NotasRepository.GetAll();
        }

        public async Task InsertNotas(Notas notas)
        {
            await _unitOfWork.NotasRepository.Add(notas);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateNotas(Notas notas)
        {
            _unitOfWork.NotasRepository.Update(notas);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteNotas(long Id)
        {
            await _unitOfWork.NotasRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
