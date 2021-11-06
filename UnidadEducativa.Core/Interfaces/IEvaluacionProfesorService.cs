using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnidadEducativa.Core.Entities;

namespace UnidadEducativa.Core.Interfaces
{
    public interface IEvaluacionProfesorService
    {
        IEnumerable<EvaluacionProfesor> GetEvaluacionProfesores();
        Task<EvaluacionProfesor> GetEvaluacionProfesor(long Id);
        Task InsertEvaluacionProfesor(EvaluacionProfesor evaluacionProfesor);
        Task<bool> UpdateEvaluacionProfesor(EvaluacionProfesor evaluacionProfesor);
        Task<bool> DeleteEvaluacionProfesor(long Id);
    }
}
