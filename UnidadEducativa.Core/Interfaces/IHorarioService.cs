using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IHorarioService
    {
        IEnumerable<Horario> GetHorarios();
        Task<Horario> GetHorario(long Id);
        Task InsertHorario(Horario horario);
        Task<bool> UpdateHorario(Horario horario);
        Task<bool> DeleteHorario(long Id);
    }
}
