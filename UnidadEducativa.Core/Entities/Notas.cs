using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.Entities
{
    public partial class Notas : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public long IdCurso { get; set; }
        public long IdPeriodo { get; set; }
        public long IdMateria { get; set; }
        public long IdCategoria { get; set; }
        public long IdEstudiante { get; set; }
        public long? IdRef { get; set; }
        public decimal Nota { get; set; }
        public long EstadoSql { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual Materia IdMateriaNavigation { get; set; }
        public virtual Periodo IdPeriodoNavigation { get; set; }
    }
}
