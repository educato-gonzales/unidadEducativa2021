using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.DTO
{
    public class EstudianteDto
    {
        public long Id { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CedulaIdentidad { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public long? IdPeriodo { get; set; }
        public long EstadoSql { get; set; }
    }
}
