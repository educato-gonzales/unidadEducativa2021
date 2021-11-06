using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Profesor : BaseEntity
    {
        public Profesor()
        {
            MateriaDictada = new HashSet<MateriaDictada>();
            Notificacion = new HashSet<Notificacion>();
        }

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


        public virtual ICollection<MateriaDictada> MateriaDictada { get; set; }
        public virtual ICollection<Notificacion> Notificacion { get; set; }
    }
}
