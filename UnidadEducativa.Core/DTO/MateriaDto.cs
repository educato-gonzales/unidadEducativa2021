using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.DTO
{
    public class MateriaDto
    {
        public long Id { get; set; }
        public string Sigla { get; set; }
        public string Nombre { get; set; }
        public string Nivel { get; set; }
        public string Descripcion { get; set; }
        public long EstadoSql { get; set; }
    }
}
