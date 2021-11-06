using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class MateriaDictada : BaseEntity
    {
        public string Descripcion { get; set; }
        public long IdMateria { get; set; }
        public long IdCurso { get; set; }
        public long IdProfesor { get; set; }
        public long IdHorario { get; set; }
        public long IdPeriodo { get; set; }
        public long EstadoSql { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Horario IdHorarioNavigation { get; set; }
        public virtual Materia IdMateriaNavigation { get; set; }
        public virtual Periodo IdPeriodoNavigation { get; set; }
        public virtual Profesor IdProfesorNavigation { get; set; }
    }
}
