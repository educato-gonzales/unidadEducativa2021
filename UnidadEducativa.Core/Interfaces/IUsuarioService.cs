using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetUsuarios();
        Task<Usuario> GetUsuario(long Id);
        Task InsertUsuario(Usuario usuario);
        Task<bool> UpdateUsuario(Usuario usuario);
        Task<bool> DeleteUsuario(long Id);
    }
}
