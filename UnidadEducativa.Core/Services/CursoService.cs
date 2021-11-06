using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class CursoService : ICursoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Curso> GetCurso(long Id)
        {
            return await _unitOfWork.CursoRepository.GetById(Id);
        }

        public IEnumerable<Curso> GetCursos()
        {
            return _unitOfWork.CursoRepository.GetAll();
        }

        public async Task InsertCurso(Curso curso)
        {
            await _unitOfWork.CursoRepository.Add(curso);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateCurso(Curso curso)
        {
            _unitOfWork.CursoRepository.Update(curso);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCurso(long Id)
        {
            await _unitOfWork.CursoRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
