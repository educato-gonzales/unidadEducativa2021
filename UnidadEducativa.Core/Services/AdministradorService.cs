using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class AdministradorService : IAdministradorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdministradorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Administrador> GetAdministrador(long Id)
        {
            return await _unitOfWork.AdministradorRepository.GetById(Id);
        }

        public IEnumerable<Administrador> GetAdministradores()
        {
            return _unitOfWork.AdministradorRepository.GetAll();
        }

        public async Task InsertAdministrador(Administrador administrador)
        {
            await _unitOfWork.AdministradorRepository.Add(administrador);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateAdministrador(Administrador administrador)
        {
            _unitOfWork.AdministradorRepository.Update(administrador);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAdministrador(long Id)
        {
            await _unitOfWork.AdministradorRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
