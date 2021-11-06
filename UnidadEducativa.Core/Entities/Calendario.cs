using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Calendario : BaseEntity
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public string Descripcion { get; set; }
        public long IdPeriodo { get; set; }
        public long EstadoSql { get; set; }

        public virtual Periodo IdPeriodoNavigation { get; set; }
    }
}
