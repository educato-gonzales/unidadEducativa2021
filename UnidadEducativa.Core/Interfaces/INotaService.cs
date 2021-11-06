using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface INotaService
    {
        IEnumerable<Nota> GetNotas();
        Task<Nota> GetNota(long Id);
        Task InsertNota(Nota nota);
        Task<bool> UpdateNota(Nota nota);
        Task<bool> DeleteNota(long Id);
    }
}
