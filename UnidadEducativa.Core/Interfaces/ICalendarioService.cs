using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface ICalendarioService
    {
        IEnumerable<Calendario> GetCalendarios();
        Task<Calendario> GetCalendario(long Id);
        Task InsertCalendario(Calendario calendario);
        Task<bool> UpdateCalendario(Calendario calendario);
        Task<bool> DeleteCalendario(long Id);
    }
}
