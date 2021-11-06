using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Horario : BaseEntity
    {
        public Horario()
        {
            EstudianteMateria = new HashSet<EstudianteMateria>();
            MateriaDictada = new HashSet<MateriaDictada>();
        }
        
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public long EstadoSql { get; set; }

        public virtual ICollection<EstudianteMateria> EstudianteMateria { get; set; }
        public virtual ICollection<MateriaDictada> MateriaDictada { get; set; }
    }
}
