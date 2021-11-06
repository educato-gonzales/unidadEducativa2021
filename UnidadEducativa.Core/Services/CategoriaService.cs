
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Categoria> GetCategoria(long Id)
        {
            return await _unitOfWork.CategoriaRepository.GetById(Id);
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return _unitOfWork.CategoriaRepository.GetAll();
        }

        public async Task InsertCategoria(Categoria categoria)
        {
            await _unitOfWork.CategoriaRepository.Add(categoria);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateCategoria(Categoria categoria)
        {
            _unitOfWork.CategoriaRepository.Update(categoria);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategoria(long Id)
        {
            await _unitOfWork.CategoriaRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
