using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IPeriodoService
    {
        IEnumerable<Periodo> GetPeriodos();
        Task<Periodo> GetPeriodo(long Id);
        Task InsertPeriodo(Periodo periodo);
        Task<bool> UpdatePeriodo(Periodo periodo);
        Task<bool> DeletePeriodo(long Id);
    }
}
