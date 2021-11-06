using System;
using System.Collections.Generic;
using System.Text;

namespace UnidadEducativa.Core.DTO
{
    public class HorarioDto
    {
        public long Id { get; set; }
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public long EstadoSql { get; set; }
    }
}
