using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IEstudianteService
    {
        IEnumerable<Estudiante> GetEstudiantes();
        Task<Estudiante> GetEstudiante(long Id);
        Task InsertEstudiante(Estudiante estudiante);
        Task<bool> UpdateEstudiante(Estudiante estudiante);
        Task<bool> DeleteEstudiante(long Id);
    }
}
