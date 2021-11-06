using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IInstitucionService
    {
        IEnumerable<Institucion> GetInstituciones();
        Task<Institucion> GetInstitucion(long Id);
        Task InsertInstitucion(Institucion institucion);
        Task<bool> UpdateInstitucion(Institucion institucion);
        Task<bool> DeleteInstitucion(long Id);
    }
}
