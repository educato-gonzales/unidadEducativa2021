﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnidadEducativa.Core.Entities
{
    public partial class Usuario : BaseEntity
    {
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Estado { get; set; }
        public string Entidad { get; set; }
        public long? IdRef { get; set; }
        public long IdRol { get; set; }
        public long EstadoSql { get; set; }


        public virtual Rol IdRolNavigation { get; set; }

        [NotMapped]
        public string Token { get; set; }

    }
}
