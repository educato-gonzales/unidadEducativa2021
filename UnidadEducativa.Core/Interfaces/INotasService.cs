using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface INotasService
    {
        IEnumerable<Notas> GetNotass();
        Task<Notas> GetNotas(long Id);
        Task InsertNotas(Notas notas);
        Task<bool> UpdateNotas(Notas notas);
        Task<bool> DeleteNotas(long Id);
    }
}
