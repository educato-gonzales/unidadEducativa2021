using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IMateriaService
    {
        IEnumerable<Materia> GetMaterias();
        Task<Materia> GetMateria(long Id);
        Task InsertMateria(Materia materia);
        Task<bool> UpdateMateria(Materia materia);
        Task<bool> DeleteMateria(long Id);
    }
}
