using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Curso : BaseEntity
    {
        public Curso()
        {
            Asistencia = new HashSet<Asistencia>();
            EstudianteCurso = new HashSet<EstudianteCurso>();
            MateriaDictada = new HashSet<MateriaDictada>();
            Nota = new HashSet<Nota>();
            Notas = new HashSet<Notas>();
            Notificacion = new HashSet<Notificacion>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Nivel { get; set; }
        public string Turno { get; set; }
        public string Descripcion { get; set; }
        public long IdParalelo { get; set; }
        public long EstadoSql { get; set; }

        public virtual Paralelo IdParaleloNavigation { get; set; }
        public virtual ICollection<Asistencia> Asistencia { get; set; }
        public virtual ICollection<EstudianteCurso> EstudianteCurso { get; set; }
        public virtual ICollection<MateriaDictada> MateriaDictada { get; set; }
        public virtual ICollection<Nota> Nota { get; set; }
        public virtual ICollection<Notas> Notas { get; set; }
        public virtual ICollection<Notificacion> Notificacion { get; set; }
    }
}
