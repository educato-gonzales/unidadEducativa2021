using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Nota : BaseEntity
    {
        public Nota()
        {
            Autoevaluacion = new HashSet<Autoevaluacion>();
            Calificacion = new HashSet<Calificacion>();
            EvaluacionProfesor = new HashSet<EvaluacionProfesor>();
        }

        public DateTime Fecha { get; set; }
        public decimal? Nota1 { get; set; }
        public string Descripcion { get; set; }
        public long IdCurso { get; set; }
        public long IdPeriodo { get; set; }
        public long IdMateria { get; set; }
        public long IdCategoria { get; set; }
        public long? IdRef { get; set; }
        public long EstadoSql { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Materia IdMateriaNavigation { get; set; }
        public virtual Periodo IdPeriodoNavigation { get; set; }
        public virtual ICollection<Autoevaluacion> Autoevaluacion { get; set; }
        public virtual ICollection<Calificacion> Calificacion { get; set; }
        public virtual ICollection<EvaluacionProfesor> EvaluacionProfesor { get; set; }

    }
}
