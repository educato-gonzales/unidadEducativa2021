using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class CalendarioService : ICalendarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CalendarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Calendario> GetCalendario(long Id)
        {
            return await _unitOfWork.CalendarioRepository.GetById(Id);
        }

        public IEnumerable<Calendario> GetCalendarios()
        {
            return _unitOfWork.CalendarioRepository.GetAll();
        }

        public async Task InsertCalendario(Calendario calendario)
        {
            await _unitOfWork.CalendarioRepository.Add(calendario);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateCalendario(Calendario calendario)
        {
            _unitOfWork.CalendarioRepository.Update(calendario);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCalendario(long Id)
        {
            await _unitOfWork.CalendarioRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
