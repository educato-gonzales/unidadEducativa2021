using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Calificacion : BaseEntity
    {
        public long Nota { get; set; }
        public long IdEstudiante { get; set; }
        public long IdEvalPoseedor { get; set; }
        public long EstadoSql { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual Nota IdEvalPoseedorNavigation { get; set; }
    }
}
