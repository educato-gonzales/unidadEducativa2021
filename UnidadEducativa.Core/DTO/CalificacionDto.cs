using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.DTO
{
    public class CalificacionDto
    {
        public long Id { get; set; }
        public long Nota { get; set; }
        public long IdEstudiante { get; set; }
        public long IdEvalPoseedor { get; set; }
        public long EstadoSql { get; set; }
    }
}
