using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IRolRepository
    {
        Task<IEnumerable<Rol>> GetRols();
        Task<Rol> GetRol(long Id);
        Task InsertRol(Rol rol);
        Task<bool> UpdateRol(Rol rol);
        Task<bool> DeleteRol(long Id);
    }
}
