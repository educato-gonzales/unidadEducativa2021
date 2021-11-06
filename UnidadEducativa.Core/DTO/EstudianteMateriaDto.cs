using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.DTO
{
    public class EstudianteMateriaDto
    {
        public long Id { get; set; }
        public long IdMateria { get; set; }
        public long IdEstudiante { get; set; }
        public long IdHorario { get; set; }
        public long IdPeriodo { get; set; }
        public long EstadoSql { get; set; }
    }
}
