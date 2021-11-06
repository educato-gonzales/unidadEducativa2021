using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class MateriaService : IMateriaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MateriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Materia> GetMateria(long Id)
        {
            return await _unitOfWork.MateriaRepository.GetById(Id);
        }

        public IEnumerable<Materia> GetMaterias()
        {
            return _unitOfWork.MateriaRepository.GetAll();
        }

        public async Task InsertMateria(Materia materia)
        {
            await _unitOfWork.MateriaRepository.Add(materia);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateMateria(Materia materia)
        {
            _unitOfWork.MateriaRepository.Update(materia);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMateria(long Id)
        {
            await _unitOfWork.MateriaRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
