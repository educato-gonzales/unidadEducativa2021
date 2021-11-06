using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.DTO
{
    public class ParametroDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public long EstadoSql { get; set; }
    }
}
