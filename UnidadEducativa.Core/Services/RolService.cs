using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class RolService : IRolService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Rol> GetRol(long Id)
        {
            return await _unitOfWork.RolRepository.GetById(Id);
        }

        public IEnumerable<Rol> GetRols()
        {
            return  _unitOfWork.RolRepository.GetAll();
        }

        public async Task InsertRol(Rol rol)
        {
            await _unitOfWork.RolRepository.Add(rol);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateRol(Rol rol)
        {
            _unitOfWork.RolRepository.Update(rol);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRol(long Id)
        {
            await _unitOfWork.RolRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
