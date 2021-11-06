using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class FotosService : IFotosService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FotosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Fotos> GetFotos(long Id)
        {
            return await _unitOfWork.FotosRepository.GetById(Id);
        }

        public IEnumerable<Fotos> GetFotoss()
        {
            return _unitOfWork.FotosRepository.GetAll();
        }

        public async Task InsertFotos(Fotos fotos)
        {
            await _unitOfWork.FotosRepository.Add(fotos);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateFotos(Fotos fotos)
        {
            _unitOfWork.FotosRepository.Update(fotos);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFotos(long Id)
        {
            await _unitOfWork.FotosRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
