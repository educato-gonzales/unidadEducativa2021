using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class ProfesorService : IProfesorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfesorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Profesor> GetProfesor(long Id)
        {
            return await _unitOfWork.ProfesorRepository.GetById(Id);
        }

        public IEnumerable<Profesor> GetProfesores()
        {
            return _unitOfWork.ProfesorRepository.GetAll();
        }

        public async Task InsertProfesor(Profesor profesor)
        {
            await _unitOfWork.ProfesorRepository.Add(profesor);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProfesor(Profesor profesor)
        {
            _unitOfWork.ProfesorRepository.Update(profesor);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProfesor(long Id)
        {
            await _unitOfWork.ProfesorRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
