using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IAdministradorService
    {
        IEnumerable<Administrador> GetAdministradores();
        Task<Administrador> GetAdministrador(long Id);
        Task InsertAdministrador(Administrador administrador);
        Task<bool> UpdateAdministrador(Administrador administrador);
        Task<bool> DeleteAdministrador(long Id);
    }
}
