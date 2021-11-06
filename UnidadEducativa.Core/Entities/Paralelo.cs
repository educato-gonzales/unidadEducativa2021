using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Paralelo : BaseEntity
    {
        public Paralelo()
        {
            Curso = new HashSet<Curso>();
        }

        public string Nombre { get; set; }
        public long EstadoSql { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }

    }
}
