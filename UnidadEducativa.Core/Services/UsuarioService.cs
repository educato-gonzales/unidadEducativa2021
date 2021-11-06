using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Usuario> GetUsuario(long Id)
        {
            return await _unitOfWork.UsuarioRepository.GetById(Id);
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return _unitOfWork.UsuarioRepository.GetAll();
        }

        public async Task InsertUsuario(Usuario Usuario)
        {
            await _unitOfWork.UsuarioRepository.Add(Usuario);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateUsuario(Usuario Usuario)
        {
            _unitOfWork.UsuarioRepository.Update(Usuario);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUsuario(long Id)
        {
            await _unitOfWork.UsuarioRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
