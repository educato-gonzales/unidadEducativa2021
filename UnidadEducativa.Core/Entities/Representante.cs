using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Representante : BaseEntity
    {
        public Representante()
        {
            RudeIdRepresentanteMadreNavigation = new HashSet<Rude>();
            RudeIdRepresentantePadreNavigation = new HashSet<Rude>();
            RudeIdRepresentanteTutorNavigation = new HashSet<Rude>();
        }

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

        public virtual ICollection<Rude> RudeIdRepresentanteMadreNavigation { get; set; }
        public virtual ICollection<Rude> RudeIdRepresentantePadreNavigation { get; set; }
        public virtual ICollection<Rude> RudeIdRepresentanteTutorNavigation { get; set; }
    }
}
