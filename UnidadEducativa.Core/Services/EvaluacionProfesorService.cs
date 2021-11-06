using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class EvaluacionProfesorService : IEvaluacionProfesorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EvaluacionProfesorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EvaluacionProfesor> GetEvaluacionProfesor(long Id)
        {
            return await _unitOfWork.EvaluacionProfesorRepository.GetById(Id);
        }

        public IEnumerable<EvaluacionProfesor> GetEvaluacionProfesores()
        {
            return _unitOfWork.EvaluacionProfesorRepository.GetAll();
        }

        public async Task InsertEvaluacionProfesor(EvaluacionProfesor evaluacionProfesor)
        {
            await _unitOfWork.EvaluacionProfesorRepository.Add(evaluacionProfesor);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateEvaluacionProfesor(EvaluacionProfesor evaluacionProfesor)
        {
            _unitOfWork.EvaluacionProfesorRepository.Update(evaluacionProfesor);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEvaluacionProfesor(long Id)
        {
            await _unitOfWork.EvaluacionProfesorRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
