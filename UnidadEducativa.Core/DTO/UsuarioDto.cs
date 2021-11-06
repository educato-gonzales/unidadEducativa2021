using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.DTO
{
    public class UsuarioDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Estado { get; set; }
        public string Entidad { get; set; }
        public long? IdRef { get; set; }
        public long IdRol { get; set; }
        public long EstadoSql { get; set; }
    }
}
