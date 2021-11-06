using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Rol : BaseEntity
    {
        public Rol()
        {
            Usuario = new HashSet<Usuario>();
        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long EstadoSql { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }

    }
}
