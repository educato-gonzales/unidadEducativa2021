using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IAsistenciaService
    {
        IEnumerable<Asistencia> GetAsistencias();
        Task<Asistencia> GetAsistencia(long Id);
        Task InsertAsistencia(Asistencia asistencia);
        Task<bool> UpdateAsistencia(Asistencia asistencia);
        Task<bool> DeleteAsistencia(long Id);
    }
}
