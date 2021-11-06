using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Fotos : BaseEntity
    {
        public string Descripcion { get; set; }
        public string PathImg { get; set; }
        public long IdEstudiante { get; set; }
        public long EstadoSql { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
    }
}
