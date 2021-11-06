using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class EstudianteService : IEstudianteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstudianteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Estudiante> GetEstudiante(long Id)
        {
            return await _unitOfWork.EstudianteRepository.GetById(Id);
        }

        public IEnumerable<Estudiante> GetEstudiantes()
        {
            return _unitOfWork.EstudianteRepository.GetAll();
        }

        public async Task InsertEstudiante(Estudiante estudiante)
        {
            await _unitOfWork.EstudianteRepository.Add(estudiante);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateEstudiante(Estudiante estudiante)
        {
            _unitOfWork.EstudianteRepository.Update(estudiante);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEstudiante(long Id)
        {
            await _unitOfWork.EstudianteRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
