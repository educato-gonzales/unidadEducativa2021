using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class EstudianteMateria : BaseEntity
    {
        public long IdMateria { get; set; }
        public long IdEstudiante { get; set; }
        public long IdHorario { get; set; }
        public long IdPeriodo { get; set; }
        public long EstadoSql { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual Horario IdHorarioNavigation { get; set; }
        public virtual Materia IdMateriaNavigation { get; set; }
        public virtual Periodo IdPeriodoNavigation { get; set; }
    }
}
