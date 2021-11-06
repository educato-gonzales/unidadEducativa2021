using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Asistencia : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public long IdCurso { get; set; }
        public long IdEstudiante { get; set; }
        public long IdMateria { get; set; }
        public long IdPeriodo { get; set; }
        public long EstadoSql { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual Materia IdMateriaNavigation { get; set; }
        public virtual Periodo IdPeriodoNavigation { get; set; }
    }
}
