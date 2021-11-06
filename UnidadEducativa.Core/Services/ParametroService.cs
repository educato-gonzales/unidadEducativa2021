using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;
using UnidadEducativa.Core.Interfaces;

namespace UnidadEducativa.Core.Services
{

    public class ParametroService : IParametroService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParametroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Parametro> GetParametro(long Id)
        {
            return await _unitOfWork.ParametroRepository.GetById(Id);
        }

        public IEnumerable<Parametro> GetParametros()
        {
            return _unitOfWork.ParametroRepository.GetAll();
        }

        public async Task InsertParametro(Parametro parametro)
        {
            await _unitOfWork.ParametroRepository.Add(parametro);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateParametro(Parametro parametro)
        {
            _unitOfWork.ParametroRepository.Update(parametro);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteParametro(long Id)
        {
            await _unitOfWork.ParametroRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
