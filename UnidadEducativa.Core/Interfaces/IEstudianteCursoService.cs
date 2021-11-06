using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IEstudianteCursoService
    {
        IEnumerable<EstudianteCurso> GetEstudianteCursos();
        Task<EstudianteCurso> GetEstudianteCurso(long Id);
        Task InsertEstudianteCurso(EstudianteCurso estudianteCurso);
        Task<bool> UpdateEstudianteCurso(EstudianteCurso estudianteCurso);
        Task<bool> DeleteEstudianteCurso(long Id);
    }
}
