using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.DTO
{
    public class FotosDto
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public string PathImg { get; set; }
        public long IdEstudiante { get; set; }
        public long EstadoSql { get; set; }
    }
}
