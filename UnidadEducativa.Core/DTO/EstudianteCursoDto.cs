using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.DTO
{
    public class EstudianteCursoDto
    {
        public long Id { get; set; }
        public long IdEstudiante { get; set; }
        public long IdCurso { get; set; }
        public long EstadoSql { get; set; }
    }
}
