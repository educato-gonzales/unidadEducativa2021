using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.Entities
{
    public partial class Administrador : BaseEntity
    {
        public string CedulaIdentidad { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombres { get; set; }
        public bool Sexo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public long EstadoSql { get; set; }
    }
}
