using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.DTO
{
    public class ProfesorDto
    {
        public long Id { get; set; }
        public string CedulaIdentidad { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombres { get; set; }
        public bool Sexo { get; set; }
        public bool Rda { get; set; }
        public bool Cas { get; set; }
        public string TituloProvNacional { get; set; }
        public string TituloProfesional { get; set; }
        public string Posgrado { get; set; }
        public string IdiomaFrecuente { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public long EstadoSql { get; set; }

    }
}
