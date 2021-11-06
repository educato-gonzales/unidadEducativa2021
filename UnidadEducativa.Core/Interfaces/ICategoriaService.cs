using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetCategorias();
        Task<Categoria> GetCategoria(long Id);
        Task InsertCategoria(Categoria categoria);
        Task<bool> UpdateCategoria(Categoria categoria);
        Task<bool> DeleteCategoria(long Id);
    }
}
