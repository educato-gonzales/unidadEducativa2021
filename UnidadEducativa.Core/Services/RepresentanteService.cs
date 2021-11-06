using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class RepresentanteService : IRepresentanteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepresentanteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Representante> GetRepresentante(long Id)
        {
            return await _unitOfWork.RepresentanteRepository.GetById(Id);
        }

        public IEnumerable<Representante> GetRepresentantes()
        {
            return _unitOfWork.RepresentanteRepository.GetAll();
        }

        public async Task InsertRepresentante(Representante representante)
        {
            await _unitOfWork.RepresentanteRepository.Add(representante);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateRepresentante(Representante representante)
        {
            _unitOfWork.RepresentanteRepository.Update(representante);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRepresentante(long Id)
        {
            await _unitOfWork.RepresentanteRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
