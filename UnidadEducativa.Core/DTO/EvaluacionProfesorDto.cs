using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.DTO
{
    public class EvaluacionProfesorDto
    {
        public long Id { get; set; }
        public long NotaSer { get; set; }
        public long NotaDecidir { get; set; }
        public long IdEstudiante { get; set; }
        public long IdEvalPoseedor { get; set; }
        public long EstadoSql { get; set; }
    }
}
