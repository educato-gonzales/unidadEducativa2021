using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class InstitucionService : IInstitucionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InstitucionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Institucion> GetInstitucion(long Id)
        {
            return await _unitOfWork.InstitucionRepository.GetById(Id);
        }

        public IEnumerable<Institucion> GetInstituciones()
        {
            return _unitOfWork.InstitucionRepository.GetAll();
        }

        public async Task InsertInstitucion(Institucion institucion)
        {
            await _unitOfWork.InstitucionRepository.Add(institucion);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateInstitucion(Institucion institucion)
        {
            _unitOfWork.InstitucionRepository.Update(institucion);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteInstitucion(long Id)
        {
            await _unitOfWork.InstitucionRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
