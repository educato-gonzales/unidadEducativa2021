using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Estudiante : BaseEntity
    {
        public Estudiante()
        {
            Asistencia = new HashSet<Asistencia>();
            Calificacion = new HashSet<Calificacion>();
            EstudianteCurso = new HashSet<EstudianteCurso>();
            EstudianteMateria = new HashSet<EstudianteMateria>();
            EvaluacionProfesor = new HashSet<EvaluacionProfesor>();
            Fotos = new HashSet<Fotos>();
            Notas = new HashSet<Notas>();
            Rude = new HashSet<Rude>();
        }

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

        public virtual Periodo IdPeriodoNavigation { get; set; }
        public virtual ICollection<Asistencia> Asistencia { get; set; }
        public virtual ICollection<Calificacion> Calificacion { get; set; }
        public virtual ICollection<EstudianteCurso> EstudianteCurso { get; set; }
        public virtual ICollection<EstudianteMateria> EstudianteMateria { get; set; }
        public virtual ICollection<EvaluacionProfesor> EvaluacionProfesor { get; set; }
        public virtual ICollection<Fotos> Fotos { get; set; }
        public virtual ICollection<Notas> Notas { get; set; }
        public virtual ICollection<Rude> Rude { get; set; }
    }
}
