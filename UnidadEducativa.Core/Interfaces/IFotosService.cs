using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IFotosService
    {
        IEnumerable<Fotos> GetFotoss();
        Task<Fotos> GetFotos(long Id);
        Task InsertFotos(Fotos fotos);
        Task<bool> UpdateFotos(Fotos fotos);
        Task<bool> DeleteFotos(long Id);
    }
}
