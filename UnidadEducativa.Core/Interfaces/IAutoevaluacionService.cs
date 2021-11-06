using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IAutoevaluacionService
    {
        IEnumerable<Autoevaluacion> GetAutoevaluaciones();
        Task<Autoevaluacion> GetAutoevaluacion(long Id);
        Task InsertAutoevaluacion(Autoevaluacion autoevaluacion);
        Task<bool> UpdateAutoevaluacion(Autoevaluacion autoevaluacion);
        Task<bool> DeleteAutoevaluacion(long Id);
    }
}
