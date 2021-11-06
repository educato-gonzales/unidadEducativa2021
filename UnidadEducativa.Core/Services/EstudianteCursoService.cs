using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class EstudianteCursoService : IEstudianteCursoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstudianteCursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EstudianteCurso> GetEstudianteCurso(long Id)
        {
            return await _unitOfWork.EstudianteCursoRepository.GetById(Id);
        }

        public IEnumerable<EstudianteCurso> GetEstudianteCursos()
        {
            return _unitOfWork.EstudianteCursoRepository.GetAll();
        }

        public async Task InsertEstudianteCurso(EstudianteCurso estudianteCurso)
        {
            await _unitOfWork.EstudianteCursoRepository.Add(estudianteCurso);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateEstudianteCurso(EstudianteCurso estudianteCurso)
        {
            _unitOfWork.EstudianteCursoRepository.Update(estudianteCurso);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEstudianteCurso(long Id)
        {
            await _unitOfWork.EstudianteCursoRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
