using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class EstudianteMateriaService : IEstudianteMateriaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstudianteMateriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EstudianteMateria> GetEstudianteMateria(long Id)
        {
            return await _unitOfWork.EstudianteMateriaRepository.GetById(Id);
        }

        public IEnumerable<EstudianteMateria> GetEstudianteMaterias()
        {
            return _unitOfWork.EstudianteMateriaRepository.GetAll();
        }

        public async Task InsertEstudianteMateria(EstudianteMateria estudianteMateria)
        {
            await _unitOfWork.EstudianteMateriaRepository.Add(estudianteMateria);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateEstudianteMateria(EstudianteMateria estudianteMateria)
        {
            _unitOfWork.EstudianteMateriaRepository.Update(estudianteMateria);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEstudianteMateria(long Id)
        {
            await _unitOfWork.EstudianteMateriaRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
