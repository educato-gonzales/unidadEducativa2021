using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IRepresentanteService
    {
        IEnumerable<Representante> GetRepresentantes();
        Task<Representante> GetRepresentante(long Id);
        Task InsertRepresentante(Representante representante);
        Task<bool> UpdateRepresentante(Representante representante);
        Task<bool> DeleteRepresentante(long Id);
    }
}
