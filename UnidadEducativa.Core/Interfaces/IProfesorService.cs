using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IProfesorService
    {
        IEnumerable<Profesor> GetProfesores();
        Task<Profesor> GetProfesor(long Id);
        Task InsertProfesor(Profesor profesor);
        Task<bool> UpdateProfesor(Profesor profesor);
        Task<bool> DeleteProfesor(long Id);
    }
}
