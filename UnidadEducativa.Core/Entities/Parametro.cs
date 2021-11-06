using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Parametro : BaseEntity
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public long EstadoSql { get; set; }
    }
}
