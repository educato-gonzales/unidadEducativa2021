using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class NotaService : INotaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Nota> GetNota(long Id)
        {
            return await _unitOfWork.NotaRepository.GetById(Id);
        }

        public IEnumerable<Nota> GetNotas()
        {
            return _unitOfWork.NotaRepository.GetAll();
        }

        public async Task InsertNota(Nota nota)
        {
            await _unitOfWork.NotaRepository.Add(nota);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateNota(Nota nota)
        {
            _unitOfWork.NotaRepository.Update(nota);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteNota(long Id)
        {
            await _unitOfWork.NotaRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
