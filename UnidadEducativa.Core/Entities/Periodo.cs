using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Periodo : BaseEntity
    {
        public Periodo()
        {
            Asistencia = new HashSet<Asistencia>();
            Calendario = new HashSet<Calendario>();
            Estudiante = new HashSet<Estudiante>();
            EstudianteMateria = new HashSet<EstudianteMateria>();
            MateriaDictada = new HashSet<MateriaDictada>();
            Nota = new HashSet<Nota>();
            Notas = new HashSet<Notas>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public long EstadoSql { get; set; }

        public virtual ICollection<Asistencia> Asistencia { get; set; }
        public virtual ICollection<Calendario> Calendario { get; set; }
        public virtual ICollection<Estudiante> Estudiante { get; set; }
        public virtual ICollection<EstudianteMateria> EstudianteMateria { get; set; }
        public virtual ICollection<MateriaDictada> MateriaDictada { get; set; }
        public virtual ICollection<Nota> Nota { get; set; }
        public virtual ICollection<Notas> Notas { get; set; }
    }
}
