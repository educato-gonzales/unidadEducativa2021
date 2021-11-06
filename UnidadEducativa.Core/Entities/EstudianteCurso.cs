using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.Entities
{
    public partial class EstudianteCurso : BaseEntity
    {
        public long IdEstudiante { get; set; }
        public long IdCurso { get; set; }
        public long EstadoSql { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Estudiante IdEstudianteNavigation { get; set; }
    }
}
