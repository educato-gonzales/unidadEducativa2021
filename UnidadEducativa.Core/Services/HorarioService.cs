using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class HorarioService : IHorarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HorarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Horario> GetHorario(long Id)
        {
            return await _unitOfWork.HorarioRepository.GetById(Id);
        }

        public IEnumerable<Horario> GetHorarios()
        {
            return _unitOfWork.HorarioRepository.GetAll();
        }

        public async Task InsertHorario(Horario horario)
        {
            await _unitOfWork.HorarioRepository.Add(horario);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateHorario(Horario horario)
        {
            _unitOfWork.HorarioRepository.Update(horario);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteHorario(long Id)
        {
            await _unitOfWork.HorarioRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
