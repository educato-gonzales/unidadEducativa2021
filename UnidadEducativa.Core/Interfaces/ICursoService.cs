using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface ICursoService
    {
        IEnumerable<Curso> GetCursos();
        Task<Curso> GetCurso(long Id);
        Task InsertCurso(Curso curso);
        Task<bool> UpdateCurso(Curso curso);
        Task<bool> DeleteCurso(long Id);
    }
}
