using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.DTO
{
    public class RepresentanteDto
    {
        public long Id { get; set; }
        public string CedulaIdentidad { get; set; }
        public string Complemento { get; set; }
        public string Expedido { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombres { get; set; }
        public string IdiomaFrecuente { get; set; }
        public string OcupacionLaboral { get; set; }
        public string GradoInstruccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Parentesco { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public long EstadoSql { get; set; }

    }
}
