using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface ICalificacionService
    {
        IEnumerable<Calificacion> GetCalificaciones();
        Task<Calificacion> GetCalificacion(long Id);
        Task InsertCalificacion(Calificacion calificacion);
        Task<bool> UpdateCalificacion(Calificacion calificacion);
        Task<bool> DeleteCalificacion(long Id);
    }
}
