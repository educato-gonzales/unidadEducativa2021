using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class MateriaDictadaService : IMateriaDictadaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MateriaDictadaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MateriaDictada> GetMateriaDictada(long Id)
        {
            return await _unitOfWork.MateriaDictadaRepository.GetById(Id);
        }

        public IEnumerable<MateriaDictada> GetMateriaDictadas()
        {
            return _unitOfWork.MateriaDictadaRepository.GetAll();
        }

        public async Task InsertMateriaDictada(MateriaDictada materiaDictada)
        {
            await _unitOfWork.MateriaDictadaRepository.Add(materiaDictada);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateMateriaDictada(MateriaDictada materiaDictada)
        {
            _unitOfWork.MateriaDictadaRepository.Update(materiaDictada);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMateriaDictada(long Id)
        {
            await _unitOfWork.MateriaDictadaRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
