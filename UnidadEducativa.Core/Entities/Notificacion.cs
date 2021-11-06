using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Notificacion : BaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public long IdCurso { get; set; }
        public long IdProfesor { get; set; }
        public long EstadoSql { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Profesor IdProfesorNavigation { get; set; }
    }
}
