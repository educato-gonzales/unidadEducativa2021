using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Materia : BaseEntity
    {
        public Materia()
        {
            Asistencia = new HashSet<Asistencia>();
            EstudianteMateria = new HashSet<EstudianteMateria>();
            MateriaDictada = new HashSet<MateriaDictada>();
            Nota = new HashSet<Nota>();
            Notas = new HashSet<Notas>();
        }

        public long Id { get; set; }
        public string Sigla { get; set; }
        public string Nombre { get; set; }
        public string Nivel { get; set; }
        public string Descripcion { get; set; }
        public long EstadoSql { get; set; }

        public virtual ICollection<Asistencia> Asistencia { get; set; }
        public virtual ICollection<EstudianteMateria> EstudianteMateria { get; set; }
        public virtual ICollection<MateriaDictada> MateriaDictada { get; set; }
        public virtual ICollection<Nota> Nota { get; set; }
        public virtual ICollection<Notas> Notas { get; set; }
    }
}
