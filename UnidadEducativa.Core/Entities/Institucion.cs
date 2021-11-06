using System;
using System.Collections.Generic;

namespace UnidadEducativa.Core.Entities
{
    public partial class Institucion : BaseEntity
    {
        public string CodUe { get; set; }
        public string NombreUe { get; set; }
        public long? NumResolucionAdm1 { get; set; }
        public DateTime? FechaResolucionAdm1 { get; set; }
        public string CodDistritoEducativo { get; set; }
        public string NombreDistritoEducativo { get; set; }
        public long? NumResolucionAdm2 { get; set; }
        public DateTime? FechaResolucionAdm2 { get; set; }
        public string CodEdificioEscolar { get; set; }
        public string NuevoCodEdificioEscolar { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string SeccionMunicipal { get; set; }
        public string Canton { get; set; }
        public string Ciudad { get; set; }
        public string Zona { get; set; }
        public string Direccion { get; set; }
        public bool Estatal { get; set; }
        public bool Convenio { get; set; }
        public string NombreInstitucion { get; set; }
        public bool Comunitaria { get; set; }
        public bool Privada { get; set; }
        public bool EdFormal { get; set; }
        public bool EdInicial { get; set; }
        public bool EdPrimaria { get; set; }
        public bool EdSecundaria { get; set; }
        public bool EdAlternativa { get; set; }
        public bool EdAdultos { get; set; }
        public bool EdEspecial { get; set; }
        public bool EdPermanente { get; set; }
        public bool Bachillerato { get; set; }
        public bool Humanistico { get; set; }
        public bool Tecnico { get; set; }
        public string Siglas { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string Correo { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Web { get; set; }
        public string Descripcion { get; set; }
        public string LugarRecepcion { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public long EstadoSql { get; set; }

    }
}
