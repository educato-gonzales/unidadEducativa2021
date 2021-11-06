using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IEstudianteMateriaService
    {
        IEnumerable<EstudianteMateria> GetEstudianteMaterias();
        Task<EstudianteMateria> GetEstudianteMateria(long Id);
        Task InsertEstudianteMateria(EstudianteMateria estudianteMateria);
        Task<bool> UpdateEstudianteMateria(EstudianteMateria estudianteMateria);
        Task<bool> DeleteEstudianteMateria(long Id);
    }
}
