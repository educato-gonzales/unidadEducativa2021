using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Categoria : BaseEntity
    {
        public Categoria()
        {
            Nota = new HashSet<Nota>();
            Notas = new HashSet<Notas>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long EstadoSql { get; set; }

        public virtual ICollection<Nota> Nota { get; set; }
        public virtual ICollection<Notas> Notas { get; set; }
    }
}
