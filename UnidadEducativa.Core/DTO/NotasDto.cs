using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.DTO
{
    public class NotasDto
    {
        public long Id { get; set; }
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
    }
}
